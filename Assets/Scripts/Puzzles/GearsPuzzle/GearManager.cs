using UnityEngine;

public class GearManager : MonoBehaviour
{
    public static GearManager Instance;

    [Header("Puzzle Settings")]
    public GameObject selectedGear;
    public int[] correctOrder = new int[10];

    [HideInInspector]
    public int[] currentOrder;
    //public GameObject[] placedGears;  // gears player has placed

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        currentOrder = new int[10];

        //placedGears = new GameObject[correctOrder.Length]; // init empty slots
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


}
