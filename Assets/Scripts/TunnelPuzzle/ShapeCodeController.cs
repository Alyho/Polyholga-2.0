using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ShapeCodeController : MonoBehaviour
{
    [SerializeField] private GameObject[] slots;

    /// <summary>
    /// Current state of shapes in the different puzzle slots.
    ///
    /// Set this in the inspector for the puzzle to load the right shapes into the right slots when initializing.
    /// This array will be updated as the player changes shapes, and is used to check whether or not the puzzle
    /// is solved.
    /// </summary>
    public Shape[] shapeInSlots;

    public Shape[] solution;

    public UnityEvent onSolve;

    private bool _solved = false;

    private void Start()
    {
        for (int slot = 0; slot < slots.Length; slot++)
            ChangeShape(slot, shapeInSlots[slot]);
    }

    public void ChangeShape(int slot, Shape shape)
    {
        GameObject slotObj = slots[slot];
        int amountOfShapes = Enum.GetNames(typeof(Shape)).Length;
        for (int i = 0; i < amountOfShapes; i++)
        {
            GameObject shapeObj = slotObj.transform.GetChild(i).gameObject;
            shapeObj.SetActive(shapeObj.GetComponent<CodeShape>().shape == shape);
        }
        
        shapeInSlots[slot] = shape;
        
        CheckCode();
    }

    private bool CodeMatches(Shape[] code)
    {
        for (int i = 0; i < code.Length; i++)
        {
            if (shapeInSlots[i] != code[i])
                return false;
        }

        return true;
    }

    private void CheckCode()
    {
        // If the puzzle has already been solved, don't fire the `onSolve` event again.
        if (_solved) return;

        Shape[] reversedSolution = solution.Reverse().ToArray();

        bool anyCodeMatches = CodeMatches(solution) || CodeMatches(reversedSolution);
        if (!anyCodeMatches) return;
        
        _solved = true;
        onSolve?.Invoke();
    }
}
