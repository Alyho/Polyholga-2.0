using UnityEngine;
using System;
using System.Collections.Generic;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory { get; private set; }
    public static InventorySystem current;

    private void Awake()
    {
        if (current == null)
        {
            inventory = new List<InventoryItem>();
            m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
            current = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }   
        
    }

    public void Add(InventoryItemData referenceData)
    {
        
        // FIXME need to make sure we can't add multiple of the same item if we don't intend to 
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }
    }

    public void Remove(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();
            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }

        if (InventoryUI.instance != null)
        {
            InventoryUI.instance.UpdateKeyUI();
        }

    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }
   
}
