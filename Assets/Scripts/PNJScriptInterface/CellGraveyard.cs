using UnityEngine;
using System.Collections;
using static UnityEngine.Rendering.DebugUI;

public class CellGraveyard : Cell
{
    [SerializeField] private GameObject _UIEquipmentMessage;

    public override void Activate(Pawn CurrentPawn)
    {
        if (!(CurrentPawn._playerData._IsEquiped))
        {
            StartCoroutine(ShowAndHide());
            CurrentPawn._playerData._IsEquiped = true;
        }

    }

    private IEnumerator ShowAndHide()
    {
        _UIEquipmentMessage.SetActive(true);
        yield return new WaitForSeconds(2f);
        _UIEquipmentMessage.SetActive(false);
    }
}
