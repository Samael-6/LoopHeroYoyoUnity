using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static readonly string SaveFilename = "savegame.txt";

    [SerializeField] private PlayerDatas playerDatas;
    private SaveController saveController;

    private void Awake()
    {
        saveController = new SaveController();
    }

    public void SaveGame()
    {
        saveController.SaveGameData(playerDatas.playerDatas, SaveFilename);
    }

    public void LoadGame()
    {
        playerDatas.playerDatas = saveController.LoadGameData(SaveFilename);
    }

    public PlayerDatasStruct GetPlayerDatas()
    {
        return playerDatas.playerDatas;
    }

    public void SetPlayerDatas(PlayerDatasStruct data)
    {
        playerDatas.playerDatas = data;
    }
}
