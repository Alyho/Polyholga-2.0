using UnityEngine;
using System.Collections;

public class NewRoomManager : MonoBehaviour
{
    public Light[] lights;
    private AnimatePositionCinematic animateDoor;
    private bool locked = false;
    private float interval = 0.3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animateDoor = GetComponentInChildren<AnimatePositionCinematic>();
        foreach (Light l in lights)
        {
            if (l != null)
                l.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() && locked == false)
        {
            //other.transform.position = Vector3.zero;
            //transform.parent.parent.position = Vector3.zero;
            animateDoor.Reveal();
            locked = true;
            StartCoroutine(TurnOnLightsSequentially());
        }

    }

    private IEnumerator TurnOnLightsSequentially()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i] != null)
            {
                lights[i].enabled = true;
            }

            yield return new WaitForSeconds(interval);
        }

    }

}
