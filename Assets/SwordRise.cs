using UnityEngine;
using System.Collections;

public class SwordRise : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject blade;
    public float animationLength = 2f;
    public float riseDistance = 2f;
    public GameObject sword;
    public AudioSource solveSound;
    void Start()
    {
        sword.GetComponent<Outline>().enabled = false;
        sword.GetComponent<Interactable>().enabled = false;
        blade.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    public void Rise()
    {
        solveSound.Play();
        blade.GetComponent<MeshRenderer>().enabled = true;
        StartCoroutine(RiseCoroutine());
    }
    private IEnumerator RiseCoroutine()
    {
        Vector3 startingPos = transform.position;
        Vector3 finalPos = transform.position + (Vector3.up * riseDistance);

        float elapsedTime = 0;

        while (elapsedTime < animationLength)
        {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / animationLength));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        sword.GetComponent<Outline>().enabled = true;
        sword.GetComponent<Interactable>().enabled = true;
    }

    public void Take()
    {
        HolgaSword.hasSword = true;
        Object.Destroy(sword);
    }
}
