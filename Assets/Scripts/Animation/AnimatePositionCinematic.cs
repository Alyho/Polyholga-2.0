using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class AnimatePositionCinematic : MonoBehaviour
{
    [Header("Assets")]
    [SerializeField] private AudioSource sound;
    [SerializeField] private CinemachineBasicMultiChannelPerlin cameraShake;

    [Header("Options")]
    [Tooltip("The amount of time to wait between the sound start time and the animation start time.")]
    public Transform endPos;
    
    [Header("Animation")]
    public AnimationCurve animationCurve;

    public float animationDelay = 0.3f;

    public float animationLength = 1f;

    [Header("Camera Shake")]
    public float cameraShakeStrength = 1f;
    public AnimationCurve cameraShakeCurve;

    private Vector3 _startPos;

    private void Start()
    {
        _startPos = transform.position;
    }
    
    public void Reveal()
    {
        StartCoroutine(OpenDoorCoroutine());
    }

    private IEnumerator OpenDoorCoroutine()
    {
        if (!sound)
            Debug.LogWarning("Add a door open sound!");
        else
            sound.Play();

        yield return new WaitForSeconds(animationDelay);

        float elapsedTime = 0f;
        while (elapsedTime < animationLength)
        {
            transform.position = Vector3.Lerp(_startPos, endPos.transform.position, animationCurve.Evaluate(elapsedTime / animationLength));
            cameraShake.AmplitudeGain = cameraShakeCurve.Evaluate(elapsedTime / animationLength) * cameraShakeStrength;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cameraShake.AmplitudeGain = 0;

        yield return null;
    }
}
