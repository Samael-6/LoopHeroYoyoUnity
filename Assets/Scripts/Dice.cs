using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private Pawn _pawn;
    
    public void RollDice()
    {
        _pawn._playerData._NumberOfActions--;
        int value = Random.Range(1, 3);
        if (_pawn._IsDrogued > 0)
        {
            _pawn._IsDrogued--;
            value = 1;
        }
        if (!_pawn.TryMoving(value))
        {
            _pawn.SyncAndSave();
        }
    }
}
