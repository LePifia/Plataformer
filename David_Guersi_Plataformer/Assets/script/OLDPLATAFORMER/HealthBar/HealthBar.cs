using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void Start()
    {
        
    }
    public void SetMaxHealth (int Health)
    {

        slider.maxValue = Health;
        slider.value = Health;

        fill.color = gradient.Evaluate(1f);
    }
   
    
    public void SetHealth(int Health)
    {
        slider.value = Health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


}
