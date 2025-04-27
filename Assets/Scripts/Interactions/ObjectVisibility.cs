using UnityEngine;

public class ObjectVisibility : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    
    public void ShowObject()
    {
        obj.SetActive(true);
    }

    public void HideObject()
    {
        obj.SetActive(false);
    }

    public void ToggleObject()
    {
        obj.SetActive(!obj.activeSelf);
    }
}
