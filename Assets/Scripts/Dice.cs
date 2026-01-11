using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private Pawn _pawn;

    public void RollDice()
    {
        int value = Random.Range(1, 4);
        _pawn.TryMoving(value);
    }
}
