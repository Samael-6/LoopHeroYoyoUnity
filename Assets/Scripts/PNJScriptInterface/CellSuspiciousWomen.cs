using System.Collections;
using UnityEngine;

public class CellSuspiciousWomen : Cell
{
    public override void Activate(Pawn CurrentPawn)
    {
        if (CurrentPawn._playerData._IndexSuspiciousWomanDialogue== 5)
        {
            SetIndexSupiciousWoman(CurrentPawn, 6);
        }
        else
        {
            StartCoroutine(TeleportationGraveYard(CurrentPawn));
        }
        GetComponent<IActionnable>().Action(CurrentPawn, CurrentPawn._playerData._IndexSuspiciousWomanDialogue);
    }

    public void SetIndexSupiciousWoman(Pawn CurrentPawn, int index)
    {
        CurrentPawn._playerData._IndexKingDialogue = index;
    }

    private IEnumerator TeleportationGraveYard(Pawn pawn)
    {
        yield return new WaitUntil(() => pawn._playerData._IndexSuspiciousWomanDialogue == 5);
        pawn.TryMoving(5);
    }
}
