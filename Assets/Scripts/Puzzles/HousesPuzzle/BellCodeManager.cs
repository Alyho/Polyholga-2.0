using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class BellCodeManager : MonoBehaviour
{
    public int[] correctMorse = new int[7];
    private int[] currentMorse;
    private int index = 0;
    private double gapTimer = 0f;
    private bool countingGap = false;
    public float gapThreshold = 2f;
    private Interactable bellInteractableScript;
    private Outline bellOutline;
    public UnityEvent onSolve;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentMorse = new int[7];
        bellInteractableScript = GetComponentInChildren<Interactable>();
        bellOutline = GetComponentInChildren<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        //Something wrong with countingGap Logic because it'll remain false after user does something even if I click the button again
        if (countingGap)
        {
            gapTimer += Time.deltaTime;

            if (gapTimer >= gapThreshold)
            {
                countingGap = false;
                CompareCode();
                UnityEngine.Debug.Log($"Word ended.");
            }
        }
    }

    private void CompareCode()
    {
        for (int i = 0; i < correctMorse.Length; i++)
        {
            if (currentMorse[i] != correctMorse[i])
            {
                UnityEngine.Debug.Log("Incorrect Code");
                System.Array.Clear(currentMorse, 0, currentMorse.Length);
                index = 0;
                return;
            }
        }

        UnityEngine.Debug.Log("Correct Code");
        bellInteractableScript.enabled = false;
        bellOutline.enabled = false;
        onSolve?.Invoke();
    }

    public void addDot()
    {

        if (index < currentMorse.Length)
        {
            currentMorse[index] = 1;
            index++;
            gapTimer = 0f;
            countingGap = true;
            UnityEngine.Debug.Log(index + " " + countingGap);
        }
    }

    public void pauseTimer()
    {
        countingGap = false;
    }

    public void addDash()
    {
        countingGap = true;

        if (index < currentMorse.Length)
        {
            currentMorse[index] = 2;
            index++;
            gapTimer = 0f;
            UnityEngine.Debug.Log(index + " " + countingGap);
        }
    }
}
