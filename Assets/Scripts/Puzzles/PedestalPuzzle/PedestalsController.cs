using System.Collections;
using UnityEngine;

public class PedestalsController : MonoBehaviour
{
    [SerializeField] private PedestalIndicatorController[] pedestalIndicatorControllers;

    public float incorrectLightLength = 2.5f;

    public void ResetIndicators()
    {
        foreach (var controller in pedestalIndicatorControllers)
        {
            controller.HideAll();
        }
    }
    
    public void ShowIncorrectIndicators()
    {
        foreach (var controller in pedestalIndicatorControllers)
        {
            controller.OnIncorrect();
        }

        StartCoroutine(HideIncorrectIndicators(incorrectLightLength));
    }
    
    private IEnumerator HideIncorrectIndicators(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        
        foreach (var controller in pedestalIndicatorControllers)
        {
            controller.HideIncorrectIndicator();
        }
    }
    
    public void ShowSolveIndicators()
    {
        foreach (var controller in pedestalIndicatorControllers)
        {
            controller.OnSolved();
        }
    }
}
