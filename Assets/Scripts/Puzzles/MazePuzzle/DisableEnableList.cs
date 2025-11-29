using UnityEngine;

public class DisableEnableList : MonoBehaviour
{
    public GameObject[] toDisable;
    public GameObject[] toEnable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisableEnable()
    {
        foreach (GameObject obj in toDisable)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        foreach (GameObject obj in toEnable)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }


}
