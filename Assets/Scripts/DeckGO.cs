using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckGO : MonoBehaviour
{
    public CardGO cardGOTemplate;
    private Stack<CardGO> currentDeck;
    private readonly int[] numArray = Enumerable.Range(1, 13).ToArray();
    private readonly char[] suitArray = { 'c', 'd', 'h', 's' };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateDeck(bool shuffled = true)
    {
        Stack<CardGO> newDeck = new();
        CardGO newCard;
        foreach (char suit in suitArray)
        {
            foreach (int num in numArray)
            {
                newCard = Instantiate(cardGOTemplate);
                newCard.Initialize(suit, num, false);
                newDeck.Push(newCard);
            }
        }
        if (shuffled)
        {
           
        }
        this.currentDeck = newDeck;
    }
    public void DrawCard()
    {
        CardGO currentCard;
        currentCard = this.currentDeck.Pop();
        Vector3 newPosition = new(gameObject.transform.position.x + 5, gameObject.transform.position.y, gameObject.transform.position.z);
        currentCard.transform.position = newPosition;
        currentCard.gameObject.SetActive(true);
    }
}
