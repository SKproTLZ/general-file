using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject MainInventoryGroup;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }
    public void ToggleInventory()
    {
        if (MainInventoryGroup != null)
        {
            bool isActive = MainInventoryGroup.activeSelf;
            MainInventoryGroup.SetActive(!isActive);
        }
    }
}
