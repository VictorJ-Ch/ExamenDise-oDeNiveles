using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryHolderController : MonoBehaviour
{
    public GameObject player;

    public float detectionRange = 5f;

    public KeyCode interactKey = KeyCode.E;
    public bool isPlayerInRange = false;
    
    private UIManager uiManager;


    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (player != null) 
        {
            PlayerInventory playerInventory = player.GetComponent<PlayerInventory>();

            if (playerInventory != null && playerInventory.hasKey)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);

                if (distance <= detectionRange)
                {
                    isPlayerInRange = true;
                    Debug.Log("Colocar bateria E");
                    uiManager.UpdatePanelState(true);

                }
                else
                {
                    isPlayerInRange = false;
                    uiManager.UpdatePanelState(false);
                }

                if (isPlayerInRange && Input.GetKeyDown(interactKey))
                {
                    PerformAction();
                }
            }
            else
            {
                Debug.LogWarning("El jugador no tiene la bateria.");
            }
        }
    }


    private void PerformAction()
    {
        Debug.Log("Has ganado");
        uiManager.UpdateWinOrLoose(true, false);
        Time.timeScale = 0;
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
