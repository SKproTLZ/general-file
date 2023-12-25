using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Itemtype
{
    normal,
    For_Puzzle,
    Buff,
    Default
}
public abstract class itemobject : ScriptableObject
{
    public GameObject prefab;
    public Itemtype type;
    [TextArea(15, 20)] //make it so not 1 line description
    public string description;
}
