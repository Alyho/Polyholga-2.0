using System.Collections;
using UnityEngine;

public class CyclingButton : MonoBehaviour
{
    private IEnumerator currentAnimationCoroutine;

    [Header("Options")]
    public float depressionDepth = 2;

    public AnimationCurve animationCurve;

    public float pushAnimationLength = 1f;

    [Header("Assets")]
    public AudioSource clickSound;
    public GameObject label;
    public Sprite[] shapes;
    public int counter = 0;

    [Header("Puzzle Info")]
    public int order;
    public LabelController controller;

    /// <summary>
    /// Position of button at scene start (we always return to this at the end of the animation)
    /// </summary>
    private Vector3 _startPos;

    /// <summary>
    /// Position of button directly before press (we start the animation at this position)
    /// </summary>
    private Vector3 _posBeforePress;
    private Vector3 _endPos;

    private void Start()
    {
        label.GetComponent<SpriteRenderer>().sprite = shapes[counter];
        _startPos = transform.position;
    }

    public void OnPush()
    {
        if (currentAnimationCoroutine != null) StopCoroutine(currentAnimationCoroutine);

        _posBeforePress = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        // Make sure animation doesn't affect the button's y-position
        _startPos.y = _posBeforePress.y;
        _startPos.x = _posBeforePress.x;
        _startPos.z = _posBeforePress.z;

        _endPos = _posBeforePress + (transform.forward * depressionDepth);

        currentAnimationCoroutine = PushButtonCoroutine();
        StartCoroutine(currentAnimationCoroutine);
    }

    private void PlayClickSound()
    {
        if (!clickSound)
            Debug.LogWarning("Add a button click sound!");
        else
            clickSound.Play();
    }

    private IEnumerator PushButtonCoroutine()
    {
        PlayClickSound();

        counter = (counter + 1) % 6;
        label.GetComponent<SpriteRenderer>().sprite = shapes[counter];

        controller.Click(order);

        float elapsedTime = 0f;
        while (elapsedTime < pushAnimationLength)
        {
            transform.position = Vector3.Lerp(_posBeforePress, _endPos, animationCurve.Evaluate(elapsedTime / pushAnimationLength));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0f;
        while (elapsedTime < pushAnimationLength)
        {
            transform.position = Vector3.Lerp(_endPos, _startPos, animationCurve.Evaluate(elapsedTime / pushAnimationLength));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return null;
        currentAnimationCoroutine = null;
    }
}
