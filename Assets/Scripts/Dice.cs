using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private Pawn _pawn;

    public void RollDice()
    {
        _pawn._playerData._NumberOfActions--;
        int value = Random.Range(1, 4);
        _pawn.TryMoving(value);
    }
}
