using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameSession : MonoBehaviour
{
    public TMP_Text textTimer;
    public TMP_Text pointsText;
    public static int points;

    public float timer;
    public float timerMainMenu;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        timer = MainMenu.timer;
        DisplayTime();
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = points.ToString();
        timer -= Time.deltaTime;
        DisplayTime();
        if(timer <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
