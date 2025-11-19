using UnityEngine;

public class GlobalCodeManager : MonoBehaviour
{
    public static GlobalCodeManager Instance;

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


    }

    // Update is called once per frame
    void Update()
    {

    }
}
