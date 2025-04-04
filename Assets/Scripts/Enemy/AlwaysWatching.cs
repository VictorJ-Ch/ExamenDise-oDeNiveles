using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysWatching : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player.transform.position);
        }
    }
}
