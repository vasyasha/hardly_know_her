using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    public static List<CardClass> currentDeck;
    private int[] numArray = Enumerable.Range(1, 13).ToArray();
    private char[] suitArray = { 'c', 'd', 'h', 's' };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<CardClass> MakeNewDeck(bool shuffled = true)
    {
        List<CardClass> newDeck = new();
        foreach (char suit in suitArray)
        {
            foreach (int num in numArray)
            {
                newDeck.Add(new CardClass(suit, num));
            }
        }
        if (shuffled)
        {
           
        }
        return newDeck;
    }
}
