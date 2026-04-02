using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private PlayerDatas playerDatas;
    private SaveController saveController;

    private void Start()
    {
        saveController = new SaveController();
    }

    public void SaveGame()
    {
        saveController.SaveGameData(playerDatas.playerDatas, "savegame.txt");
    }

    public void LoadGame()
    {
        playerDatas.playerDatas = saveController.LoadGameData("savegame.txt");
    }
}
