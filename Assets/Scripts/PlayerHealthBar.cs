using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private Image HealthBar;
    private float MaxHealth;

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 90.0f;
        HealthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = PlayerControler.Health / MaxHealth;
    }
}
