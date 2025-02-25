using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer masterMixer;

    public static AudioManager Instance = null;
	
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad (gameObject);
    }
    
    public void SetVolume(float soundLevel)
    {
        masterMixer.SetFloat("masterVol", Mathf.Log(soundLevel) * 20);
    }
}
