using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;


public class DoorTrigger : MonoBehaviour
{
    public GameObject nextRoom;
    private GameObject nextRoomRef;

    public Transform spawnPoint;

    private AnimatePositionCinematic animateDoor;

    private bool onFront;
    private bool locked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animateDoor = GetComponentInChildren<AnimatePositionCinematic>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null && locked == false)
        {

            nextRoomRef = UnityEngine.Object.Instantiate(nextRoom, spawnPoint.position, spawnPoint.rotation);
            animateDoor.Reveal();


        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null && locked == false)
        {


            onFront = IsOnFrontSide(other.transform.position);

            if (onFront == false)
            {
                locked = true;
                StartCoroutine(Delay());
            }
            else
            {
                animateDoor.Reveal();
                StartCoroutine(Delay());

            }
        }
    }

    private bool IsOnFrontSide(Vector3 worldPos)
    {
        Vector3 toPoint = (worldPos - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, toPoint);
        return dot > 0f;
    }

    private IEnumerator Delay()
    {

        if (nextRoomRef != null && locked == false)
        {
            yield return new WaitForSeconds(1.5f);
            Destroy(nextRoomRef);
            nextRoomRef = null;
        }
        else
        {
            yield return new WaitForSeconds(1f);
            Destroy(transform.parent.gameObject);
        }
    }

}
