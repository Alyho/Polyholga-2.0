using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningCutscene : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    
    [SerializeField] private GameObject[] sentences;

    [Tooltip("Length of each frame in seconds")]
    public float frameLength = 5.0f;

    // State
    private bool _onTitleScreen = true;
    private int _currentFrameIdx = 0;
    private float _timeOnFrame = 0f;

    private void Update()
    {
        if (Input.anyKeyDown)
            AdvanceFrame();

        if (_onTitleScreen) return;
            
        if (_timeOnFrame >= frameLength)
            AdvanceFrame();
        
        _timeOnFrame += Time.deltaTime;
    }

    private void AdvanceFrame()
    {
        if (_onTitleScreen)
        {
            titleScreen.SetActive(false);
            _onTitleScreen = false;
            
            sentences[0].SetActive(true);
            return;
        }
        
        if (_currentFrameIdx == sentences.Length - 1)
        {
            SceneManager.LoadScene("city-square", LoadSceneMode.Single);
            return;
        }

        sentences[_currentFrameIdx].SetActive(false);
        _currentFrameIdx++;
        sentences[_currentFrameIdx].SetActive(true);
        
        _timeOnFrame = 0f;
    }
}
