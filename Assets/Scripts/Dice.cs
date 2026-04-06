using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private Pawn _pawn;
    [SerializeField] private SaveManager _saveManager;

    public void RollDice()
    {
        _pawn._playerData._NumberOfActions--;
        int value = Random.Range(1, 4);
        if (_pawn.TryMoving(value))
        {
            _saveManager.SaveGame();
        }
    }
}
