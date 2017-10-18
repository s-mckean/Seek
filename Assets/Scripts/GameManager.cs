using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject hidden;
    public Light gameLighting;
    private Color startColor;

	// Use this for initialization
	void Start () {
        hidden.SetActive(false);
        startColor = gameLighting.color;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            hidden.SetActive(true);
            gameLighting.color = Color.black;
        }

        if (Input.GetMouseButtonUp(1))
        {
            hidden.SetActive(false);
            gameLighting.color = startColor;
        }
	}

    
}
