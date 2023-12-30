using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField]  GameObject InventoryGameObject;
    [SerializeField]  KeyCode[Tab]  toggleInventoryKeys;

    void Update()
    {
        for (int i = 0; i < toggleInventoryKeys.Length; i++)
        {
            if (Input.GetKeyDown(toggleInventoryKeys[i]))
            {
                inventoryGameObject.SetActive(!InventoryGameObject.activeSelf);
                break;
            }
        }
    }
}
