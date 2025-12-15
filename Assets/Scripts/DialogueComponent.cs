using UnityEngine;

public class DialogueComponent : MonoBehaviour, IActionnable
{
    [SerializeField] private DialogueDatas _dialogueData;
    private DialogueRow _currentRow;
    private int _currentRowIndex = 0;
    [SerializeField] private UIDialogueController _dialogueController;
    public void Action(Pawn CurrentPawn)
    {
        _currentRow = GetDialogueRow();
        _dialogueController.StartDialogue(this);
    }

    public DialogueRow GetDialogueRow()
    {
        return _dialogueData.rows[_currentRowIndex];
    }

    public string GetDialogueText()
    {
        return _currentRow.longDialogue;
    }

    public string GetCharacterName()
    {
        return _currentRow.characterName;
    }

    public Sprite GetCharacterImage()
    {
        return _currentRow.characterImage;
    }

    public void getNextRow()
    {
        if (_currentRow.NextRowNumber == - 1)
        {
            _dialogueController.EndDialogue();
        }
        else
        {
            _currentRowIndex = _currentRow.NextRowNumber;
            _currentRow = GetDialogueRow();
            _dialogueController.UpdateText();
        }
    }
}
