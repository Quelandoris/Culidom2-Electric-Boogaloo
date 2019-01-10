using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureGenerator : MonoBehaviour {

    private enum RoadStyle { MAJOR = 0, MINOR, INNER, NONE }
    private enum NeighborRoadState { YES, NO, NULL }

    readonly static Color[] debugDistricts = { Color.red, Color.blue, Color.magenta, Color.cyan, Color.yellow, Color.green };
    readonly static float yieldTimer = 0.03f;

    public int resolution = 256;
    public int seed;
    public bool randomizeSeed = true;

    public int maxCycles = 14;
    public int[] seedCycles;
    public int xCells = 30;
    public int yCells = 15;

    public int xSecondaryCells;
    public int ySecondaryCells;

    public float secondaryAmplitude = 1;

    private Texture2D texture;

    float stepSize;

    float cellStepX;
    float cellStepY;

    Point[,] points;
    UrbanBuffer urbanizations;

    Point[,] secondaryPoints;
    UrbanBuffer secondaryUrbanizations;

    int[,] mapDistricts;

    public GameObject[] urbanFabs;
    public GameObject[] suburbFabs;
    public GameObject[] ruralFabs;
    public GameObject[] lotFabs;
    public GameObject roadStraightFab, roadTurnFab, roadTriFab, roadQuadFab;
    public GameObject debugNullFab;

    public RectTransform mainCanvas;

    public MapData mapData;
    public GameObject[,] mapTiles;
    public List<GameObject> allTiles;

    public float urbanThreshold;
    public float suburbThreshold;

    public GameObject waitScreen;
    public Text waitText;
    public RectTransform waitAnim;

    void Awake()
    {
        if (randomizeSeed)
        {
            seed = UnityEngine.Random.Range(0, int.MaxValue);
        }
        
    }

    private void Start()
    {
        StartCoroutine("GenerateMap");
    }

    private void OnEnable()
    {
        GameController.Instance().world = this;
    }

    private void Update()
    {
        waitAnim.Rotate(-100 * Time.deltaTime * Vector3.forward);
    }

    public bool SameDistrict(Building restaurant) {
        for (int i = 0; i < allTiles.Count; i++) {
            if (allTiles[i].GetComponent<WorldTile>().district == restaurant.tile.district) {
                return true;
            }
        }

        return false;
    }

    public int AmountOfCityBlocks(Building restaurant) {
        int amountOfCityBlocks = 0;
        for (int i = 0; i < allTiles.Count; i++) {
            if (allTiles[i].GetComponent<WorldTile>().district == restaurant.tile.district)
            {
                if (allTiles[i].GetComponent<WorldTile>().urbanization > 0.3f) {
                    amountOfCityBlocks++;
                }
            }
        }
        return amountOfCityBlocks;
    }

    public int AmountOfRuralBlocks(Building restaurant) {
        int amountOfRuralBlocks = 0;
        for (int i = 0; i < allTiles.Count; i++)
        {
            if (allTiles[i].GetComponent<WorldTile>().district == restaurant.tile.district)
            {
                if (allTiles[i].GetComponent<WorldTile>().urbanization < 0.009f)
                {
                    amountOfRuralBlocks++;
                }
            }
        }
        return amountOfRuralBlocks;
    }

    void FillTexture()
    {
        UnityEngine.Random.InitState(seed);
        for (int y = 0; y < resolution; y++)
        {
            for(int x = 0; x < resolution; x++)
            {
                float minDist = 100; //3*Mathf.Max(cellStepX,cellStepY);
                float minUrban = 0;

                float secMinDist = 500;
                float secMinUrban = 0;

                Color minDebugColor = Color.white;

                int xCellCoord = Mathf.FloorToInt(x * stepSize * xCells);
                int yCellCoord = Mathf.FloorToInt(y * stepSize * yCells);

                int xSecCellCoord = Mathf.FloorToInt(x * stepSize * xSecondaryCells);
                int ySecCellCoord = Mathf.FloorToInt(y * stepSize * ySecondaryCells);

                //List<Point> adjacents = new List<Point>();
                for (int iy = -1; iy <= 1; iy++)
                {
                    for(int ix = -1; ix <= 1; ix++)
                    {
                        try
                        {
                            Vector2 adjustedCoord = points[xCellCoord + ix, yCellCoord + iy].position;
                            float dist = Vector2.Distance(new Vector2(x * stepSize, y * stepSize), adjustedCoord);
                            if (dist < minDist)
                            {
                                minDist = dist;
                                minUrban = urbanizations.Read()[xCellCoord + ix, yCellCoord + iy];
                            }

                            /*
                            Point oldPoint = points[xCellCoord + ix, yCellCoord + iy];
                            Point newPoint = new Point(oldPoint.position, oldPoint.x, oldPoint.y);
                            newPoint.dist = Vector2.Distance(oldPoint.position, new Vector2(x*stepSize,y*stepSize));
                            adjacents.Add(newPoint);
                            */
                        }
                        catch
                        {
                            //Out of Bounds
                        }

                        try
                        {

                            Vector2 adjustedSecCoord = secondaryPoints[xSecCellCoord + ix, ySecCellCoord + iy].position;
                            float dist = Vector2.Distance(new Vector2(x * stepSize, y * stepSize), adjustedSecCoord);
                            if (dist < secMinDist)
                            {
                                secMinDist = dist;
                                secMinUrban = secondaryUrbanizations.Read()[xSecCellCoord + ix, ySecCellCoord + iy];

                                minDebugColor = debugDistricts[(xSecCellCoord + ix + (ySecCellCoord + iy) * xSecondaryCells)%debugDistricts.Length];
                            }
                        }
                        catch
                        {
                            //Out of Bounds
                        }
                    }
                    
                }
                //adjacents.Sort();
                //float lineLength = (adjacents[1].position - adjacents[0].position).magnitude;
                //Vector3 projection = Vector3.Project(new Vector3(x*stepSize,y*stepSize,0)-new Vector3(adjacents[0].x,adjacents[0].y,0), new Vector3(adjacents[1].x, adjacents[1].y, 0)- new Vector3(adjacents[0].x, adjacents[0].y, 0));
                //texture.SetPixel(x, y, Color.Lerp(Color.blue, Color.red, projection.magnitude/lineLength));

                //float combinedUrban = Mathf.Clamp(minUrban + secMinUrban, 0, 1);

                float combinedUrban = Mathf.Clamp(minUrban * (1+secMinUrban), 0, 1);

                texture.SetPixel(x, y, Color.Lerp(Color.black,Color.white,combinedUrban) * minDebugColor);
                
                if (Mathf.Repeat(x * stepSize, cellStepX) < 0.002f || Mathf.Repeat(y * stepSize, cellStepY) < 0.002f)
                {
                    //Grid Lines
                    //texture.SetPixel(x, y, Color.green);
                }
                if (minDist < 0.005f)
                {
                    //Centers
                    //texture.SetPixel(x, y, Color.black);
                }
            }
        }
        texture.Apply();
    }

    IEnumerator GenerateMap()
    {
        float startTime = Time.realtimeSinceStartup;
        

        waitScreen.SetActive(true);
        waitText.text = "Starting world Creation";
        yield return new WaitForSeconds(Time.deltaTime);
        float focusTime = Time.realtimeSinceStartup;

        UnityEngine.Random.InitState(seed);

        stepSize = 1f / resolution;
        cellStepX = 1f / xCells;
        cellStepY = 1f / yCells;

        int maxDistrict = -1;
        List<Point>[] districtMembers;

        /* This code sets up a debug texture
        texture = new Texture2D(resolution, resolution, TextureFormat.RGB24, true);
        texture.name = "Procedural Texture";
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Point;
        GetComponent<MeshRenderer>().material.mainTexture = texture;
        */

        #region Place primary cell centers
        points = new Point[xCells, yCells];
        urbanizations = new UrbanBuffer(xCells, yCells);
        for (int y = 0; y < points.GetLength(1); y++)
        {
            for (int x = 0; x < points.GetLength(0); x++)
            {
                points[x, y] = new Point(new Vector2((x + UnityEngine.Random.value) * cellStepX, (y + UnityEngine.Random.value) * cellStepY), x, y);
                urbanizations.Write()[x, y] = 0;

                waitText.text = "Shaping the world: " + (y * xCells + x + 1) + "/" + (xCells * yCells);
                if(Time.realtimeSinceStartup - focusTime >= yieldTimer)
                {
                    yield return new WaitForSeconds(Time.deltaTime);
                    focusTime = Time.realtimeSinceStartup;
                }
            }

        }
        //Primary is not swapped as the population center must be assigned first
        #endregion

        #region Place secondary cell centers
        float secondaryCellStepX = 1f / xSecondaryCells;
        float secondaryCellStepY = 1f / ySecondaryCells;
        secondaryPoints = new Point[xSecondaryCells, ySecondaryCells];
        secondaryUrbanizations = new UrbanBuffer(xSecondaryCells, ySecondaryCells);

        mapDistricts = new int[xSecondaryCells, ySecondaryCells];
        for (int y = 0; y < secondaryPoints.GetLength(1); y++)
        {
            for (int x = 0; x < secondaryPoints.GetLength(0); x++)
            {
                secondaryPoints[x, y] = new Point(new Vector2((x + UnityEngine.Random.value) * secondaryCellStepX, (y + UnityEngine.Random.value) * secondaryCellStepY), x, y);
                secondaryUrbanizations.Write()[x, y] = (UnityEngine.Random.Range(-1f, 1f) * secondaryAmplitude);
                if (x == 0 || x == xSecondaryCells - 1 || y == 0 || y == ySecondaryCells - 1)
                {
                    mapDistricts[x, y] = -1;
                }
                else
                {
                    mapDistricts[x, y] = x + (y * xSecondaryCells);
                    maxDistrict = Mathf.Max(mapDistricts[x, y], maxDistrict);
                }

                waitText.text = "Shaping the districts: " + (y * xSecondaryCells + x + 1) + "/" + (xSecondaryCells * ySecondaryCells);
                if (Time.realtimeSinceStartup - focusTime >= yieldTimer)
                {
                    yield return new WaitForSeconds(Time.deltaTime);
                    focusTime = Time.realtimeSinceStartup;
                }
            }
        }
        /* IN case this breaks things, here is the old version
       secondaryUrbanizations = new UrbanBuffer(xCells, yCells); 
        
        mapDistricts = new int[xCells, yCells];
        for (int y = 0; y < secondaryPoints.GetLength(1); y++)
        {
            for (int x = 0; x < secondaryPoints.GetLength(0); x++)
            {
                secondaryPoints[x, y] = new Point(new Vector2((x + UnityEngine.Random.value) * secondaryCellStepX, (y + UnityEngine.Random.value) * secondaryCellStepY), x, y);
                secondaryUrbanizations.Write()[x, y] = (UnityEngine.Random.Range(-1f, 1f) * secondaryAmplitude);
                if (x == 0 || x == xSecondaryCells - 1 || y == 0 || y == ySecondaryCells - 1)
                {
                    mapDistricts[x, y] = -1;
                }
                else
                {
                    mapDistricts[x, y] = x + (y * resolution);
                }
            }
        }
        */
        secondaryUrbanizations.Swap();
        #endregion


        #region Urban growth simulation
        //Choose initial urban center
        List<Point> regions = new List<Point>();
        foreach (Point p in points)
        {
            regions.Add(p);
        }
        regions.Sort();

        List<Point> centers = new List<Point>();
        Point mainCenter = regions[UnityEngine.Random.Range(0, regions.Count / 6)];
        centers.Add(mainCenter);

        urbanizations.Write()[centers[0].x, centers[0].y] = 1;

        urbanizations.Swap();

        //Begin simulation
        for (int tick = 0; tick < maxCycles; tick++)
        {

            //Perform simulation for the current tick
            for (int y = 0; y < yCells; y++)
            {
                for (int x = 0; x < xCells; x++)
                {
                    UrbanizeAverage(y, x);
                    //UrbanizeBleed(y, x);
                }
            }

            //If it is time to add a new urban sub-center, do so
            bool placeSeed = false;
            for (int i = 0; i < seedCycles.Length; i++)
            {
                if (seedCycles[i] == tick)
                {
                    placeSeed = true;
                }
            }

            if (placeSeed)
            {
                int selection = UnityEngine.Random.Range(0, regions.Count / (3));
                while (centers.Contains(regions[selection])) //Rechoose if there's a duplicate
                {
                    selection = UnityEngine.Random.Range(0, regions.Count / (3));
                }
                centers.Add(regions[selection]);
            }

            if (tick != maxCycles - 1)
            {
                foreach (Point p in centers)
                {
                    urbanizations.Write()[p.x, p.y] = 1;
                }
            }
            urbanizations.Swap();

            waitText.text = "We built this city: " + (tick +1) + "/" + maxCycles;
            if (Time.realtimeSinceStartup - focusTime >= yieldTimer)
            {
                yield return new WaitForSeconds(Time.deltaTime);
                focusTime = Time.realtimeSinceStartup;
            }
        }
        #endregion

        #region Mark tiles as being roads
        bool[,] hasRoad = new bool[resolution, resolution];
        Point roadCenter = centers[0];

        int ringSegments = UnityEngine.Random.Range(4, 9);
        List<float> ringAngles = new List<float>();
        List<float> ringDistances = new List<float>();

        float ringSectionAngle = 360f / ringSegments; ;
        for(int i = 0; i < ringSegments; i++)
        {
            float thisAngle = i * ringSectionAngle + (UnityEngine.Random.Range(1/6f, 5/6f) * ringSectionAngle);
            ringAngles.Add(thisAngle);
            ringDistances.Add(UnityEngine.Random.Range(0.1f, 0.35f));
        }

        for(int i = 0; i < ringAngles.Count; i++)
        {
            Vector2 startDir = (Mathf.Sin(Mathf.Deg2Rad * ringAngles[i]) * Vector2.up + Mathf.Cos(Mathf.Deg2Rad * ringAngles[i]) * Vector2.right).normalized;
            Vector2 roadStart = roadCenter.position + ringDistances[i] * startDir;

            Vector2 endDir = (Mathf.Sin(Mathf.Deg2Rad * ringAngles[(i+1)%ringAngles.Count]) * Vector2.up + Mathf.Cos(Mathf.Deg2Rad * ringAngles[(i + 1) % ringAngles.Count]) * Vector2.right).normalized;
            Vector2 roadEnd = roadCenter.position + ringDistances[(i + 1) % ringDistances.Count] * endDir;

            PlaceRoads(hasRoad, resolution * roadStart, resolution * roadEnd);

            waitText.text = "Paving the roads...";
            if (Time.realtimeSinceStartup - focusTime >= yieldTimer)
            {
                yield return new WaitForSeconds(Time.deltaTime);
                focusTime = Time.realtimeSinceStartup;
            }
        }

        

        //Place a main road
        for(int i = 0; i < ringSegments; i++)
        {
            Vector2 startPoint;
            Vector2 startDir;
            Vector2 endPoint;
            Vector2 endDir;
            int selectedRoad = UnityEngine.Random.Range(0, ringAngles.Count);
            RoadStyle roadType = (RoadStyle)UnityEngine.Random.Range(0, 4);
            switch (roadType)
            {
                case RoadStyle.MAJOR:
                    startPoint = roadCenter.position;
                    startDir = (Mathf.Sin(Mathf.Deg2Rad * ringAngles[selectedRoad]) * Vector2.up + Mathf.Cos(Mathf.Deg2Rad * ringAngles[selectedRoad]) * Vector2.right).normalized;
                    endPoint = startPoint + 2 * startDir;
                    PlaceRoads(hasRoad, resolution * startPoint, resolution * endPoint);
                    break;
                case RoadStyle.MINOR:
                    startDir = (Mathf.Sin(Mathf.Deg2Rad * ringAngles[selectedRoad]) * Vector2.up + Mathf.Cos(Mathf.Deg2Rad * ringAngles[selectedRoad]) * Vector2.right).normalized;
                    startPoint = roadCenter.position + ringDistances[selectedRoad] * startDir;
                    float deviation = ringSectionAngle* UnityEngine.Random.Range(-1/6f, 1/6f);
                    endDir = (Mathf.Sin(Mathf.Deg2Rad * (ringAngles[selectedRoad] + deviation)) * Vector2.up + Mathf.Cos(Mathf.Deg2Rad * (ringAngles[selectedRoad] +deviation)) * Vector2.right).normalized;
                    endPoint = startPoint + 2 * endDir;
                    PlaceRoads(hasRoad, resolution * startPoint, resolution * endPoint);
                    break;
                case RoadStyle.INNER:
                    startPoint = roadCenter.position;
                    startDir = (Mathf.Sin(Mathf.Deg2Rad * ringAngles[selectedRoad]) * Vector2.up + Mathf.Cos(Mathf.Deg2Rad * ringAngles[selectedRoad]) * Vector2.right).normalized;
                    endPoint = roadCenter.position + ringDistances[selectedRoad] * startDir;
                    PlaceRoads(hasRoad, resolution * startPoint, resolution * endPoint);
                    break;
                case RoadStyle.NONE:
                default:
                    break;
            }
            ringAngles.RemoveAt(selectedRoad);
            ringDistances.RemoveAt(selectedRoad);
        }

        //Clean up silly roads
        waitText.text = "Making roads less wacky";
        if (Time.realtimeSinceStartup - focusTime >= yieldTimer)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            focusTime = Time.realtimeSinceStartup;
        }
        FixRoads(hasRoad);

        #endregion


        #region Sample the system for tile data
        MapData map = new MapData(resolution, resolution, maxDistrict+1);
        districtMembers = new List<Point>[maxDistrict+1];
        for(int i = 0; i < districtMembers.Length; i++)
        {
            districtMembers[i] = new List<Point>();
            map.districtColors[i] = Color.HSVToRGB(UnityEngine.Random.value, 1, UnityEngine.Random.value * 0.25f + 0.75f);
            //map.districtColors[i] = Color.HSVToRGB(i/((float)districtMembers.Length+1), 1, 1);
        }

        //Find closest primary and secondary point, use their values
        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {
                float minDist = 100; //3*Mathf.Max(cellStepX,cellStepY);
                float minUrban = 0;

                float secMinDist = 500;
                float secMinUrban = 0;

                int xCellCoord = Mathf.FloorToInt(x * stepSize * xCells);
                int yCellCoord = Mathf.FloorToInt(y * stepSize * yCells);

                int xSecCellCoord = Mathf.FloorToInt(x * stepSize * xSecondaryCells);
                int ySecCellCoord = Mathf.FloorToInt(y * stepSize * ySecondaryCells);

                int district = -1;

                for (int iy = -1; iy <= 1; iy++)
                {
                    for (int ix = -1; ix <= 1; ix++)
                    {
                        //Nearest primary point
                        try
                        {
                            Vector2 adjustedCoord = points[xCellCoord + ix, yCellCoord + iy].position;
                            float dist = Vector2.Distance(new Vector2(x * stepSize, y * stepSize), adjustedCoord);
                            if (dist < minDist)
                            {
                                minDist = dist;
                                minUrban = urbanizations.Read()[xCellCoord + ix, yCellCoord + iy];
                            }

                            /*
                            Point oldPoint = points[xCellCoord + ix, yCellCoord + iy];
                            Point newPoint = new Point(oldPoint.position, oldPoint.x, oldPoint.y);
                            newPoint.dist = Vector2.Distance(oldPoint.position, new Vector2(x*stepSize,y*stepSize));
                            adjacents.Add(newPoint);
                            */
                        }
                        catch
                        {
                            //Out of Bounds
                        }

                        //Nearest Secondary point
                        try
                        {

                            Vector2 adjustedSecCoord = secondaryPoints[xSecCellCoord + ix, ySecCellCoord + iy].position;
                            float dist = Vector2.Distance(new Vector2(x * stepSize, y * stepSize), adjustedSecCoord);
                            if (dist < secMinDist)
                            {
                                secMinDist = dist;
                                secMinUrban = secondaryUrbanizations.Read()[xSecCellCoord + ix, ySecCellCoord + iy];

                                district = mapDistricts[xSecCellCoord + ix, ySecCellCoord + iy];
                            }
                        }
                        catch
                        {
                            //Out of Bounds
                        }
                    }

                }
                float combinedUrban = Mathf.Clamp(minUrban * (1 + secMinUrban), 0, 1);

                //Add to map
                if(district < 0)
                {
                    map.buildings[x, y] = null;
                }
                else if (hasRoad[x,y])
                {
                    BuildingResidential building = ScriptableObject.CreateInstance<BuildingResidential>();
                    building.type = ResidentType.ROAD;
                    building.name = BuildingResidential.GenerateName(ResidentType.ROAD);
                    int population = UnityEngine.Random.Range(1 + Mathf.CeilToInt(combinedUrban*2), 3+Mathf.CeilToInt(combinedUrban*4));
                    for (int j = 0; j < population; j++)
                    {
                        Pop currentPop = new Pop();
                        currentPop.income = (IncomeLevel)UnityEngine.Random.Range(0, 3);
                        currentPop.preference = (FoodPreference)UnityEngine.Random.Range(0, 4);
                        currentPop.favoriteIngredient = (RecipeIngredient)UnityEngine.Random.Range(-1, Ingredient.OPTIONS_COUNT);
                        if (UnityEngine.Random.value > 0.5f)
                        {
                            currentPop.hatedIngredient = (RecipeIngredient)UnityEngine.Random.Range(0, Ingredient.OPTIONS_COUNT);
                        }
                        else
                        {
                            currentPop.hatedIngredient = RecipeIngredient.EMPTY;
                        }
                        building.residents.Add(currentPop);
                    }
                    map.buildings[x, y] = new BuildingData(building, district, combinedUrban);
                }
                else if (combinedUrban > urbanThreshold)
                {
                    BuildingResidential building = ScriptableObject.CreateInstance<BuildingResidential>();
                    building.type = ResidentType.URBAN;
                    building.name = BuildingResidential.GenerateName(ResidentType.URBAN);
                    int population = UnityEngine.Random.Range(2, 6);
                    for (int j = 0; j < population; j++)
                    {
                        Pop currentPop = new Pop();
                        currentPop.income = (IncomeLevel)UnityEngine.Random.Range(0, 3);
                        currentPop.preference = (FoodPreference)UnityEngine.Random.Range(0, 4);
                        currentPop.favoriteIngredient = (RecipeIngredient)UnityEngine.Random.Range(-1, Ingredient.OPTIONS_COUNT);
                        if (UnityEngine.Random.value > 0.5f)
                        {
                            currentPop.hatedIngredient = (RecipeIngredient)UnityEngine.Random.Range(0, Ingredient.OPTIONS_COUNT);
                        }
                        else
                        {
                            currentPop.hatedIngredient = RecipeIngredient.EMPTY;
                        }
                        building.residents.Add(currentPop);
                    }
                    map.buildings[x, y] = new BuildingData(building, district, combinedUrban);
                }
                else if (combinedUrban > suburbThreshold)
                {
                    BuildingResidential building = ScriptableObject.CreateInstance<BuildingResidential>();
                    building.type = ResidentType.SUBURB;
                    building.name = BuildingResidential.GenerateName(ResidentType.SUBURB);
                    int population = UnityEngine.Random.Range(1, 5);
                    for (int j = 0; j < population; j++)
                    {
                        Pop currentPop = new Pop();
                        currentPop.income = (IncomeLevel)UnityEngine.Random.Range(0, 3);
                        currentPop.preference = (FoodPreference)UnityEngine.Random.Range(0, 4);
                        currentPop.favoriteIngredient = (RecipeIngredient)UnityEngine.Random.Range(-1, Ingredient.OPTIONS_COUNT);
                        if (UnityEngine.Random.value > 0.5f)
                        {
                            currentPop.hatedIngredient = (RecipeIngredient)UnityEngine.Random.Range(0, Ingredient.OPTIONS_COUNT);
                        }
                        else
                        {
                            currentPop.hatedIngredient = RecipeIngredient.EMPTY;
                        }
                        building.residents.Add(currentPop);
                    }
                    map.buildings[x, y] = new BuildingData(building, district, combinedUrban);
                }
                else
                {
                    BuildingResidential building = ScriptableObject.CreateInstance<BuildingResidential>();
                    building.type = ResidentType.RURAL;
                    building.name = BuildingResidential.GenerateName(ResidentType.RURAL);
                    int population = UnityEngine.Random.Range(1, 4);
                    for (int j = 0; j < population; j++)
                    {
                        Pop currentPop = new Pop();
                        currentPop.income = (IncomeLevel)UnityEngine.Random.Range(0, 3);
                        currentPop.preference = (FoodPreference)UnityEngine.Random.Range(0, 4);
                        currentPop.favoriteIngredient = (RecipeIngredient)UnityEngine.Random.Range(-1, Ingredient.OPTIONS_COUNT);
                        if (UnityEngine.Random.value > 0.5f)
                        {
                            currentPop.hatedIngredient = (RecipeIngredient)UnityEngine.Random.Range(0, Ingredient.OPTIONS_COUNT);
                        }
                        else
                        {
                            currentPop.hatedIngredient = RecipeIngredient.EMPTY;
                        }
                        building.residents.Add(currentPop);
                    }
                    map.buildings[x, y] = new BuildingData(building, district, combinedUrban);
                }
                //Keep track of all tiles in a given district
                if(district >= 0)
                {
                    districtMembers[district].Add(new Point(Vector2.zero, x, y));
                }

                waitText.text = "Chopping things into neat little squares: " + (y * resolution + x + 1) + "/" + (resolution * resolution);
                if (Time.realtimeSinceStartup - focusTime >= yieldTimer)
                {
                    yield return new WaitForSeconds(Time.deltaTime);
                    focusTime = Time.realtimeSinceStartup;
                }
            }
        }
        #endregion

        #region Place empty lots in districts
        for (int district = 0; district <= maxDistrict; district++)
        {
            int numLots = UnityEngine.Random.Range(1, 4);
            if (districtMembers[district].Count > 0)
            {
                for (int lot = 0; lot < numLots; lot++)
                {
                    int tries = 0;
                    while (tries < 10)
                    {
                        waitText.text = "Creating opportunities: " + (district + 1) + "/" + maxDistrict;
                        if (Time.realtimeSinceStartup - focusTime >= yieldTimer)
                        {
                            yield return new WaitForSeconds(Time.deltaTime);
                            focusTime = Time.realtimeSinceStartup;
                        }


                        int selection = UnityEngine.Random.Range(0, districtMembers[district].Count);
                        Point location = districtMembers[district][selection];

                        BuildingData chosenBuilding = map.buildings[location.x, location.y];

                        //Try again if the selected building is an empty lot or a road;
                        if (chosenBuilding.building.GetType() == typeof(BuildingVacant))
                        {
                            tries++;
                            continue;
                        }
                        if (chosenBuilding.building.GetType() == typeof(BuildingResidential))
                        {
                            if (((BuildingResidential)chosenBuilding.building).type == ResidentType.ROAD)
                            {
                                tries++;
                                continue;
                            }
                        }

                        BuildingVacant building = ScriptableObject.CreateInstance<BuildingVacant>();

                        building.name = "Vacant Lot";

                        float urb = map.buildings[location.x, location.y].urbanization;
                        building.price = 5 * (Mathf.RoundToInt(200 * (1 + urb * 2)) / 5);

                        map.buildings[location.x, location.y] = new BuildingData(building, district, urb);
                        break;
                    }
                }

            }

        }
        #endregion

        mapData = map;

        #region Place Tiles
        mapTiles = new GameObject[mapData.columns, mapData.rows];
        allTiles = new List<GameObject>();

        UnityEngine.Random.InitState(seed);

        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {
                BuildingData tileData = mapData.buildings[x, y];
                GameObject tile;
                WorldTile tileScript;
                Vector3 spawnPos = new Vector3(x - (resolution / 2), 0, y - (resolution / 2));

                if (tileData == null)
                {
                    //Do nothing
                    //Instantiate(debugNullFab, spawnPos, Quaternion.identity);
                }
                else if (tileData.building.GetType() == typeof(BuildingResidential))
                {
                    BuildingResidential building = (BuildingResidential)tileData.building;
                    switch (building.type)
                    {
                        case ResidentType.URBAN:
                            tile = Instantiate(urbanFabs[UnityEngine.Random.Range(0,urbanFabs.Length)], spawnPos, Quaternion.identity);
                            break;
                        case ResidentType.SUBURB:
                            tile = Instantiate(suburbFabs[UnityEngine.Random.Range(0, suburbFabs.Length)], spawnPos, Quaternion.identity);
                            break;
                        case ResidentType.RURAL:
                            tile = Instantiate(ruralFabs[UnityEngine.Random.Range(0, ruralFabs.Length)], spawnPos, Quaternion.identity);
                            break;
                        case ResidentType.ROAD:
                            Quaternion roadDir;
                            tile = Instantiate(OrientRoad(hasRoad,x,y,out roadDir), spawnPos, Quaternion.identity);
                            tile.GetComponent<WorldTile>().tileGeometry.localRotation = roadDir;
                            break;
                        default:
                            tile = Instantiate(ruralFabs[0], spawnPos, Quaternion.identity);
                            break;
                    }
                    tileScript = tile.GetComponent<WorldTile>();

                    building.canvas = mainCanvas;
                    building.tile = tileScript;
                    building.world = this;
                    tileScript.building = building;
                    tileScript.urbanization = mapData.buildings[x, y].urbanization;
                    tileScript.district = mapData.buildings[x, y].district;
                    tileScript.x = x;
                    tileScript.y = y;

                    mapTiles[x, y] = tile;
                    allTiles.Add(tile);

                    tile.GetComponentInChildren<DistrictDisplay>().SetBorders(GetSurroundings(x, y), mapData.districtColors[mapData.buildings[x, y].district]);
                }
                else if (tileData.building.GetType() == typeof(BuildingVacant))
                {
                    BuildingVacant building = (BuildingVacant)tileData.building;
                    tile = Instantiate(lotFabs[UnityEngine.Random.Range(0, lotFabs.Length)], spawnPos, Quaternion.identity);
                    tileScript = tile.GetComponent<WorldTile>();

                    building.canvas = mainCanvas;
                    building.tile = tileScript;
                    building.world = this;
                    tileScript.building = building;
                    tileScript.urbanization = mapData.buildings[x, y].urbanization;
                    
                    tileScript.district = mapData.buildings[x, y].district;
                    tileScript.x = x;
                    tileScript.y = y;

                    mapTiles[x, y] = tile;
                    allTiles.Add(tile);

                    tile.GetComponentInChildren<DistrictDisplay>().SetBorders(GetSurroundings(x, y), mapData.districtColors[mapData.buildings[x, y].district]);
                }

                waitText.text = "Making things look pretty: " + (y * resolution + x + 1) + "/" + (resolution * resolution);
                if (Time.realtimeSinceStartup - focusTime >= yieldTimer)
                {
                    yield return new WaitForSeconds(Time.deltaTime);
                    focusTime = Time.realtimeSinceStartup;
                }
            }
        }
        #endregion

        waitScreen.SetActive(false);
    }

    void PlaceRoads(bool[,] hasRoad, Vector2 start, Vector2 end)
    {
        int x, y, xEnd, yEnd;
        Vector2 dir = (end - start).normalized;
        x = Mathf.FloorToInt(start.x);
        y = Mathf.FloorToInt(start.y);
        xEnd = Mathf.FloorToInt(end.x);
        yEnd = Mathf.FloorToInt(end.y);
        int steps = 0;

        Vector2 currentPoint = start;
        do
        {
            try
            {
                hasRoad[x, y] = true;
            }
            catch (Exception exc)
            {
                //Off the grid
            }
            Vector2 stepPos = currentPoint + dir * 2;
            Vector2 bound = new Vector2(dir.x < 0 ? x : x + 1, dir.y < 0 ? y : y + 1);
            Vector2 exitTime = new Vector2((bound.x - currentPoint.x) / dir.x, (bound.y - currentPoint.y) / dir.y);
            float minExit = Mathf.Min(exitTime.x, exitTime.y);
            if (exitTime.x < exitTime.y)
            {
                x += (int)Mathf.Sign(dir.x);
            }
            else
            {
                y += (int)Mathf.Sign(dir.y);
            }
            currentPoint += minExit * dir;
            steps++;
        } while (!(x == xEnd && y == yEnd) && steps < 3 * resolution);
    }

    void FixRoads(bool[,] hasRoad)
    {
        //Find all of the problem areas
        List<Point> problemTLCorners = new List<Point>();
        for(int y = 0; y < resolution-1; y++)
        {
            for (int x = 0; x < resolution - 1; x++)
            {
                if(hasRoad[x,y] && hasRoad[x+1,y] && hasRoad[x,y+1] && hasRoad[x + 1, y + 1])
                {
                    problemTLCorners.Add(new Point(Vector2.zero, x, y));
                }
            }
        }

        //Fix each problem area
        foreach(Point corner in problemTLCorners)
        {
            if(!(hasRoad[corner.x, corner.y] && hasRoad[corner.x + 1, corner.y] && hasRoad[corner.x, corner.y + 1] && hasRoad[corner.x + 1, corner.y + 1]))
            {
                //Do nothing if the problem has already been fixed
                continue;
            }

            //Initialize the nodes
            RoadNode[,] nodes = new RoadNode[4, 4];
            List<RoadNode> outerNodes = new List<RoadNode>();
            List<RoadNode> innerNodes = new List<RoadNode>();
            for(int iy = 0; iy < 4; iy++)
            {
                for(int ix = 0; ix < 4; ix++)
                {
                    if((ix == 0 && iy == 0) || (ix == 4 && iy == 0) || (ix == 0 && iy == 4) || (ix == 4 && iy == 4))
                    {
                        //Don't care about the corners
                        continue;
                    }
                    try
                    {
                        if(hasRoad[corner.x + ix -1,corner.y + iy - 1])
                        {
                            nodes[ix, iy] = new RoadNode(corner.x + ix - 1, corner.y + iy - 1);
                            if(ix == 0 || ix == 3 || iy == 0 || iy == 3)
                            {
                                outerNodes.Add(nodes[ix, iy]);
                            }
                            else
                            {
                                innerNodes.Add(nodes[ix, iy]);
                            }
                        }
                    }
                    catch
                    {
                        //Out of bounds, do nothing
                    }
                }
            }
            //Make the links
            for(int cy = 0; cy < 4; cy++)
            {
                for (int cx = 0; cx < 4; cx++)
                {
                    RoadNode current = nodes[cx, cy];
                    //Right
                    try
                    {
                        if (nodes[cx + 1, cy] != null)
                        {
                            if (!current.connections.Contains(nodes[cx + 1, cy]))
                            {
                                current.connections.Add(nodes[cx + 1, cy]);
                            }
                            if (!nodes[cx + 1, cy].connections.Contains(current))
                            {
                                nodes[cx + 1, cy].connections.Add(current);
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        //Do nothing
                    }
                    
                    //Top
                    try
                    {
                        if (nodes[cx, cy - 1] != null)
                        {
                            if (!current.connections.Contains(nodes[cx, cy - 1]))
                            {
                                current.connections.Add(nodes[cx, cy - 1]);
                            }
                            if (!nodes[cx, cy - 1].connections.Contains(current))
                            {
                                nodes[cx, cy - 1].connections.Add(current);
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        //Do nothing
                    }
                    
                    //Left
                    try
                    {
                        if (nodes[cx - 1, cy] != null)
                        {
                            if (!current.connections.Contains(nodes[cx - 1, cy]))
                            {
                                current.connections.Add(nodes[cx - 1, cy]);
                            }
                            if (!nodes[cx - 1, cy].connections.Contains(current))
                            {
                                nodes[cx - 1, cy].connections.Add(current);
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        //Do nothing
                    }
                    
                    //Bottom
                    try
                    {
                        if (nodes[cx, cy + 1] != null)
                        {
                            if (!current.connections.Contains(nodes[cx, cy + 1]))
                            {
                                current.connections.Add(nodes[cx, cy + 1]);
                            }
                            if (!nodes[cx, cy + 1].connections.Contains(current))
                            {
                                nodes[cx, cy + 1].connections.Add(current);
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        //Do nothing
                    }
                    
                }
            }
            if(outerNodes.Count == 0)
            {
                //This probably should never happen
                continue;
            }
            //Try removing inner nodes
            List<RoadNode> removableNodes = new List<RoadNode>();
            foreach(RoadNode node in innerNodes)
            {
                node.disabled = true;
                List<RoadNode> connectedNodes = ConnectedRoads(outerNodes[0]);
                node.disabled = false;
                bool safeToDelete = true;
                foreach (RoadNode outer in outerNodes)
                {
                    if (!connectedNodes.Contains(outer))
                    {
                        safeToDelete = false;
                    }
                }
                if (safeToDelete)
                {
                    removableNodes.Add(node);
                }
            }
            //Delete the node with the least connections
            if(removableNodes.Count == 0)
            {
                //Can't remove any for some reason
                continue;
            }
            RoadNode toRemove = removableNodes[0];
            int minConnections = removableNodes[0].connections.Count;
            foreach(RoadNode node in removableNodes)
            {
                if(node.connections.Count < minConnections)
                {
                    minConnections = node.connections.Count;
                    toRemove = node;
                }
            }
            //remove the node
            hasRoad[toRemove.x, toRemove.y] = false;
        }
    }

    private List<RoadNode> ConnectedRoads(RoadNode start)
    {
        List<RoadNode> discovered = new List<RoadNode>();
        Queue<RoadNode> queue = new Queue<RoadNode>();
        discovered.Add(start);
        queue.Enqueue(start);
        while(queue.Count != 0)
        {
            RoadNode current = queue.Dequeue();
            foreach(RoadNode connection in current.connections)
            {
                if (!connection.disabled && !discovered.Contains(connection))
                {
                    discovered.Add(connection);
                    queue.Enqueue(connection);
                }
            }
        }
        return discovered;
    }

    private GameObject OrientRoad(bool[,] hasRoad, int x, int y, out Quaternion quat)
    {
        int numConnections = 0;
        NeighborRoadState top, right, bottom, left;
        top = right = bottom = left = NeighborRoadState.NULL;
        try
        {
            if (hasRoad[x + 1, y])
            {
                numConnections++;
                right = NeighborRoadState.YES;
            }
            else
            {
                right = NeighborRoadState.NO;
            }
        }
        catch (Exception exc)
        {
            //out of bounds
            right = NeighborRoadState.NULL;
        }
        try
        {
            if (hasRoad[x, y + 1])
            {
                numConnections++;
                top = NeighborRoadState.YES;
            }
            else
            {
                top = NeighborRoadState.NO;
            }
        }
        catch (Exception exc)
        {
            //out of bounds
            top = NeighborRoadState.NULL;
        }
        try
        {
            if (hasRoad[x - 1, y])
            {
                numConnections++;
                left = NeighborRoadState.YES;
            }
            else
            {
                left = NeighborRoadState.NO;
            }
        }
        catch (Exception exc)
        {
            //out of bounds
            left = NeighborRoadState.NULL;
        }
        try
        {
            if (hasRoad[x, y - 1])
            {
                numConnections++;
                bottom = NeighborRoadState.YES;
            }
            else
            {
                bottom = NeighborRoadState.NO;
            }
        }
        catch (Exception exc)
        {
            //out of bounds
            bottom = NeighborRoadState.NULL;
        }

        if (numConnections == 4)
        {
            quat = Quaternion.identity;
            return roadQuadFab;
        }
        else if(numConnections == 3)
        {
            if (right != NeighborRoadState.YES)
            {
                quat = Quaternion.Euler(0 * Vector3.up);
            }
            else if (top != NeighborRoadState.YES)
            {
                quat = Quaternion.Euler(270 * Vector3.up);
            }
            else if (left != NeighborRoadState.YES)
            {
                quat = Quaternion.Euler(180 * Vector3.up);
            }
            else
            {
                quat = Quaternion.Euler(90 * Vector3.up);
            }
            return roadTriFab;
        }
        else if(numConnections == 2)
        {
            if(right == NeighborRoadState.YES && left == NeighborRoadState.YES)
            {
                quat = Quaternion.Euler(90 * Vector3.up);
                return roadStraightFab;
            }
            else if(top == NeighborRoadState.YES && bottom == NeighborRoadState.YES)
            {
                quat = Quaternion.identity;
                return roadStraightFab;
            }

            if(right == NeighborRoadState.YES && top == NeighborRoadState.YES)
            {
                quat = Quaternion.Euler(180 * Vector3.up);
                return roadTurnFab;
            }
            else if (top == NeighborRoadState.YES && left == NeighborRoadState.YES)
            {
                quat = Quaternion.Euler(90 * Vector3.up);
                return roadTurnFab;
            }
            else if (left == NeighborRoadState.YES && bottom == NeighborRoadState.YES)
            {
                quat = Quaternion.Euler(0 * Vector3.up);
                return roadTurnFab;
            }
            else
            {
                quat = Quaternion.Euler(270 * Vector3.up);
                return roadTurnFab;
            }

        }
        else
        {
            if (right == NeighborRoadState.YES || left == NeighborRoadState.YES)
            {
                quat = Quaternion.Euler(90 * Vector3.up);
                return roadStraightFab;
            }
            else
            {
                quat = Quaternion.identity;
                return roadStraightFab;
            }
        }
    }

    private void UrbanizeAverage(int y, int x)
    {
        float total = 0;
        float div = 0;
        for (int iy = -1; iy <= 1; iy++)
        {
            for (int ix = -1; ix <= 1; ix++)
            {
                if (!(ix == 0 && iy == 0))
                {
                    try
                    {
                        float mult = cellStepX / Vector2.Distance(points[x + ix, y + iy].position, points[x, y].position);
                        total += mult * urbanizations.Read()[x + ix, y + iy];
                        div += mult;
                    }
                    catch
                    {
                        //Out of Bounds
                    }
                }
            }
        }
        urbanizations.Write()[x, y] = total / div;
    }

    private void UrbanizeBleed(int y, int x)
    {
        float total = 0;
        float div = 0;
        for (int iy = -1; iy <= 1; iy++)
        {
            for (int ix = -1; ix <= 1; ix++)
            {
                if (!(ix == 0 && iy == 0))
                {
                    try
                    {
                        float mult = cellStepX / Vector2.Distance(points[x + ix, y + iy].position, points[x, y].position);
                        total += mult * urbanizations.Read()[x + ix, y + iy];
                        div += mult;
                    }
                    catch
                    {
                        //Out of Bounds
                    }
                }
            }
        }
        urbanizations.Write()[x, y] = total / div;
    }

    private bool[,] GetSurroundings(int x, int y)
    {
        if (mapData.buildings[x, y].district < 0)
        {
            return null;
        }

        int thisDistrict = mapData.buildings[x, y].district;
        bool[,] sameDistrict = new bool[3, 3];
        for(int iy = -1; iy < 2; iy++)
        {
            for(int ix = -1; ix < 2; ix++)
            {
                try
                {
                    int other = mapData.buildings[x + ix, y + iy].district;
                    if(other < 0)
                    {
                        sameDistrict[ix + 1, iy + 1] = false;
                    }
                    else
                    {
                        sameDistrict[ix+1,iy+1] = other == thisDistrict;
                    }
                }
                catch
                {
                    //Out of bounds, put a wall
                    sameDistrict[ix + 1, iy + 1] = false;
                }
            }
        }
        return sameDistrict;
    }

    IEnumerator WaitForInput(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
        {
            yield return null;
        }
    }

    private class UrbanBuffer
    {
        float[,] read;
        float[,] write;
        float[][,] buffers;

        public UrbanBuffer(int xCells, int yCells)
        {
            buffers = new float[2][,];
            buffers[0] = new float[xCells, yCells];
            buffers[1] = new float[xCells, yCells];
            read = buffers[0];
            write = buffers[1];
        }

        public float[,] Read() { return read; }

        public float[,] Write() { return write; }

        public void Swap()
        {
            float[,] temp = read;
            read = write;
            write = temp;
        }
    }

    private class RoadNode
    {
        public List<RoadNode> connections;
        public bool disabled;
        public int x, y;

        public RoadNode(int x, int y)
        {
            this.x = x;
            this.y = y;
            connections = new List<RoadNode>();
            disabled = false;
        }
    }
}

struct Point : System.IComparable<Point>
{
    public Vector2 position;
    public float dist;
    public int x;
    public int y;

    public Point(Vector2 position, int x, int y)
    {
        this.position = position;
        this.x = x;
        this.y = y;
        dist = Vector2.Distance(position, new Vector2(0.5f, 0.5f));
    }

    public int CompareTo(Point other)
    {
        if(dist < other.dist)
        {
            return -1;
        }
        else if(dist > other.dist)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}

[Serializable]
public struct MapData
{
    public BuildingData[,] buildings;
    public Color[] districtColors;
    public int rows, columns;

    public MapData(int x, int y, int districtCount)
    {
        buildings = new BuildingData[x,y];
        this.rows = y;
        this.columns = x;
        districtColors = new Color[districtCount];
    }
}

[Serializable]
public class BuildingData
{
    public Building building;
    public int district;
    public float urbanization;

    public BuildingData(Building building, int district, float urbanization)
    {
        this.building = building;
        this.district = district;
        this.urbanization = urbanization;
    }
}


