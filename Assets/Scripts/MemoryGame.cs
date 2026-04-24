using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGame : MonoBehaviour
{
    private int NbRevealedCards = 0;
    private int round = 3;
    private List<int> revealedCardIndex = new List<int>();
    private List<int> revealedCardsIndexTemp = new List<int>();

    [SerializeField] List<Button> _cards;
    [SerializeField] List<Image> _cardFaces;
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void StartMemoryGame()
    {
        revealedCardIndex = new List<int>();
        revealedCardsIndexTemp = new List<int>();
        NbRevealedCards = 0;
        round = 3;

        foreach (Button card in _cards)
        {
            Image cardImage = card.gameObject.GetComponentInChildren<Image>();
            Color tempColor = cardImage.color;
            tempColor.a = 1f;
            cardImage.color = tempColor;
        }

        Debug.Log("Memory Game Started!");
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void EndMemoryGame()
    {
        // Code to end the memory game goes here
        gameObject.SetActive(false);
        Debug.Log("Memory Game Ended!");
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void RevealCard(int cardIndex)
    {
        Image cardImage = _cards[cardIndex].gameObject.GetComponentInChildren<Image>();
        Color tempColor = cardImage.color;

        if ((IsRevealedCard(cardIndex)))
        {
            tempColor.a = 0f;
            cardImage.color = tempColor;
            NbRevealedCards++;

            revealedCardsIndexTemp.Add(cardIndex);
            revealedCardIndex.Add(cardIndex);

            if (NbRevealedCards >= 3)
            {
                if (IsWinningConditionMet())
                {
                    Debug.Log("You win!");
                    EndMemoryGame();
                }
                else
                {
                    if (_cardFaces[revealedCardsIndexTemp[0]].sprite.name == _cardFaces[revealedCardsIndexTemp[1]].sprite.name &&
                        _cardFaces[revealedCardsIndexTemp[1]].sprite.name == _cardFaces[revealedCardsIndexTemp[2]].sprite.name)
                    {
                        NbRevealedCards = 0;
                        revealedCardsIndexTemp.Clear();
                        return;
                    }

                    StartCoroutine(HideCardsAfterDelay());
                    round--;

                    if (round <= 0)
                    {
                        Debug.Log("Game Over!");
                        EndMemoryGame();
                    }
                }
            }
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private IEnumerator HideCardsAfterDelay()
    {
        foreach (Button card in _cards)
            card.interactable = false;

        yield return new WaitForSeconds(2f);

        foreach (int idx in revealedCardsIndexTemp)
        {
            Image img = _cards[idx].gameObject.GetComponentInChildren<Image>();
            Color c = img.color;
            c.a = 1f;
            img.color = c;
        }

        NbRevealedCards = 0;
        revealedCardsIndexTemp.Clear();

        foreach (Button card in _cards)
            card.interactable = true;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool IsWinningConditionMet()
    {
        foreach (Button card in _cards)
        {
            Image cardImage = card.gameObject.GetComponentInChildren<Image>();
            if (cardImage.color.a > 0f) return false;
        }
        return true;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool IsRevealedCard(int cardIndex)
    {
        return _cards[cardIndex].GetComponentInChildren<Image>().color.a > 0;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool CheckNbRevealedCards()
    {
        return NbRevealedCards == 3;
    }
}