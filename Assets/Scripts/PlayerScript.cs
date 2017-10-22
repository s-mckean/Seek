using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public GameObject[] collectable;
    private int itemsCollected = 0;
    public Text itemsText;

	// Use this for initialization
	void Start () {
        collectable = GameObject.FindGameObjectsWithTag("Collectable");
        Debug.Log(collectable);
        foreach (GameObject collect in collectable)
        {
            itemsCollected++;
        }

        itemsText.text = "Items Remaining: " + itemsCollected;
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
