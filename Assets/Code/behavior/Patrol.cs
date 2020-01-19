using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public float startWaitTime;

    public bool ShouldPatrol = false;
    public bool ShouldFaceWalkingPos = true;

    //This is for premade Patrol points
    public  List<Transform> MoveSpots;
    private int randomSpot;

    //This is for Random Patrol points
    private Vector3 Spot;
    public float minX;
    public float minZ;
    public float maxX;
    public float maxZ;

    private float offset = 10;

    // Start is called before the first frame update
    void Start()
    {
        if(MoveSpots.Count == 0)
        {
            if (minX == 0)
            {
                minX = this.transform.position.x - offset;
            }
            if (minZ == 0)
            {
                minZ = this.transform.position.z - offset;
            }
            if (maxX == 0)
            {
                maxX = this.transform.position.x + offset;
            }
            if (maxZ == 0)
            {
                maxZ = this.transform.position.z + offset;
            }
            Spot = new Vector3(Random.Range(minX, maxX), this.transform.position.y, Random.Range(minZ, maxZ)); 
        }
        else
        {
            randomSpot = Random.Range(0, MoveSpots.Count);
        }
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldPatrol)
        {
            if (MoveSpots.Count == 0)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, Spot, speed * Time.deltaTime);
                if (ShouldFaceWalkingPos)
                {
                    this.transform.LookAt(Spot);// try to make this smoother
                }

                if (Vector3.Distance(transform.position, Spot) < 0.2f)
                {
                    if (waitTime <= 0)
                    {
                        Spot = new Vector3(Random.Range(minX, maxX), this.transform.position.y, Random.Range(minZ, maxZ));
                        waitTime = startWaitTime;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(transform.position, MoveSpots[randomSpot].position, speed * Time.deltaTime);
                if (ShouldFaceWalkingPos)
                {
                    this.transform.LookAt(MoveSpots[randomSpot].position);// try to make this smoother
                }

                if (Vector3.Distance(transform.position, MoveSpots[randomSpot].position) < 0.2f)
                {
                    if (waitTime <= 0)
                    {
                        randomSpot = Random.Range(0, MoveSpots.Count);
                        waitTime = startWaitTime;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
            }
        }
    }
}
