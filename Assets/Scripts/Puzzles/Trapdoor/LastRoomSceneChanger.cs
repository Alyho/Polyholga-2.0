using UnityEngine;
using UnityEngine.Rendering;

public class LastRoomSceneChanger : MonoBehaviour
{
    public Transform moveCharacter; 
    private Transform currTransform; 
    private CharacterMotor cm; 

    private PlatformCharacterController test; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Check");
        cm = other.GetComponent<CharacterMotor>(); 
        if (cm!= null)
        {
            test = other.GetComponent<PlatformCharacterController>(); 
            cm.enabled = false; 
            test.enabled = false; 
            currTransform = other.GetComponent<Transform>(); 
            //print("Current Positoin" + currTransform.position); 
            currTransform.position = moveCharacter.position;

            //test.enabled = true; 
            //currTransform.localRotation = Quaternion.identity; 
            //print("After Position: " + currTransform.position); 

            RenderSettings.ambientMode = AmbientMode.Skybox;
            //RenderSettings.ambientLight = 1; 
            RenderSettings.reflectionIntensity = 1.0f; 
            DynamicGI.UpdateEnvironment();
            
        }
    }

}
