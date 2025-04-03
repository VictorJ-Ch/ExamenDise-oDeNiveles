using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;

    public float detectionRange = 5f;
    public float enemyVelocity = 5f;

    public bool isPlayerInRange = false;
    public bool isEnemyChasing = false;

    private UIManager uiManager;


    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }


    void Update()
    {
        if(player != null)
        {
            float distance  = Vector3.Distance(transform.position, player.transform.position);

            if(distance <= detectionRange)
            {
                isPlayerInRange = true;
                isEnemyChasing = true;
                Debug.Log("El enemigo esta cazando al jugador");
                isEnemyChasing = true;

                LookAtPlayer();
                EnemyChasing();
            }
            else
            {
                isPlayerInRange = false;
            }
        }
    }


    private void LookAtPlayer()
    {
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void EnemyChasing()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemyVelocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collison)
    {
        if(collison.gameObject == player)
        {
            Debug.LogWarning("Has perdido");
            uiManager.UpdateWinOrLoose(false, true);
            Time.timeScale = 0;
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
