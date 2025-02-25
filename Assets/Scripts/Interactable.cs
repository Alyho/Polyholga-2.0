using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Outline))]
public class Interactable : MonoBehaviour
{
    private Outline _outlineScript;

    [Tooltip("The maximum distance at which this is interactable")]
    public float maxDistance = 15f;

    public UnityEvent onClick;

    [FormerlySerializedAs("interactable")] [Tooltip("Use this to toggle interactibility")]
    public bool isInteractible = true;

    private void Awake()
    {
        _outlineScript = GetComponent<Outline>();
        _outlineScript.enabled = false;
    }

    public void Update()
    {
        bool currentlyHighlighted = PointAtInteractable.CurrentlyHighlightedObject == gameObject;
        
        _outlineScript.enabled = isInteractible && currentlyHighlighted;
        if (currentlyHighlighted && Input.GetMouseButtonDown(0))
            OnClick();
    }

    public void SetInteractable(bool interactable)
    {
        isInteractible = interactable;
    }

    public virtual void OnClick()
    {
        if (!isInteractible) return;

        onClick.Invoke();
    }
}
