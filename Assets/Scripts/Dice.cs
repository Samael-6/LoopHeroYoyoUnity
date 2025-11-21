using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private Pawn _pawn;

    public void RollDice()
    {
        int value = Random.Range(1, 7);
        Debug.Log($"Dice rolled: {value}");
        _pawn.TryMoving(value);
    }
}
