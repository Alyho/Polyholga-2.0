using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class NewRoomManager : MonoBehaviour
{
    public Light[] lights;
    private AnimatePositionCinematic animateDoor;
    private bool locked = false;
    private float interval = 0.3f;
    public UnityEvent onSolve;

    public int roomNumber;
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
            CheckAnswer();
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

    private void CheckAnswer()
    {

        GlobalCodeManager.Instance.currentOrder[GlobalCodeManager.Instance.currentIndex] = roomNumber;


        if (GlobalCodeManager.Instance.currentOrder[GlobalCodeManager.Instance.currentIndex] != GlobalCodeManager.Instance.correctOrder[GlobalCodeManager.Instance.currentIndex])
        {
            //Debug.Log("Incorrect");
            GlobalCodeManager.Instance.currentIndex = 0;

        }
        else
        {
            GlobalCodeManager.Instance.currentIndex++;
            if (GlobalCodeManager.Instance.currentIndex >= GlobalCodeManager.Instance.correctOrder.Length)
            {
                // Puzzle solved
                Debug.Log("Puzzle Solved!");
                onSolve?.Invoke();
                // You can add additional actions here when the puzzle is solved
            }
        }

        //GetComponent<Interactable>().SetInteractable(false);
        //solvedIndicator.SetActive(true);

        //Debug.Log("YOU DID IT");
    }

}
