using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreLabel;

    int score = 0;
    public int increment;

    public bool isStarted = false;
    public Image menu;
    public Button startButton;

    public static GameController instance;

    public void incrementScore()
    {
        score += increment;
        scoreLabel.text = "Score: " + score;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        startButton.onClick.AddListener(delegate
        {
            menu.gameObject.SetActive(false);
            startButton.gameObject.SetActive(false);
            isStarted = true;
        });
    }
}
