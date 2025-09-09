using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MaterialAnimation : MonoBehaviour
{

    public Material blendMat;
    private float blendTime = 2f;

    private GameObject origin;

    void Start()
    {
        blendMat.SetFloat("_Blend", 0f);

    }

    public void StartBlend()
    {
        origin = GameObject.FindWithTag("Sword");

        Vector3 referencePos = transform.position;

        if (transform.parent != null)
        {
            referencePos = transform.parent.position;
        }

        float distance = Vector3.Distance(origin.transform.position, referencePos);

        StartCoroutine(BlendCoroutine(distance));
    }

    private IEnumerator BlendCoroutine(float distance)
    {
        float delay = distance / 3;

        if (delay >= 25)
        {
            delay = distance / 5;
        }

        yield return new WaitForSeconds(delay);

        float elapsed = 0f;

        while (elapsed < blendTime)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / blendTime);

            blendMat.SetFloat("_Blend", t);

            yield return null;
        }
    }
}
