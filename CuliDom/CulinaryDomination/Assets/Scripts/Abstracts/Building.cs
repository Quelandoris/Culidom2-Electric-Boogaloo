using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : ScriptableObject {

    public string name;
    public WorldTile tile;
    public RectTransform canvas;

    public TextureGenerator world;

    public float urbanization;

    public abstract void Click();

    public abstract void UnClick();
}
