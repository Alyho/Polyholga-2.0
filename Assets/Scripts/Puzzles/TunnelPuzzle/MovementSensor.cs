using UnityEngine;
using System.Collections;

public class MovementSensor : MonoBehaviour
{
    public bool inner;
    static bool playerEntering;
    public AudioSource ForwardSound;
    public AudioSource BackwardSound;
    public AudioSource WinSound;
    public GameObject Numbers;
    static bool audioPlaying;
    static bool puzzleSolved;
    public static bool playerNear;
    

    private void Start()
    {
        Numbers.SetActive(false);
        audioPlaying = false;
        puzzleSolved = false;
        playerEntering = true;
        playerNear = false;
    }
    private void Update()
    {
        if ((Input.GetAxis("Vertical") == 0)&& (Input.GetAxis("Horizontal") == 0)){
            BackwardSound.Pause();
            ForwardSound.Pause();
            audioPlaying = false;
        }
        else if (!audioPlaying&&!puzzleSolved&&playerNear)
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                BackwardSound.Pause();
                ForwardSound.Play();
            }
            else
            {
                ForwardSound.Pause();
                BackwardSound.Play();
            }
            audioPlaying = true;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        playerNear = true;
        GameObject player = collider.gameObject;
        if ((inner && playerEntering) || (!inner&&!playerEntering))
        {
            CheckPuzzle(player);
            playerEntering = false;
        }
        if (!inner)
        {
            playerEntering = true;
        }
    }

    void CheckPuzzle(GameObject player)
    {
        Vector3 PlayerDirection = player.transform.forward;
        PlayerDirection.y = 0;
        Vector3 TunnelDirection = this.transform.right;
        TunnelDirection.y = 0;
        if (!puzzleSolved)
        {
            if ((Vector3.Dot(PlayerDirection, TunnelDirection) < 0 && inner) || (Vector3.Dot(PlayerDirection, TunnelDirection) > 0 && !inner))
            {
                BackwardSound.Pause();
                WinSound.Play();
                StartCoroutine(PlayForwardAudio());
                Numbers.SetActive(true);
                puzzleSolved=true;
            }
            else
            {
                if (!audioPlaying)
                {
                    BackwardSound.Play();
                    audioPlaying = true;
                }
            }
        }
    }
    public void LeaveTunnel()
    {
        audioPlaying = false;
        playerNear = false;
    }
    IEnumerator PlayForwardAudio()
    {
        yield return new WaitForSeconds(3);
        ForwardSound.Play();
    }
}