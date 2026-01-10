using UnityEngine;



[System.Serializable]
public struct DialogueRow
{
    public string characterName;
    public string longDialogue;
    public int NextRowNumber;
    public Sprite characterImage;
}

[CreateAssetMenu(fileName = "DialogueDatas", menuName = "Scriptable Objects/DialogueDatas")]
public class DialogueDatas : ScriptableObject
{
    public DialogueRow[] rows;
}
