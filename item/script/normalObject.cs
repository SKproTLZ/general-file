using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* file name =>  Name of new file that we create 
menuName => the place where we can select and create this object type*/
[CreateAssetMenu(fileName = "New normal Object", menuName = "Inventory System/Item/normal")]
public class normalObject : itemobject
{
    public void Awake()
    {
        type = Itemtype.normal; //set itme type
    }
}
