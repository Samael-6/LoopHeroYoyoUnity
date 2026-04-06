using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Pawn : MonoBehaviour
{
    [SerializeField] public Board _board;
    [SerializeField] public PlayerDatasStruct _playerData;
    [SerializeField] public GameObject _LooseScreen;
    [SerializeField] public Camera _camera;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        if (_playerData._IsEnding || _playerData._NumberOfActions == 0)
        {
            _playerData._IsBeginning = true;
            _playerData._IsEquiped = false;
            _playerData._IsEnding = false;
            _playerData._NumberOfActions = 100;
            _playerData._IndexSuspiciousWomanDialogue = 0;
            _playerData._IndexKingDialogue = 0;
            _playerData._cellNumber = 0;
        }
        MoveToCell();
        ActivateCell();
    }
    private void MoveToCell()
    {
        Transform NewPos = _board.GetCellByNumber(_playerData._cellNumber).transform; // TODO : get cell number from PlayerDatas
        transform.position = (NewPos.position);
        transform.position += new Vector3(0, 1, 0); // To be above the cell
        transform.rotation = NewPos.rotation;
    }

    public bool TryMoving(int value)
    {
        if (_playerData._NumberOfActions <= 0)
        {
            StartCoroutine(LooseScreen());
            return false;
        }
        else
        {
            _playerData._cellNumber = _board.GetNextCellToMove(_playerData._cellNumber + value);
            MoveToCell();
            ActivateCell();
            return true;
        }
    }

    private void ActivateCell()
    {
        Cell cell = _board.GetCellByNumber(_playerData._cellNumber);
        cell.Activate(this);
    }

    public IEnumerator LooseScreen()
    {
        _LooseScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }
}
