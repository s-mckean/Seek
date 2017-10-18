using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject hidden;
    public Light gameLighting;
    private Color startColor;
    public Text timer;
    public float timeRemaining = 180f;

	// Use this for initialization
	void Start () {
        hidden.SetActive(false);
        startColor = gameLighting.color;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTimer();
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

    public void UpdateTimer()
    {
        string secondsText;
        int minutes = (int)timeRemaining /60;
        int seconds = (int)timeRemaining - (60 * minutes);
        secondsText = "" + seconds;
        if (seconds < 10) secondsText = "0" + seconds;
        timer.text = minutes + ":" + secondsText;
        timeRemaining -= Time.deltaTime;
    }
}
