using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OrderedButtonController : MonoBehaviour
{
    [SerializeField] private ClickableButton[] pedestalButtons;

    [Tooltip("Order of button presses that give us our solution (value of each element is the button idx in pedestalButtons")]
    public int[] solutionOrder;

    private List<int> _currSolution = new List<int>();

    [Header("Events")]
    public UnityEvent onSolve;
    public UnityEvent onReset;
    public UnityEvent onIncorrect;

    private bool _solved = false;

    private void Awake()
    {
        for (int i = 0; i < pedestalButtons.Length; i++)
        {
            var clickableButton = pedestalButtons[i];
            var buttonIdx = i;
            
            clickableButton.onPushIn.AddListener(() => OnButtonPush(buttonIdx));
            clickableButton.onRelease.AddListener(OnButtonRelease);
        }
    }
    
    public void OnButtonPush(int button)
    {
        if (_solved) return;
        
        _currSolution.Add(button);

        if (_currSolution.Count != solutionOrder.Length)
            return;
        
        for (int i = 0; i < solutionOrder.Length; i++)
        {
            if (solutionOrder[i] != _currSolution[i])
            {
                Reset();
                onIncorrect?.Invoke();
                return;
            }
        }   
        
        for (int i = 0; i < pedestalButtons.Length; i++)
        {
            var clickableButton = pedestalButtons[i];
            clickableButton.GetComponent<Interactable>().SetInteractable(false);
        }
        
        onSolve?.Invoke();
    }

    private void Reset()
    {
        _currSolution.Clear();
        onReset?.Invoke();
        
        for (int i = 0; i < pedestalButtons.Length; i++)
        {
            var clickableButton = pedestalButtons[i];
            
            clickableButton.Release();
        }
    }

    public void OnButtonRelease()
    {
        Reset();
    }
}
