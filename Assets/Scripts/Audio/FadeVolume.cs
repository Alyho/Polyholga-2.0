using System.Collections;
using UnityEngine;

public class FadeVolume : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AnimationCurve volumeCurve;

    public float transitionTime = 1.0f;
    
    private IEnumerator _currentAnimationCoroutine;
    
    public void SetVolume(float goalVol)
    {
        if (_currentAnimationCoroutine != null) StopCoroutine(_currentAnimationCoroutine);

        _currentAnimationCoroutine = TransitionVolume(goalVol);
        StartCoroutine(_currentAnimationCoroutine);
    }

    private IEnumerator TransitionVolume(float goalVol)
    {
        float startVol = audioSource.volume;
        
        float elapsedTime = 0f;
        while (elapsedTime < transitionTime)
        {
            audioSource.volume = Mathf.Lerp(startVol, goalVol, volumeCurve.Evaluate(elapsedTime / transitionTime));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return null;
        
        _currentAnimationCoroutine = null;
    }
}
