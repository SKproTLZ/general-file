using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Buff Object", menuName = "Inventory System/Item/Buff")]
public class BuffObject : itemobject
{
    public float atkbonus;
    public float defbonus;
    public void Awake()
    {
        type = Itemtype.Buff;
    }
}
