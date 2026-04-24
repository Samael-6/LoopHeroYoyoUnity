using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CellTavernier : MonoBehaviour
{
    [SerializeField] private GameObject _memory;

    public void StartMiniGame(Pawn pawn)
    {
        pawn._dice.GetComponent<Canvas>().enabled = false;
        _memory.SetActive(true);
        _memory.GetComponent<MemoryGame>().StartMemoryGame();
    }
}
