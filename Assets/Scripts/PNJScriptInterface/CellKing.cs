using System.Collections;
using UnityEngine;

public class CellKing : Cell
{
    [SerializeField] private GameObject _UIVictoryMessage;
    [SerializeField] private GameObject _DialogueUI;
    public override void Activate(Pawn CurrentPawn)
    {
        if (CurrentPawn._playerData._IsEnding)
        {
            SetIndexKing(CurrentPawn, 14);
            StartCoroutine(VictoryScreen(_DialogueUI));
        }
        else if (CurrentPawn._playerData._IndexKingDialogue == 10)
        {
            SetIndexKing(CurrentPawn, 11);
        }
        GetComponent<IActionnable>().Action(CurrentPawn, CurrentPawn._playerData._IndexKingDialogue);
    }

    public void SetIndexKing(Pawn CurrentPawn, int index)
    {
        CurrentPawn._playerData._IndexKingDialogue = index;
    }

    // Correction de la propriété VictoryScreen pour inclure au moins un accesseur
    private IEnumerator VictoryScreen(GameObject DialogueUI)
    {
        yield return new WaitUntil(() => DialogueUI == null || !DialogueUI);
        _UIVictoryMessage.SetActive(true);
    }
}
