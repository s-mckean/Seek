using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesScript : MonoBehaviour {


	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
	    
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().UpdateItemsCollected();
            Destroy(gameObject);
        }
    }
}
