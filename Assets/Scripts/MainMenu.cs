using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public static float timer;
    public static float spawnTime;
    public string spawnString;
    public Slider mySlider;
    public TMP_InputField mainInputField;

    private void Start()
    {
        mainInputField.onValueChanged.AddListener(UpdateInputField);
    }

    void UpdateInputField(string data)
    {
        spawnTime = float.Parse(data);
    }

    void Update()
    {
        timer = mySlider.value;
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene("Game");
    }
}