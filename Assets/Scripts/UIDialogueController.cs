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
    public void StartDialogue(DialogueComponent dialogueComponent)
    {
        _dialogueComponent = dialogueComponent;
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
        _dialoguePanel.SetActive(false);
    }
}
