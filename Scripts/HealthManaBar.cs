using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManaBar : MonoBehaviour
{
    public Slider sliderMana;
    public Slider sliderHealth;
    public void SetMaxMana(float mana)
    {
        sliderMana.maxValue = mana;
        sliderMana.value = mana;
    }
   public void SetMana(float mana)
    {
        sliderMana.value = mana;    
    }
    public void SetMaxHealth(float health)
    {
        sliderHealth.maxValue = health;
    }
    public void SetHealth(float health)
    {
        sliderHealth.value = health;
    }

}
