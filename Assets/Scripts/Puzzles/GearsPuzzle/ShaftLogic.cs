using UnityEngine;

public class ShaftLogic : MonoBehaviour
{
    private Interactable _interactableScript;
    private Outline _outlineScript;
    private int shaftNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _interactableScript = GetComponent<Interactable>();
        _outlineScript = GetComponent<Outline>();
        shaftNumber = int.Parse(gameObject.name);
        //Debug.Log("hi?? " + GearManager.Instance.currentOrder.Length);
    }

    // Update is called once per frame
    void Update()
    {

        if (GearManager.Instance.currentOrder[shaftNumber] == 0)
        {
            _interactableScript.enabled = true;
        }
    }

    public void placeGear()
    {
        if (GearManager.Instance.selectedGear != null)
        {
            GearManager.Instance.selectedGear.transform.position = transform.position;
            string gearName = GearManager.Instance.selectedGear.name;
            int gearNumber = int.Parse(gearName);
            GearManager.Instance.currentOrder[shaftNumber] = gearNumber;

            GearManager.Instance.selectedGear = null;
            _interactableScript.enabled = false;
            _outlineScript.enabled = false;

        }
    }
}
