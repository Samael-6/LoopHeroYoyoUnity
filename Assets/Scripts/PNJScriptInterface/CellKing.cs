using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CellKing : Cell , IDialogueSetter
{
    private Pawn _pawn = null;
    [SerializeField] private GameObject _UIVictoryMessage;

    public override void Activate(Pawn CurrentPawn)
    {
        _pawn = CurrentPawn;
        if (CurrentPawn._playerData._IsEnding)
        {
            SetIndex(14);
            StartCoroutine(VictoryScreen(CurrentPawn));
        }
        else if (CurrentPawn._playerData._IndexKingDialogue == 10)
        {
            SetIndex(11);
        }
        GetComponent<IActionnable>().Action(CurrentPawn, CurrentPawn._playerData._IndexKingDialogue);
    }

    public void SetIndex(int index)
    {
        if (!(_pawn._playerData._IsEnding) && index > 11)
        {
            index = 11;
        }
        _pawn._playerData._IndexKingDialogue = index;
    }

    // Correction de la propriété VictoryScreen pour inclure au moins un accesseur
    private IEnumerator VictoryScreen(Pawn pawn)
    {
        yield return new WaitUntil(() => pawn._playerData._IndexKingDialogue == 15);
        _UIVictoryMessage.SetActive(true);
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }
}
