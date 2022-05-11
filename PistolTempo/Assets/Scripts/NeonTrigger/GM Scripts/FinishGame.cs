using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
   [SerializeField] private GameObject youWinUI;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            youWinUI.SetActive(true);
        }
    }
}
