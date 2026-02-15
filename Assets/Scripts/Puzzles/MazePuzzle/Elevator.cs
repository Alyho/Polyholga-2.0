using UnityEngine;

public class Elevator : MonoBehaviour
{
    public AnimatePositionCinematic bars; 

    private AnimatePositionCinematic elevator; 
    private CharacterMotor cm; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elevator = GetComponentInParent<AnimatePositionCinematic>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        cm = other.GetComponent<CharacterMotor>(); 
        if (cm!= null)
        {
            //cm.enabled = false; 
            bars.Reveal(); 

            elevator.Reveal(); 

            gameObject.SetActive(false); 

        }
    }
}
