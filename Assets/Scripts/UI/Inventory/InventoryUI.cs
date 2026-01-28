using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;

    [Header("Setup")]
    public GameObject iconPrefab;   
    public Transform container;     

    private List<GameObject> spawnedIcons = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateKeyUI();
    }

   public void UpdateKeyUI()
{
    // 1. Clear existing icons
    foreach (GameObject icon in spawnedIcons)
    {
        Destroy(icon);
    }
    spawnedIcons.Clear();

    // 2. Loop through each unique item type in the inventory
    foreach (InventoryItem item in InventorySystem.current.inventory)
    {
        // 3. NEW: Loop based on the stack size of that item
        for (int i = 0; i < item.stackSize; i++)
        {
            GameObject newIcon = Instantiate(iconPrefab, container);
            
            Image img = newIcon.GetComponent<Image>();
            if (img != null && item.data.icon != null)
            {
                img.sprite = item.data.icon; // Uses the icon from InventoryItemData
            }

            spawnedIcons.Add(newIcon);
        }
    }
}
}