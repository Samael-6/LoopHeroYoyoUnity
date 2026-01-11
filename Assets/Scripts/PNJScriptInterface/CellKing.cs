using UnityEngine;

public class CellKing : Cell
{
    public override void Activate(Pawn CurrentPawn)
    {
        if (CurrentPawn._playerData._IsEnding)
        {
            CurrentPawn._playerData._IndexKingDialogue = 14;
        }
    }
}
