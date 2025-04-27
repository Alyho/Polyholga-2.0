using System;
using UnityEngine;

public enum Shape
{
    Circle,
    Pentagon,
    Rectangle,
    Square
}

public class CodeShape : Interactable
{   
    [Header("Properties")]
    [Tooltip("0-idx slot (e.g. value of 0 represents slot 1)")]
    public int slot;
    public Shape shape;

    [Header("Objects")] [SerializeField] private GameObject solvedIndicator;
    
    [Header("Scripts")]
    [SerializeField] private ShapeCodeController shapeCodeController;

    private void OnEnable() => shapeCodeController.onSolve.AddListener(OnSolve);

    private void OnDisable() => shapeCodeController.onSolve.RemoveListener(OnSolve);

    private void OnSolve()
    {
        GetComponent<Interactable>().SetInteractable(false);
        
        solvedIndicator.SetActive(true);
    }

    public override void OnClick()
    {
        // Get next shape (https://stackoverflow.com/questions/53210460/get-next-item-in-enum-and-return-first-if-last1)
        Shape[] shapeValues = (Shape[])Enum.GetValues(shape.GetType());
        int j = (Array.IndexOf(shapeValues, shape) + 1) % shapeValues.Length;
        Shape nextShape = shapeValues[j];
        
        shapeCodeController.ChangeShape(slot, nextShape);
    }
}
