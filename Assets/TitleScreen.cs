using UnityEngine;
using UnityEngine.Playables;
public class TitleScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private PlayableDirector director;
    public GameObject title;

    void Start()
    {
        director = GetComponent<PlayableDirector>();
        title.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            director.Play();
            title.SetActive(false);
        }
    }
}
