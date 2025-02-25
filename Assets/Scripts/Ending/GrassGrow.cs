using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class GrassGrow : MonoBehaviour
{
    [MinMaxSlider(0, 5)]
    public Vector2 scaleRange = new Vector2(0, 2);
    
    public float animationTime;

    private Vector3 _finalScale;

    private void Start()
    {
        _finalScale = Vector3.one * Random.Range(scaleRange.x, scaleRange.y);

        transform.localScale = Vector3.zero;
    }

    public void TriggerGrassGrow()
    {
        StartCoroutine(GrowGrass());
    }

    private IEnumerator GrowGrass()
    {
        float elapsedTime = 0f;

        while (elapsedTime < animationTime)
        {
            elapsedTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector3.zero, _finalScale, elapsedTime / animationTime);
            yield return null;
        }
    }
}
