using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Outline))]
public class Interactable : MonoBehaviour
{
    private Outline _outlineScript;
    private float mouseDownTime;
    private float holdThreshold = 0.5f;
    private bool isHolding;

    [Tooltip("The maximum distance at which this is interactable")]
    public float maxDistance = 15f;

    public UnityEvent onClick;
    public UnityEvent onHold;
    public UnityEvent onHoldRelease;

    [FormerlySerializedAs("interactable")]
    [Tooltip("Use this to toggle interactibility")]
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
        {
            mouseDownTime = Time.time;
            isHolding = false;
        }

        if (currentlyHighlighted && Input.GetMouseButton(0))
        {
            if (!isHolding && Time.time - mouseDownTime >= holdThreshold)
            {
                isHolding = true;
                OnHold();
            }
        }
        if (currentlyHighlighted && Input.GetMouseButtonUp(0))
        {
            if (!isHolding)
            {
                OnClick();
            }
            else
            {
                OnHoldRelease();
            }
        }

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

    private void OnHold()
    {
        if (!isInteractible) return;
        Debug.Log("Mouse Held");

        onHold.Invoke();
    }

    private void OnHoldRelease()
    {
        if (!isInteractible) return;
        Debug.Log("Hold Released");
        onHoldRelease.Invoke();
    }
}
