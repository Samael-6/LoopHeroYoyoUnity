using UnityEngine;
using System.Collections;

public class CellGraveyard : Cell
{
    [SerializeField] private GameObject _UIEquipmentMessage;

    public override void Activate(Pawn CurrentPawn)
    {
        if (!CurrentPawn._playerData._IsEquiped)
        {
            CurrentPawn._playerData._IsEquiped = true;
            CurrentPawn.SyncAndSave();
            StartCoroutine(ShowAndHide());
        }
    }

    private IEnumerator ShowAndHide()
    {
        _UIEquipmentMessage.SetActive(true);
        yield return new WaitForSeconds(2f);
        _UIEquipmentMessage.SetActive(false);
    }
}

