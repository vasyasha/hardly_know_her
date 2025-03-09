using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public static LogicScript instance;

    public static List<CardClass> currentDeck;
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
                    MakeAndPlaceNewDeck();
                }
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

    private void MakeAndPlaceNewDeck()
    {
        Debug.Log("MAKE NEW DECK");
    }
    
}
