using UnityEngine;

/// <summary>
/// Lets us call functions on objects with the Interactable script attached when we look at/away from them
/// </summary>
public class PointAtInteractable : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;

    public float raycastDistance = 30f;
    public LayerMask hitLayers;

    public static GameObject CurrentlyHighlightedObject;

    void Update()
    {
        Vector3 rayOrigin = mainCamera.transform.position;
        Vector3 rayDirection = mainCamera.transform.forward;

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, raycastDistance, layerMask: hitLayers))
        {
            // Log the name of the object hit
            if (hit.collider.GetComponent<Interactable>())
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                float distToInteractable = Vector3.Distance(rayOrigin, interactable.transform.position);
                if (distToInteractable > interactable.maxDistance)
                {
                    CurrentlyHighlightedObject = null;
                    return;
                }

                if (!interactable.isInteractible)
                {
                    CurrentlyHighlightedObject = null;
                    return;
                }
                
                CurrentlyHighlightedObject = interactable.gameObject;
            }
            else
            {
                CurrentlyHighlightedObject = null;
            }
        }
    }
}
