using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogueController : MonoBehaviour
{
    [SerializeField] private DialogueComponent _dialogueComponent;
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private TMP_Text _characterNameText;
    [SerializeField] private Image _characterImage;
    private Cell _currentCell;

    public void StartDialogue(DialogueComponent dialogueComponent, Cell cell)
    {
        _dialogueComponent = dialogueComponent;
        _currentCell = cell;
        UpdateText();
        _dialoguePanel.SetActive(true);
    }

    public void ChangeRow()
    {
        _dialogueComponent.getNextRow();
    }

    public void UpdateText()
    {
        _dialogueText.text = _dialogueComponent.GetDialogueText();
        _characterNameText.text = _dialogueComponent.GetCharacterName();
        _characterImage.sprite = _dialogueComponent.GetCharacterImage();
    }

    public void EndDialogue()
    {
        _currentCell.GetComponent<IDialogueSetter>()?.SetIndex(_dialogueComponent._currentRowIndex);
        _dialoguePanel.SetActive(false);
    }
}
