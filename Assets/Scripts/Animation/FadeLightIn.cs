using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class FadeLightIn : MonoBehaviour
{
    private Light _lightSource;
    [SerializeField] private AnimationCurve intensityCurve;

    public float transitionTime = 1.0f;
    public float goalIntensity = 1.0f;

    private void OnEnable()
    {
        _lightSource = GetComponent<Light>();
        _lightSource.intensity = 0.0f;
        
        StartCoroutine(TransitionIntensity());
    }

    private IEnumerator TransitionIntensity()
    {
        float startIntensity = _lightSource.intensity;
        
        float elapsedTime = 0f;
        while (elapsedTime < transitionTime)
        {
            _lightSource.intensity = Mathf.Lerp(startIntensity, goalIntensity, intensityCurve.Evaluate(elapsedTime / transitionTime));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return null;
    }
}
