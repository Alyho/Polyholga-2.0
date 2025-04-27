using UnityEngine;
using UnityEngine.Events;
public class TriggerEvent : MonoBehaviour
{
    public bool triggerEnterOnce = false;
    public bool triggerExitOnce = false;

    private bool _enterTriggered = false;
    private bool _exitTriggered = false;

    public UnityEvent onEnter;
    public UnityEvent onExit;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (triggerEnterOnce && _enterTriggered) return;
            
            onEnter?.Invoke();

            _enterTriggered = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (triggerExitOnce && _exitTriggered) return;
            
            onExit?.Invoke();

            _exitTriggered = true;
        }
    }
}
