using UnityEngine;

public class BttnPlayerRange : MonoBehaviour
{
    public GameObject player;
    public GameObject bridgeKey;
    public float detectionRange = 5f;
    public KeyCode interactKey = KeyCode.E;
    public bool isPlayerInRange = false;

    void Start()
    {
        bridgeKey.SetActive(false);
    }
    void Update()
    {
        if (player != null)
        {
            float distance  = Vector3.Distance(transform.position, player.transform.position);

            if(distance <= detectionRange)
            {
                isPlayerInRange = true;
                Debug.Log("Press E");
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
        Debug.Log("Bttn pulsado");
        bridgeKey.SetActive(true);
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
