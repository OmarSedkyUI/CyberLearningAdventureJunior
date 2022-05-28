using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1_HealthBar : MonoBehaviour
{
    public Slider slider;

    public float ReturnHealth()
    {
        return slider.value;
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

    public void IncHealth(int health)
    {
        slider.value += health;
    }

    public void DecHealth(float health)
    {
        slider.value -= health;
    }
}
