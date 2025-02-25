using System.Collections;
using UnityEngine;

public class PedestalIndicatorController : MonoBehaviour
{
    [SerializeField] private GameObject pressedIndicator;
    [SerializeField] private GameObject incorrectIndicator;
    [SerializeField] private GameObject solvedIndicator;

    private void Start() => HideAll();

    public void HideAll()
    {
        pressedIndicator.SetActive(false);
        incorrectIndicator.SetActive(false);
        solvedIndicator.SetActive(false);
    }

    public void OnPressed()
    {
        HideAll();
        
        pressedIndicator.SetActive(true);
    }
    
    public void OnIncorrect()
    {
        HideAll();
        
        incorrectIndicator.SetActive(true);
    }

    public void HideIncorrectIndicator() => incorrectIndicator.SetActive(false);
    
    public void OnSolved()
    {
        HideAll();
        
        solvedIndicator.SetActive(true);
    }
}
