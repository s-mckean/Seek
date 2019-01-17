using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject hidden;
    public Light gameLighting;
    private Color startColor;
    public Text timer;
    public Text LoseText;
    public Text WinText;
    private bool won = false;
    public float timeRemaining = 10f;
    public GameObject player;
    public GameObject collectablePrefab;
    public GameObject hiddenParent;
    public Image meter;
    public GameObject platformPrefab;

    private double perSecondDecrement;
    private double flatDecrement;
    private bool hiddenActive = false;
    private RectTransform meterRectTransform;
    private bool lose = false;
    private bool canHide = true;


    void Awake()
    {
        meterRectTransform = meter.GetComponent<RectTransform>();
        perSecondDecrement = meterRectTransform.rect.width * .01;
        flatDecrement = meterRectTransform.rect.width * .1;
        int numberofcubes = Random.Range(5, 7);
        for (int i = 0; i < numberofcubes; i++)
        {
            Vector3 position = new Vector3(Random.Range(146, 306), 21f, Random.Range(85, 286));
            Instantiate(collectablePrefab, position, Quaternion.identity, hiddenParent.transform);
        }
        StartCoroutine(UpdateHealthBar());
    }

    // Use this for initialization
    void Start () {
        hidden.SetActive(false);
        startColor = gameLighting.color;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeRemaining >= 0 && !won && !lose) { UpdateTimer(); }
        if (!lose) { Win(); }
        if (Input.GetMouseButtonDown(1) && canHide)
        {
            hiddenActive = true;
            hidden.SetActive(true);
            gameLighting.color = Color.black;
        }

        if (Input.GetMouseButtonUp(1) || !canHide)
        {
            hiddenActive = false;
            hidden.SetActive(false);
            gameLighting.color = startColor;
        }

        if (Input.GetMouseButtonDown(0) && meterRectTransform.rect.width - (float)flatDecrement >= 0 && !lose && !won)
        {
            SpawnPlatform();
            meterRectTransform.sizeDelta = new Vector2(meterRectTransform.rect.width - (float)flatDecrement, meterRectTransform.rect.height);
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
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

        if (timeRemaining < 0)
        {
            Lose();
        }
    }

    public void Lose()
    {
        LoseText.GetComponent<Text>().enabled = true;
        StartCoroutine(RestartGame());
        lose = true;
    }

    public void Win()
    {
        if (player.GetComponent<PlayerScript>().GetItemsCollected() == 0)
        {
            WinText.GetComponent<Text>().enabled = true;
            StartCoroutine(RestartGame());
            won = true;
        }
    }

    IEnumerator UpdateHealthBar()
    {
        while (true)
        {
            while (hiddenActive)
            {
                meter.GetComponent<RectTransform>().sizeDelta = new Vector2(meter.GetComponent<RectTransform>().rect.width - (float)perSecondDecrement, meterRectTransform.rect.height);
                if (meter.GetComponent<RectTransform>().rect.width <= 0) canHide = false;
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SpawnPlatform()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        float spawnDistance = 10;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        Instantiate(platformPrefab, new Vector3(spawnPos.x, 18.9f, spawnPos.z), playerRotation);
    }
}
