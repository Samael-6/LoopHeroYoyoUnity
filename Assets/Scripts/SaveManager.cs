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

    /// <summary>Persists the current player data to disk.</summary>
    public void SaveGame()
    {
        saveController.SaveGameData(playerDatas.playerDatas, SaveFilename);
    }

    /// <summary>Loads player data from disk into the ScriptableObject.</summary>
    public void LoadGame()
    {
        playerDatas.playerDatas = saveController.LoadGameData(SaveFilename);
    }

    /// <summary>Returns the currently loaded player data struct.</summary>
    public PlayerDatasStruct GetPlayerDatas()
    {
        return playerDatas.playerDatas;
    }

    /// <summary>Writes an updated struct back into the ScriptableObject before saving.</summary>
    public void SetPlayerDatas(PlayerDatasStruct data)
    {
        playerDatas.playerDatas = data;
    }
}
