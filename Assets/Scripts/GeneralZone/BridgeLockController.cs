using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeLockController : MonoBehaviour
{
    public GameObject player;
    public GameObject bridgeWall;
    public GameObject caveZone;
    public GameObject generalZone;
    public GameObject bridgeZone;
    public GameObject miniGameZoneWall;

    public float detectionRange = 5f;
    public float bridgeDuration = 10f;

    public KeyCode interactKey = KeyCode.E;
    public bool isPlayerInRange = false;


    private UIManager uiManager;



    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        bridgeWall.SetActive(true);
        miniGameZoneWall.SetActive(false);

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
                    Debug.Log("Colocar llave E");
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
                Debug.LogWarning("El jugador no tiene el componente 'PlayerInventory' o no tiene la llave.");
            }
        }
        else
        {
            Debug.LogError("El objeto 'player' no está asignado en el inspector.");
        }
    }



    private void PerformAction()
    {
        Debug.Log("El puente esta abierrto");
        bridgeWall.SetActive(false);
        StartCoroutine(CloseBridge());
        uiManager.UpdatePanelState(false);
    }


    private IEnumerator CloseBridge()
    {
        Debug.Log($"Cruza el puente: {bridgeDuration} segundos");
        yield return new WaitForSeconds(bridgeDuration);
        bridgeWall.SetActive(true);
        bridgeZone.SetActive(false);
        caveZone.SetActive(false);
        generalZone.SetActive(false);
        miniGameZoneWall.SetActive(true);
        Debug.LogWarning("Time's Up");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
