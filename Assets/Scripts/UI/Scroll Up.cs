using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ScrollUp : MonoBehaviour
{
    public float speed = 2f;
    public Image image;
    public float fadeTime = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
    }

    public void FadeToBlack()
    {
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
