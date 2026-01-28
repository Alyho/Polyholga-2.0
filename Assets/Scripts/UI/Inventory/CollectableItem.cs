using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public InventoryItemData referenceItem;

    public void OnHandleItemPickup()
    {
        InventorySystem.current.Add(referenceItem);
        if (InventoryUI.instance != null)
        {
            InventoryUI.instance.UpdateKeyUI();
        }
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }


}
