using System;
using UnityEngine;
using UnityEngine.Events;

public class WinListener : MonoBehaviour
{
    public UnityEvent OnWin;

    private void CallWinEvent()
    {
        OnWin.Invoke();
    }

    private void OnEnable()
    {
        GameState.OnWin += CallWinEvent;
    }
    
    private void OnDisable()
    {
        GameState.OnWin -= CallWinEvent;
    }
}
