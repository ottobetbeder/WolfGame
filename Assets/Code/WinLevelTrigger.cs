using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevelTrigger : MonoBehaviour
{
    public System.Action PlayerWon;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && PlayerWon != null)
        {
            PlayerWon();
        }
    }
}
