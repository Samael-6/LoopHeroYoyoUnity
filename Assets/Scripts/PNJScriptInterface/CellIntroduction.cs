using UnityEngine;

public class CellIntroduction : Cell
{
    public override void Activate(Pawn CurrentPawn)
    {
        if (CurrentPawn._playerData._IsBeginning)
        {
            base.Activate(CurrentPawn);
            CurrentPawn._playerData._IsBeginning = false;
            CurrentPawn.SyncAndSave();
        }
    }
}
