using UnityEngine;
using DG.Tweening;
using UnityEditor.Tilemaps;
using System;
using System.Linq;

public class CardClass : MonoBehaviour
{
    private bool revealed = false;
    public GameObject cardFront;
    public string cardSuitNum;
    public char cardSuit;
    public int cardNum;
    private char[] allowedSuits = { 'c', 'd', 'h', 's' };
// Start is called once before the first execution of Update after the MonoBehaviour is created
public CardClass(char cardSuit, int cardNum)
    {
        Initialize(cardSuit, cardNum);
    }
    public CardClass(string cardSuitNum)
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
        Initialize(cardSuit, cardNum);
    }

    private void Initialize(char cardSuit, int cardNum)
    {
        
        if (allowedSuits.Contains(cardSuit) && cardNum > 0 && cardNum < 14)
        {
            this.cardSuit = cardSuit;
            this.cardNum = cardNum;
            this.cardSuitNum = $"{cardSuit}{cardNum}";
            // render the correct card
        }
        else
        {
            this.cardSuit = 'b';
            this.cardNum = 0;
            this.cardSuitNum = $"{cardSuit}{cardNum}";
            // render blank card
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FlipCard();
        } 
    }
    public void FlipCard()
    {
        revealed = !revealed;
        Debug.Log($"Revealed state: {revealed}");
        transform.DORotate(new Vector3(0, revealed ? 180f : 0f, 0), 0.25f);
    }
}
