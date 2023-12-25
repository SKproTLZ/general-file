using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Puzzle Object", menuName = "Inventory System/Item/Puzzle")]
public class PuzzleObject : itemobject
{
    public void Awake()
    {
        type = Itemtype.For_Puzzle;
    }
}
