using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameobject : MonoBehaviour
{
    public Transform ToFollow
        {
            get { return toFollow; }

            set { toFollow = value; }
        }
    private Transform toFollow;
    public float MoveSpeed = 4;
    public float MaxDist = 10;
    public float MinDist = 5;


    // Update is called once per frame
    void Update()
    {
        if (ToFollow != null && Vector3.Distance(transform.position, ToFollow.position) >= MinDist)
        {
            transform.LookAt(ToFollow);// try to make this smoother

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, ToFollow.position) <= MaxDist)
            {

                //Here Call any function U want Like Shoot at here or something
            }
        }
    }


}
