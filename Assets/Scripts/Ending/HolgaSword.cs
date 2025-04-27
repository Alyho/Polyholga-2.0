using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HolgaSword : MonoBehaviour
{

    public static bool hasSword = false;
    public GameObject swordSprite;

    public GameObject cutScene;

    public GameObject emptySwordSprite;

    public float growFactor;
    public float waitTime;

    public float maxSize;
    private Vector3 ogSize;

    void Start()
    {
        ogSize = emptySwordSprite.transform.localScale;
    }

    public void OnClick()
    {
        if (hasSword == false)
        {
            StartCoroutine(NoSword());
        }
        else
        {
            cutScene.SetActive(true);
            swordSprite.SetActive(false);

            GetComponent<Outline>().OutlineWidth = 0;
            hasSword = false;
        }
    }

    private IEnumerator NoSword()
    {
        while (maxSize > emptySwordSprite.transform.localScale.x)
        {
            emptySwordSprite.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        while (ogSize.x < emptySwordSprite.transform.localScale.x)
        {
            emptySwordSprite.transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
            yield return null;
        }

        emptySwordSprite.transform.localScale = ogSize;

        //timer = 0;
        //yield return new WaitForSeconds(waitTime);

        //emptySwordSprite.transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;

        //yield return new WaitForSeconds(0);
    }
}
