using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public InventoryItemData referenceItem;

    public void OnHandleItemPickup()
    {
        InventorySystem.current.Add(referenceItem);
        Destroy(gameObject);
    }


}
