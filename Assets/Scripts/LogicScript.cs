using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public static LogicScript instance;

    public DeckGO deckGOTemplate;

    private static DeckGO currentDeck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // The following chunk deals with left clicks on the field
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("LMB CLICK");
            // Check if GO detected
            GameObject clickedGO = DetectGOFromMousePosition();
            if (clickedGO != null)
            {
                // Implement for deck placeholder
                if (clickedGO.CompareTag("DeckPlaceholder"))
                {
                    MakeAndPlaceNewDeck(clickedGO.transform.position, clickedGO.transform.rotation);
                }
                if (clickedGO.CompareTag("PlayingCard"))
                {
                    clickedGO.GetComponent<CardGO>().FlipCard();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentDeck != null) {
                currentDeck.DrawCard();
            }
        }
    }

    private GameObject DetectGOFromMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
            {
                return hit.collider.gameObject;
            }
        return null;
    }

    private void MakeAndPlaceNewDeck(Vector3 position, Quaternion rotation)
    {
        Debug.Log("MAKE NEW DECK");
        currentDeck = Instantiate(deckGOTemplate, position, rotation);
    }
    
}
