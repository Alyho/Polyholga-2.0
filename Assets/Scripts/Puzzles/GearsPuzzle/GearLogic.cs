using UnityEngine;

public class GearLogic : MonoBehaviour
{
    private Interactable _interactableScript;
    private Vector3 startPos;
    private int gearNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Handle handle;

    void Start()
    {
        _interactableScript = GetComponent<Interactable>();
        startPos = transform.position;
        gearNumber = int.Parse(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (GearManager.Instance.selectedGear != gameObject)
        {
            _interactableScript.enabled = true;
        }
    }

    public void selectGear()
    {
        for (int g = 0; g < GearManager.Instance.currentOrder.Length; g++)
        {


            if (GearManager.Instance.currentOrder[g] == gearNumber)
            {
                transform.position = startPos;
                GearManager.Instance.currentOrder[g] = 0;
                return;
            }
        }

        GearManager.Instance.selectedGear = gameObject;
        _interactableScript.enabled = false;
    }

    private void OnEnable() => handle.onSolve.AddListener(OnSolve);

    private void OnDisable() => handle.onSolve.RemoveListener(OnSolve);

    private void OnSolve()
    {
        GetComponent<Interactable>().SetInteractable(false);
    }
}
