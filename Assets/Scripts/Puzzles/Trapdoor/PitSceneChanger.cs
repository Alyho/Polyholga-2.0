using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Rendering;


public class PitSceneChanger : MonoBehaviour
{
    public Transform moveCharacter; 
    public GlobalCodeManager startMaze; 
    public GameObject elevator; 

    private Transform currTransform; 
    private CharacterMotor cm; 
    private AnimatePositionCinematic elevatorMove; 
    private PlatformCharacterController test; 

    private bool once = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elevatorMove = elevator.GetComponent<AnimatePositionCinematic>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        cm = other.GetComponent<CharacterMotor>(); 
        test = other.GetComponent<PlatformCharacterController>(); 
        if (cm!= null && once == false)
        {
            cm.enabled = false; 
            test.enabled = false;
            currTransform = other.GetComponent<Transform>(); 
            //print("Current Positoin" + currTransform.position); 
            currTransform.position = moveCharacter.position;
            currTransform.localRotation = Quaternion.identity; 
            //print("After Position: " + currTransform.position); 
            
            RenderSettings.ambientMode = AmbientMode.Flat;
            RenderSettings.ambientLight = Color.black; 
            DynamicGI.UpdateEnvironment();
            RenderSettings.reflectionIntensity = 0.0f;

            elevator.SetActive(true); 
 
            StartCoroutine(TurnOnCM()); 
            
        }
        else if (cm!= null && once == true){
            
            //test.enabled = true; 
            StartCoroutine(TurnOnCM()); 
            
        }

    }

     private IEnumerator TurnOnCM()
    {
             
        yield return new WaitForSeconds(1.0f);
        
        
   
        //startMaze.enabled = true; 

        if (once == true){
            test.enabled = true; 
            elevatorMove.Reveal(); 
        } else{
            test.enabled = true; 
        cm.enabled = true; 
            once = true; 
        }
    }


}
