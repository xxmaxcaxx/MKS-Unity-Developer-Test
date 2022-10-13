using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public Button ButtonPlayAgain;
    public Button ButtonMainMenu;
    public TMP_Text points;

    // Start is called before the first frame update
    void Start()
    {
        Button bpa = ButtonPlayAgain.GetComponent<Button>();
        bpa.onClick.AddListener(PLayAgainOnClick);

        Button bmn = ButtonMainMenu.GetComponent<Button>();
        bmn.onClick.AddListener(MainMenuOnClick);

        points.text = GameSession.points.ToString();
    }

    void PLayAgainOnClick()
    {
        SceneManager.LoadScene("Game");
    }

    void MainMenuOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
