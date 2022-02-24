using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarSlider : MonoBehaviour
{

    public Slider slider;
    public TextMeshProUGUI textoVida;
    public HealthDamage healthDamage;

    void Update()
    {
        textoVida.text = healthDamage.vidaP + "/" + healthDamage.maxHealth; 
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
