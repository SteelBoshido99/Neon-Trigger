using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHp;

    [SerializeField] private hbController healBar;

    public int getMaxHp()
    {
        return maxHealth;
    }

    public void setMaxHp(int mxHealth)
    {
        maxHealth = mxHealth;
    }

    public int getCutrrentHp()
    {
        return currentHp;
    }

    public void setCurrentHp(int thisHealth)
    {
        currentHp = thisHealth;
    }


    void Start()
    {
        currentHp = maxHealth;
        //hbController.setMaxHp(maxHealth);
    }

    
    void Update()
    {
        //This is to test the health bar
        if (Input.GetKeyDown(KeyCode.K))
        {
            TestDamage(10);
        }
    }

    //This is to test the health bar
    void TestDamage(int damage)
    {
        currentHp -= damage;
        //hbController.UpdateHp(currentHp);
    }

}
