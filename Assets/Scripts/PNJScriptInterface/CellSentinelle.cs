using System.Collections;
using UnityEngine;

public class CellSentinelle : Cell
{
    private Pawn _pawn = null;

    [SerializeField] private SceneLoader _sceneLoader;

    public override void Activate(Pawn currentPawn)
    {
        _pawn = currentPawn;
        if (currentPawn._playerData._IsEquiped)
        {
            _pawn._playerData._IsEnding = true;
            _pawn.TryMoving(8);
        }
        else
        {
            GetComponent<IActionnable>().Action(currentPawn, 0);
        }
    }
}