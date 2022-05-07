using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hbController : MonoBehaviour
{

    //This will control the set slider, in this case a health bar
    [SerializeField] private Slider hpSlider;



    //This is to ensure that when the game starts the player has maximum HP
    public void setMaxHp(int maxHp)
    {
        hpSlider.maxValue = maxHp;
        hpSlider.value = maxHp;
    }


    //When this function is called it updates the player 
    public void UpdateHp(int cHealth)
    {
        hpSlider.value = cHealth;
    }
}
