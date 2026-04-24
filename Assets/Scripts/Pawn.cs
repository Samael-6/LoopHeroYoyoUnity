using System.Collections;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] public Board _board;
    [SerializeField] public GameObject _LooseScreen;
    [SerializeField] public Camera _camera;
    [SerializeField] public SaveManager _saveManager;
    [SerializeField] public Dice _dice;

    public int _IsDrogued = 0;
    public PlayerDatasStruct _playerData;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        _saveManager.LoadGame();
        _playerData = _saveManager.GetPlayerDatas();

        if (_playerData._IsEnding || _playerData._NumberOfActions == 0)
        {
            ResetPlayerData();
            _saveManager.SetPlayerDatas(_playerData);
            _saveManager.SaveGame();
        }

        MoveToCell();
        ActivateCell();
    }

    private void ResetPlayerData()
    {
        _playerData._IsBeginning = true;
        _playerData._IsEquiped = false;
        _playerData._IsEnding = false;
        _playerData._NumberOfActions = 100;
        _playerData._IndexSuspiciousWomanDialogue = 0;
        _playerData._IndexKingDialogue = 0;
        _playerData._cellNumber = 0;
    }
    private void MoveToCell()
    {
        Transform newPos = _board.GetCellByNumber(_playerData._cellNumber).transform;
        transform.position = newPos.position + new Vector3(0, 1, 0);
        transform.rotation = newPos.rotation;
    }

    public bool TryMoving(int value)
    {
        if (_playerData._NumberOfActions <= 0)
        {
            StartCoroutine(LooseScreen());
            return false;
        }

        _playerData._cellNumber = _board.GetNextCellToMove(_playerData._cellNumber + value);
        MoveToCell();
        ActivateCell();
        SyncAndSave();
        return true;
    }

    private void ActivateCell()
    {
        Cell cell = _board.GetCellByNumber(_playerData._cellNumber);
        cell.Activate(this);
    }

    public void SyncAndSave()
    {
        _saveManager.SetPlayerDatas(_playerData);
        _saveManager.SaveGame();
    }

    public IEnumerator LooseScreen()
    {
        _LooseScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }
}
