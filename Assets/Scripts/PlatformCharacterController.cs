using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlatformCharacterController : MonoBehaviour
{
    CharacterController cc;
    Transform currentPlatform;
    Vector3 lastPlatformPos;
    Quaternion lastPlatformRot;
    Vector3 platformVelocity;

    void Awake() => cc = GetComponent<CharacterController>();

    void Update()
    {

        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 move = transform.TransformDirection(input) * 5f;
  
        if (cc.isGrounded) move.y = -1f; else move.y += Physics.gravity.y * Time.deltaTime;


        if (currentPlatform != null)
        {
            Vector3 platformDelta = currentPlatform.position - lastPlatformPos;

            Quaternion rotDelta = currentPlatform.rotation * Quaternion.Inverse(lastPlatformRot);
            Vector3 rotationalDelta = rotDelta * (transform.position - currentPlatform.position) - (transform.position - currentPlatform.position);

            move += platformDelta / Time.deltaTime; 

            lastPlatformPos = currentPlatform.position;
            lastPlatformRot = currentPlatform.rotation;
        }


        cc.Move(move * Time.deltaTime);
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.normal.y > 0.5f)
        {
            var t = hit.collider.transform;
            if (t != currentPlatform)
            {
                currentPlatform = t;
                lastPlatformPos = currentPlatform.position;
                lastPlatformRot = currentPlatform.rotation;
            }
        }
    }

    void LateUpdate()
    {
        if (currentPlatform != null && !cc.isGrounded)
        {
            currentPlatform = null;
        }
    }
}
