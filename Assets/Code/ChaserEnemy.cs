using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    public Patrol patrolBehaviour;
    public See seeBehaviour;
    public FollowGameobject followBehaviour;


    // Start is called before the first frame update
    void Start()
    {
        seeBehaviour.TagToLookFor = "Player";
        seeBehaviour.ObjectSeen += PlayerSeen;
        seeBehaviour.ObjectLost += PlayerLost;
        patrolBehaviour.ShouldPatrol = true; //here I can set the patrol options
    }

    private void PlayerSeen(GameObject player)
    {
        patrolBehaviour.ShouldPatrol = false;
        followBehaviour.ToFollow = player.transform;
    }

    private void PlayerLost(GameObject player)
    {
        patrolBehaviour.ShouldPatrol = true;
        followBehaviour.ToFollow = null;
    }

    void Update()
    {
        if (followBehaviour.ToFollow == null)
        {
            patrolBehaviour.ShouldPatrol = true;
        }
    }
}
