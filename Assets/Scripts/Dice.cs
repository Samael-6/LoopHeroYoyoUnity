using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private Pawn _pawn;

    /// <summary>Rolls the dice, moves the pawn, and persists the updated state.</summary>
    public void RollDice()
    {
        _pawn._playerData._NumberOfActions--;
        int value = Random.Range(1, 4);
        // TryMoving calls SyncAndSave internally on success.
        // If movement fails (actions == 0), sync the decremented count manually.
        if (!_pawn.TryMoving(value))
        {
            _pawn.SyncAndSave();
        }
    }
}
