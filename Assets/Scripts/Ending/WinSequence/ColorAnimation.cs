using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorAnimation : MonoBehaviour
{
    public Material restoredColor;

    private GameObject origin;

    private float totalTime = 1f;

    private Jump jumpScript;

    public void ChangeColor()
    {
        origin = GameObject.FindWithTag("Sword");

        float distance = Vector3.Distance(origin.transform.position, transform.position);

        StartCoroutine(ChangeColorDelay(distance));

        //Debug.Log(distance);
        //GetComponent<MeshRenderer>().material.color = restoredColor.color;
    }

    private IEnumerator ChangeColorDelay(float distance)
    {
        float delay = distance / 3;

        if (delay >= 25){
            delay = distance / 5; 
        }

        yield return new WaitForSeconds(delay);

        Color initialColor = GetComponent<MeshRenderer>().material.color;
        float elapsedTime = 0f;

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            GetComponent<MeshRenderer>().material.color = Color.Lerp(initialColor, restoredColor.color, elapsedTime / totalTime);
            yield return null;
        }

        GetComponent<MeshRenderer>().material.color = restoredColor.color;

        jumpScript = GetComponent<Jump>();

        if (jumpScript != null){
            jumpScript.enabled = true;
        }
    
    }

    // TODO: make coroutine that transitions current color to restored color
}
