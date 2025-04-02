using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaterryController : MonoBehaviour
{
    public GameObject player;
    public float detectionRange = 5f;
    public KeyCode interactKey = KeyCode.E;
    public bool isPlayerInRange = false;

    void Update()
    {
        if (player != null)
        {
            float distance  = Vector3.Distance(transform.position, player.transform.position);

            if(distance <= detectionRange)
            {
                isPlayerInRange = true;
                Debug.Log("Recoger la bateria E");
            }
            else
            {
                isPlayerInRange = false;
            }



            if(isPlayerInRange && Input.GetKeyDown(interactKey))
            {
                PerformAction();
            }
        }
    }

    private void PerformAction()
    {
        Debug.Log("Tenes la bateria");
        player.GetComponent<PlayerInventory>().hasBatery = true;
        gameObject.SetActive(false);
        
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
