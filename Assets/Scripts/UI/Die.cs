using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public GameObject player;

    private UIManager uiManager;


    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Chocando con: " + other);
        if (other.gameObject == player)
        {
            Debug.LogWarning("Player se ha caido");
            uiManager.UpdateWinOrLoose(false, true);
            Time.timeScale = 0;
        }
    }
}