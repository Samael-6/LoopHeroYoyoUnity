using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGame : MonoBehaviour
{
    private int _NbRevealedCards = 0;
    [SerializeField] List<Button> _cards;


    public void StartMemoryGame()
    {
        // Code to start the memory game goes here
        Debug.Log("Memory Game Started!");
    }

    public void EndMemoryGame()
    {
        // Code to end the memory game goes here
        Debug.Log("Memory Game Ended!");
    }

    public void RevealCard()
    {
        if (CheckNbRevealedCards())
        {

        }
    }

    public bool IsWinningConditionMet()
    {
        // Code to check if the winning condition is met goes here
        return false;
    }

    public bool CheckNbRevealedCards()
    {
        return _NbRevealedCards == 3;
    }
}
