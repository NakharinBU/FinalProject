using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void UpdateHealthBar(float currentHealth) 
    {
        float maxValue = slider.maxValue;
        slider.value = Mathf.Clamp(currentHealth, 0, maxValue);
    }

    public void SetMaxHealth(float maxHealth) 
    {
        slider.maxValue = maxHealth;
    }


}
