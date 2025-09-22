using UnityEngine;

public class Handle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckAnswer()
    {
        for (int i = 0; i < GearManager.Instance.currentOrder.Length; i++)
        {
            if (GearManager.Instance.currentOrder[i] != GearManager.Instance.correctOrder[i])
            {
                Debug.Log("Incorrect");
                return;
            }
        }

        Debug.Log("YOU DID IT");
    }
}
