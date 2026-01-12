using System.Collections;
using UnityEngine;

public class CellSentinelle : Cell
{
    private Pawn _pawn = null;

    public override void Activate(Pawn CurrentPawn)
    {
        _pawn = CurrentPawn;
        if (CurrentPawn._playerData._IsEquiped)
        {
            _pawn._playerData._IsEnding = true;
            _pawn.TryMoving(8);
        }
        else
        {
            GetComponent<IActionnable>().Action(CurrentPawn, 0);
        }
    }
}
