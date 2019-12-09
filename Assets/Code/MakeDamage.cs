using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour
{
    //see how to show once of both
    [SerializeField] private int damageMade;
    [SerializeField] private bool instaKill;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (!player.IsDashing)
            {
                if (instaKill)
                {
                    player.die();
                }
                else
                {
                    player.TakeDamage(damageMade);
                }
            }
        }
    }
}
