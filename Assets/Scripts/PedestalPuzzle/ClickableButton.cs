using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ClickableButton : MonoBehaviour
{
    [Header("Options")]
    public float depressionDepth = 2f;

    public AnimationCurve animationCurve;

    public float pushAnimationLength = 1f;

    public bool reversePressDirection = false;

    [Header("Assets")]
    public AudioSource clickSound;

    private Vector3 _startPos;
    private Vector3 _endPos;

    private IEnumerator currentAnimationCoroutine;
    private bool _pushedIn;

    [Header("Events")]
    public UnityEvent onPushIn;
    public UnityEvent onRelease;
    
    private void Start()
    {
        _startPos = transform.position;
        
        if (reversePressDirection)
            _endPos = _startPos + (Vector3.back * depressionDepth);
        else
            _endPos = _startPos + (Vector3.forward * depressionDepth);
    }

    public void OnPush()
    {
        if (currentAnimationCoroutine != null) StopCoroutine(currentAnimationCoroutine);

        currentAnimationCoroutine = _pushedIn ? ReleaseCoroutine() : PushInCoroutine();
        StartCoroutine(currentAnimationCoroutine);
    }

    private void PlayClickSound()
    {
        if (!clickSound)
            Debug.LogWarning("Add a button click sound!");
        else
            clickSound.Play();
    }
    
    private IEnumerator PushInCoroutine()
    {
        onPushIn.Invoke();
        _pushedIn = true;

        PlayClickSound();

        float elapsedTime = 0f;
        while (elapsedTime < pushAnimationLength)
        {
            transform.position = Vector3.Lerp(_startPos, _endPos, animationCurve.Evaluate(elapsedTime / pushAnimationLength));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return null;
        
        currentAnimationCoroutine = null;
    }
    
    private IEnumerator ReleaseCoroutine(bool userTriggered = true)
    {
        _pushedIn = false;

        if (userTriggered)
        {
            onRelease.Invoke();
            PlayClickSound();
        }

        float elapsedTime = 0f;
        while (elapsedTime < pushAnimationLength)
        {
            transform.position = Vector3.Lerp(_endPos, _startPos, animationCurve.Evaluate(elapsedTime / pushAnimationLength));

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        yield return null;
        
        currentAnimationCoroutine = null;
    }

    /// <summary>
    /// Used to programmatically release button. Does not play sound, since it's not user-triggered.
    /// </summary>
    public void Release()
    {
        if (currentAnimationCoroutine != null) StopCoroutine(currentAnimationCoroutine);
        
        StartCoroutine(ReleaseCoroutine(false));
    }
}
