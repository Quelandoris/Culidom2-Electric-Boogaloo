using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTile : MonoBehaviour {

    protected float elapsed = 0f;
    protected const float maxHeight = 0.1f;
    bool selected = false;
    bool isClicked = false;
    public Transform model;
    public Transform tileGeometry;
    public Building building;
    public GameObject clickUI;
    [Tooltip("Used for Restaurant's UI if owned by a different player.")]
    public GameObject secondaryClickUI;
    GameObject textBox;

    public float urbanization;
    public int district;

    public int x;
    public int y;

    public bool[,] debug;

    CameraMovement cameraScript;
    string[] tileName = new string[2];

    public GameObject hoverTextFab;

    //sound stuff
    public AudioSource ruralAmbience, suburbanAmbience, urbanAmbience;
    public AudioClip sfx_ambience_rural, sfx_ambience_suburban, sfx_ambience_urban;
    public GameObject AudioManager;

    void Awake()
    {
        cameraScript = FindObjectOfType<CameraMovement>();
    }

    private void OnEnable()
    {
        AudioManager = FindObjectOfType<AudioManager>().gameObject;
    }

    public void Start()
    {
        tileName = gameObject.name.Split(' ');
    }

    void Update()
    {
        Animate();
    }

    void Animate()
    {
        float speed = 1.25f;
        if (selected || isClicked)
        {
            elapsed += speed * Time.deltaTime;

        }
        else
        {
            elapsed -= speed * Time.deltaTime;
        }
        elapsed = Mathf.Clamp(elapsed, 0, 1);
        float frac = (1-Mathf.Cos(Mathf.PI*elapsed))/ 2;
        model.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(0, maxHeight, 0), frac);
    }

	public void Select()
    {
        if (!selected)
        {
            selected = true;
            try
            {
                Destroy(textBox); //Attempt to destroy the hover text in case there already is one
            }
            catch { }
            textBox = Instantiate(hoverTextFab, model) as GameObject;
            textBox.transform.localPosition = 1f * Vector3.up;
            TextMesh hoverMesh = textBox.GetComponentInChildren<TextMesh>();
            hoverMesh.text= building.name;
            Transform bg = textBox.transform.Find("Background"); //I think "bg" is causing the null reference : Antonio
            bg.localScale = new Vector3(0.015f*building.name.Length + 0.01f, bg.localScale.y, bg.localScale.z); // Maybe building.name.length. Cause that don't make no sense

            
        }
    }

    public void Deselect()
    {
        if (selected)
        {
            selected = false;
            Destroy(textBox);
            
        }
    }

    public void Click()
    {
        isClicked = true;
        building.Click();

        if (tileName[0] == "Rural")
        {
            // put rural tile sound here
            AudioManager.GetComponent<AudioManager>().PlayAmbienceRural();
        }
        else if (tileName[0] == "Urban")
        {
            // put urban tile sound here
            AudioManager.GetComponent<AudioManager>().PlayAmbienceUrban();
        }
        else if (tileName[0] == "Suburb")
        {
            // put suburb tile sound here
            AudioManager.GetComponent<AudioManager>().PlayAmbienceSuburban();

        }
        else if(tileName[0] == "Empty")
        {
            // put vacant tile sound here
        }
        else {
            Debug.Log("We aint got no sound. Dylan you fired");
        }
    }

    public void UnClick()
    {
        isClicked = false;
        building.UnClick();
        turnOffAmbience();

    }

    void turnOffAmbience()
    {
        try
        {
            if (ruralAmbience.isPlaying)
            {
                ruralAmbience.Stop();
            }

            if (suburbanAmbience.isPlaying)
            {
                suburbanAmbience.Stop();
            }

            if (urbanAmbience.isPlaying)
            {
                urbanAmbience.Stop();
            }
        }
        catch { }
    }

    public Building GetBuilding() {
        return building;
    }
}
