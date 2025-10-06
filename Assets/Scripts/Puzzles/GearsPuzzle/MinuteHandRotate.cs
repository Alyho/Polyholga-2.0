using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class MinuteHandRotate : MonoBehaviour
{
    private float rotationAngle = 150f;   // Degrees to rotate
    private float duration = 5;         // Time in seconds

    private bool isRotating = false;
    private float delayBeforeStart = 2f;
    private AudioSource audioSource;
    public AudioClip newClip;

    [Header("Camera Shake")]
    [SerializeField] private CinemachineBasicMultiChannelPerlin cameraShake;

    public float cameraShakeStrength = 1f;
    public AnimationCurve cameraShakeCurve;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void StartRotation()
    {
        if (!isRotating)
            StartCoroutine(RotateOverTime());
    }

    private System.Collections.IEnumerator RotateOverTime()
    {
        isRotating = true;

        if (delayBeforeStart > 0f)
            yield return new WaitForSeconds(delayBeforeStart);

        if (audioSource != null)
            audioSource.Play();

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.AngleAxis(rotationAngle, Vector3.right); // X-axis rotation

        float elapsed = 0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsed / duration);
            //cameraShake.AmplitudeGain = cameraShakeCurve.Evaluate(elapsed / duration) * cameraShakeStrength;
            elapsed += Time.deltaTime;
            yield return null;
        }
        //cameraShake.AmplitudeGain = 0;

        transform.rotation = endRotation;
        isRotating = false;

        //yield return new WaitForSeconds(1f);
        ChangeAudioAndPlay(newClip);

    }


    public void ChangeAudioAndPlay(AudioClip newAudio)
    {
        if (newAudio == null) return;

        audioSource.clip = newAudio;
        audioSource.Play();
    }

}
