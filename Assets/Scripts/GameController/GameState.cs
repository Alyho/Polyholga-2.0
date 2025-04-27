using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static bool Paused;

    public static Action OnWin;
    
    [Button("Trigger a win")]
    private void DefaultSizedButton()
    {
        Win();
    }

    public static void PauseGame()
    {
        Paused = true;

        Time.timeScale = 0;
    }

    public static void ResumeGame()
    {
        Paused = false;
        
        Time.timeScale = 1;
    }

    public void Win()
    {
        Debug.Log("Hooray! We win!");
        
        OnWin?.Invoke();
    }
}
