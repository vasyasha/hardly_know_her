using UnityEngine;
using DG.Tweening;
using UnityEditor.Tilemaps;
using System;
using System.Linq;

public class CardGO : MonoBehaviour
{
    private bool revealed = false;
    public GameObject cardFront;
    private string cardSuitNum;
    private char cardSuit;
    private int cardNum;
    private readonly char[] allowedSuits = { 'c', 'd', 'h', 's' };
    private static int blankCardCount = 0;
// Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Initialize(string cardSuitNum, bool isActive = true)
    {
        char cardSuit = cardSuitNum[0];
        int cardNum;
        if (Int32.TryParse(cardSuitNum[1..], out int parsedCardNum))
        {
            cardNum = parsedCardNum;
        }
        else
        {
            Console.WriteLine($"Card String could not be parsed: {cardSuitNum}, setting to 0");
            cardNum = 0;
        }
        Initialize(cardSuit, cardNum, isActive);
    }

    public void Initialize(char cardSuit, int cardNum, bool isActive = true)
    {
        
        if (allowedSuits.Contains(cardSuit) && cardNum > 0 && cardNum < 14)
        {
            this.cardSuit = cardSuit;
            this.cardNum = cardNum;
            this.cardSuitNum = $"{cardSuit}{cardNum}";
            gameObject.name = $"{this.cardSuitNum} Card";
            // render the correct card
        }
        else
        {
            this.cardSuit = 'b';
            this.cardNum = 0;
            this.cardSuitNum = $"{cardSuit}{cardNum}";
            gameObject.name = $"Blank Card {blankCardCount}";
            blankCardCount += 1;
            // render blank card
        }


        gameObject.SetActive(isActive);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FlipCard()
    {
        revealed = !revealed;
        Debug.Log($"Revealed state: {revealed}, card is {this.cardSuitNum}");
        transform.DORotate(new Vector3(0, revealed ? 180f : 0f, 0), 0.25f);
    }
}
