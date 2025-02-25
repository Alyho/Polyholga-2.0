using Sirenix.OdinInspector;
using UnityEngine;

public class PuzzleHelper : MonoBehaviour
{
    public ShapeCodeController tunnelPuzzleController;
    public OrderedButtonController pedestalPuzzleController;
    public LabelController chairPuzzleController;

    [Button("Solve Tunnel Puzzle")]
    private void TunnelPuzzleButton()
    {
        tunnelPuzzleController.onSolve?.Invoke();
    }
    
    [Button("Solve Pedestal Puzzle")]
    private void PedestalPuzzleButton()
    {
        pedestalPuzzleController.onSolve?.Invoke();
    }
    
    [Button("Solve Chair Puzzle")]
    private void ChairPuzzleButton()
    {
        chairPuzzleController.onSolve?.Invoke();
    }
}
