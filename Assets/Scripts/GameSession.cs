using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public TMP_Text textTimer;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        DisplayTime();
    }

    // Update is called once per frame
    void Update()
    {
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
