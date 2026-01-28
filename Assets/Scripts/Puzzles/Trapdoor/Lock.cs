using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Lock : MonoBehaviour
{
    [Header("Requirements")]
    public InventoryItemData requiredKey; 
    public AnimatePositionCinematic door1;
    public AnimatePositionCinematic door2; 

    public UnityEvent Unlock1;
    public UnityEvent Unlock2; 

    private int keyCount = 0; 

    public void CheckForKey(bool one)
    {
        InventoryItem item = InventorySystem.current.Get(requiredKey);

        if (item != null)
        {
            keyCount ++; 

            if (one == true){
                Debug.Log("Call Unlock1"); 
                OnUnlock1();
            } else {
                Debug.Log("Call Unlock2"); 
                OnUnlock2(); 
            }
            
            UnlockDoor();
        }
        else
        {
            Debug.Log("It's locked. You need the " + requiredKey.displayName);
        }
    }

    private void UnlockDoor()
    {
        InventorySystem.current.Remove(requiredKey);
        if (keyCount == 2){
            door1.Reveal(); 
            door2.Reveal(); 
        }

    }

    public virtual void OnUnlock1()
    {
        Unlock1.Invoke();
    }

    public virtual void OnUnlock2(){
        Unlock2.Invoke(); 
    }
}