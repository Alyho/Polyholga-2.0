using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;
public class DoorTrigger : MonoBehaviour
{
    public GameObject nextRoom;
    private GameObject nextRoomRef;

    public GameObject lastRoomPrefab;
    public Transform newSpawnPoint;

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
                StartCoroutine(RemoveCurrentRoom());
            }
            else
            {
                locked = false;
                animateDoor.Reveal();
                StartCoroutine(RemoveNextRoom());

            }
        }
    }

    private bool IsOnFrontSide(Vector3 worldPos)
    {
        Vector3 toPoint = (worldPos - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, toPoint);
        return dot > 0f;
    }

    /*private IEnumerator Delay()
    {
        Debug.Log("Check " + (nextRoomRef != null) + " " + (locked == false));

        if (nextRoomRef != null || locked == false)
        {
            GameObject nextRoomRefRef = nextRoomRef;
            yield return new WaitForSeconds(1.5f);
            Destroy(nextRoomRefRef);
            //nextRoomRef = null;
        }
        else
        {

            yield return new WaitForSeconds(1f);
            Destroy(transform.parent.gameObject);
        }
    }*/

    private IEnumerator RemoveNextRoom()
    {
        GameObject nextRoomRefRef = nextRoomRef;
        yield return new WaitForSeconds(1.5f);
        Destroy(nextRoomRefRef);
    }

    private IEnumerator RemoveCurrentRoom()
    {
        yield return new WaitForSeconds(1f);
        Destroy(transform.parent.gameObject);
    }

    public void ChangeNextRoom()
    {
        nextRoom = lastRoomPrefab;
        spawnPoint = newSpawnPoint;
    }
}
