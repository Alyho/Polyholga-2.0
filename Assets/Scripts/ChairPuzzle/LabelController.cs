using UnityEngine;
using System;
using UnityEngine.Events;
public class LabelController : MonoBehaviour
{
    public int[] currentStates;
    public int[] solution;
    public UnityEvent onSolve;
    private bool solved = false;
    
    
    
    void Start()
    {
        currentStates = new int[] { 0, 0, 0, 0, 0, 0 };
        solution = new int[] { 0, 1, 5, 3, 2, 4 };
    }

    public void Click(int i)
    {
        currentStates[i] = (currentStates[i] + 1) % 6;
        CheckSolution();
    }

    void CheckSolution()
    {
        if (solved)
        {
            return;
        }
        for (int i = 0; i < currentStates.Length; i++)
        {
            if (currentStates[i] != solution[i])
            {
                return;
            }
        }
        onSolve.Invoke();
        solved = true;
    }
}
