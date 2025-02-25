using UnityEngine;

public class SwordIndicator : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject sword;

    private void Start()
    {
        background.SetActive(true);
        sword.SetActive(false);
    }
    
    private void Update()
    {
        sword.SetActive(HolgaSword.hasSword);
    }
}
