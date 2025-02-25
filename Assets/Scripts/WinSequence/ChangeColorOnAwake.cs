using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeColorOnAwake : MonoBehaviour
{
    public Material restoredColor;

    private float totalTime = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ChangeColor());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator ChangeColor()
    {

        Color initialColor = GetComponent<MeshRenderer>().material.color;
        float elapsedTime = 0f;

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            GetComponent<MeshRenderer>().material.color = Color.Lerp(initialColor, restoredColor.color, elapsedTime / totalTime);
            yield return null;
        }

        GetComponent<MeshRenderer>().material.color = restoredColor.color;
    }
}
