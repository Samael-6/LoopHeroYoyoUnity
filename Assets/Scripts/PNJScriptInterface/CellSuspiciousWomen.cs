using System.Collections;
using UnityEngine;

public class CellSuspiciousWomen : Cell, IDialogueSetter
{
    private Pawn _pawn = null;

    public override void Activate(Pawn CurrentPawn)
    {
        _pawn = CurrentPawn;
        if (CurrentPawn._playerData._IndexSuspiciousWomanDialogue== 5)
        {
            SetIndex(6);
        }
        else
        {
            StartCoroutine(TeleportationGraveYard(CurrentPawn));
        }
        GetComponent<IActionnable>().Action(CurrentPawn, CurrentPawn._playerData._IndexSuspiciousWomanDialogue);
    }

    public void SetIndex(int index)
    {
        if (_pawn._playerData._IsEquiped)
        {
            index = 5;
        }
        _pawn._playerData._IndexSuspiciousWomanDialogue = index;
    }

    private IEnumerator TeleportationGraveYard(Pawn pawn)
    {
        yield return new WaitUntil(() => pawn._playerData._IndexSuspiciousWomanDialogue == 4);
        pawn.TryMoving(1);
    }
}
