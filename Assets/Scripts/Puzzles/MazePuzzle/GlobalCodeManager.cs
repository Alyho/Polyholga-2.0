using UnityEngine;
using System.Collections;

public class GlobalCodeManager : MonoBehaviour
{
    public static GlobalCodeManager Instance;
    public Light firstLight;

    public int[] correctOrder = new int[5];

    [HideInInspector]
    public int[] currentOrder;
    [HideInInspector]
    public int currentIndex = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        currentOrder = new int[5];
    }

    void Start()
    {
        firstLight.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator TurnOnLight()
    {
        yield return new WaitForSeconds(0.5f);
        
    }
}
