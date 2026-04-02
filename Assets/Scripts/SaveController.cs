using UnityEngine;
using System.IO;


public struct PlayerDatasStruct
{
    public int _cellNumber;
    public int _IndexKingDialogue;
    public int _IndexSuspiciousWomanDialogue;
    public int _NumberOfActions;
    public bool _IsEquiped;
    public bool _IsBeginning;
    public bool _IsEnding;
    public bool _IsDrunk;
}

public class SaveController
{
    public bool SaveGameData(PlayerDatasStruct playerDatas, string filename)
    {
        string data = JsonUtility.ToJson(playerDatas);
        string path = Application.persistentDataPath + "/" + filename;
        
        if(File.Exists(path))
        {
            File.Delete(path);
        }
        File.WriteAllText(path, data);
        return false;
    }
    public PlayerDatasStruct LoadGameData(string filename)
    {
        PlayerDatasStruct playerDatas = new PlayerDatasStruct();
        string path = Application.persistentDataPath + "/" + filename;

        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            playerDatas = JsonUtility.FromJson<PlayerDatasStruct>(data);
        }
        else 
        {
            SaveGameData(playerDatas, filename);
        }

            return playerDatas;
    }
}
