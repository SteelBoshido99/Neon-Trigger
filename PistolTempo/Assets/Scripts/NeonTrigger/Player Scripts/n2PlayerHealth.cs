using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class n2PlayerHealth : MonoBehaviour
{
    [SerializeField] private Text healthDisplay;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image[] healhPoints;

    [SerializeField] private float cHealth, mxHealth = 100;


    private void Start()
    {
        cHealth = mxHealth;
        healthDisplay.text = "Current Health is: " + cHealth + "%";
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TestDamage(10.0f);

        }

    }

    void healthFiller()
    {
        healthBar.fillAmount = cHealth / mxHealth;
    }

    void TestDamage(float damage)
    {
        if(cHealth > 0)
        {
            cHealth -= damage;
            healthDisplay.text = "Current Health is: " + cHealth + "%";
        }
        
    }


}
