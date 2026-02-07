using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public AudioMixer masterMixer;

    public static AudioManager Instance = null;

    //private AudioSource music; 
	
    private void Awake()
    {

        //music = gameObject.GetComponent<AudioSource>(); 

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

    /*public void AdjustMusicVolume(float duration, float targetVolume){
        StartCoroutine(FadeVolume(duration, targetVolume)); 
    }

    private static IEnumerator FadeVolume(float duration, float targetVolume)
    {
        float startVolume = audioSource.volume;
        float currentTime = 0;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
            yield return null; // Wait for the next frame
        }

        audioSource.volume = targetVolume;
    }*/


}
