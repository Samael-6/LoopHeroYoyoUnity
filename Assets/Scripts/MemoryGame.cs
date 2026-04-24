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
    private Pawn _pawn;

    [SerializeField] List<Button> _cards;
    [SerializeField] List<Image> _cardFaces;
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void StartMemoryGame(Pawn pawn)
    {
        revealedCardIndex = new List<int>();
        revealedCardsIndexTemp = new List<int>();
        NbRevealedCards = 0;
        round = 3;
        _pawn = pawn;
        ResetAllCards();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void ResetAllCards()
    {
        foreach (Button card in _cards)
        {
            card.interactable = true;
            Image cardImage = card.gameObject.GetComponentInChildren<Image>();
            Color tempColor = cardImage.color;
            tempColor.a = 1f;
            cardImage.color = tempColor;
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void EndMemoryGame()
    {
        _pawn._IsDrogued = 3-round;
        StopAllCoroutines();
        ResetAllCards();
        gameObject.SetActive(false);
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