using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3_HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Update()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public float ReturnHealth()
    {
        return slider.value;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
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