using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ScrollUp : MonoBehaviour
{
    public Image image;
    public float fadeTime = 2f;

    private float duration = 20f;
    private Vector3 startPoint;
    private Vector3 endPoint;
    public GameObject endPointObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPoint = transform.position;
        endPoint = endPointObject.transform.position;
        StartCoroutine(Scroll());
    }

    // Update is called once per frame
    void Update()
    {

    }


    private IEnumerator Scroll()
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            Debug.Log("time elapsed" + timeElapsed + " delta" + Time.deltaTime + "t" + timeElapsed / duration);
            transform.position = Vector3.Lerp(startPoint, endPoint, timeElapsed / duration);

            yield return null;
        }

        StartCoroutine(FadeToBlackCoroutine());
    }

    private IEnumerator FadeToBlackCoroutine()
    {
        float timer = 0;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timer / fadeTime);
            Color color = image.color;
            image.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("FirstScene");
    }
}
