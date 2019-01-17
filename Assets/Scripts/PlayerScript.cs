using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public GameObject[] collectable;
    private int itemsCollected = 0;
    public Text itemsText;
    private Vector3 startPosition;

	// Use this for initialization
	void Awake () {
        startPosition = transform.position;
        collectable = GameObject.FindGameObjectsWithTag("Collectable");
        foreach (GameObject collect in collectable)
        {
            itemsCollected++;
        }

        itemsText.text = "Items Remaining: " + itemsCollected;

	}
	
    public void UpdateItemsCollected()
    {
        itemsCollected--;
        itemsText.text = "Items Remaining: " + itemsCollected;
    }

    public int GetItemsCollected()
    {
        return itemsCollected;
    }

    public void ResetPlayersPosition()
    {
        transform.position = startPosition;
    }
}
