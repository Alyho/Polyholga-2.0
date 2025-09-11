using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private ObjectVisibility _objectVisibilityScript;

    private void Awake()
    {
        _objectVisibilityScript = pauseMenu.GetComponent<ObjectVisibility>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameState.Paused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        GameState.PauseGame();
        _objectVisibilityScript.ShowObject();
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;  // release
            Cursor.visible = true;
        }

    }

    public void Resume()
    {
        GameState.ResumeGame();


        Cursor.lockState = CursorLockMode.Locked; // recapture
        Cursor.visible = false;

        _objectVisibilityScript.HideObject();
    }

    public void QuitGame() => Application.Quit();
}
