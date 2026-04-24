using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CellTavernier : MonoBehaviour
{
    [SerializeField] private GameObject _memory;
    [SerializeField] private Pawn _pawn;

    public void StartMiniGame()
    {
        _memory.SetActive(true);
        _memory.GetComponent<MemoryGame>().StartMemoryGame(_pawn);
    }
}
