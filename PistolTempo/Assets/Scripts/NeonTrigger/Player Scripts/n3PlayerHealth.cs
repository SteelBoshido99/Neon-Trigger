using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class n3PlayerHealth : MonoBehaviour
{
    private float cHealth;
    [SerializeField] private float lagTime;
    [SerializeField] private float mxHealth = 100f;
    [SerializeField] private float chipSpeed = 2f;
    [SerializeField] private Image frontBar;
    [SerializeField] private Image backBar;

    // Start is called before the first frame update
    void Start()
    {
        cHealth = mxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Ensures the player's HP doesn't fall below 0 and go above max HP
        cHealth = Mathf.Clamp(cHealth, 0, mxHealth);
        uiUpdate();

        if (Input.GetKeyDown(KeyCode.K))
        {
            TestDamage(Random.Range(2.0f, 10.0f));
        }
    }

    public void uiUpdate()
    {
        Debug.Log("You health is " + cHealth + "%");
        float frontFill = frontBar.fillAmount;
        float backFill = backBar.fillAmount;
        float hpFraction = cHealth / mxHealth;

        //This makes it so that when the player is damaged they can see how much damage they took as the Lerp funciton animates the image over time
        if(backFill > hpFraction)
        {
            frontBar.fillAmount = hpFraction;
            backBar.color = Color.red;
            lagTime += Time.deltaTime;
            float complete = lagTime / chipSpeed;
            backBar.fillAmount = Mathf.Lerp(backFill, hpFraction, complete);
        }
    }

    public void TestDamage(float damage)
    {
        cHealth -= damage;
        lagTime = 0f;
    }

}