using System;
using UnityEngine;

public class CellSentinelle : Cell
{
    private Pawn _pawn = null;

    [SerializeField] private SceneLoader _sceneLoader;

    public override void Activate(Pawn currentPawn)
    {
        _pawn = currentPawn;

        // Retour du labyrinthe
        if (currentPawn._playerData._IsReturningFromSentinelle)
        {
            currentPawn._playerData._IsReturningFromSentinelle = false;
            _pawn._dice.RollDice();
            currentPawn.SyncAndSave();
            return;
        }

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

    private object Getcomponent<T>()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// À appeler juste avant de charger la scène du labyrinthe.
    /// Marque le retour en cours et sauvegarde pour survivre au changement de scène.
    /// </summary>
    public void OnEnterMiniGame()
    {
        _pawn._playerData._IsReturningFromSentinelle = true;
        _pawn.SyncAndSave();
        _sceneLoader.LoadNewScene();
    }
}
