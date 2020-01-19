using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class See : MonoBehaviour
{
    public System.Action<GameObject> ObjectSeen;
    public System.Action<GameObject> ObjectLost;
    public string TagToLookFor
    {
        get { return tagToLookFor; }

        set { tagToLookFor = value; }
    }
    private string tagToLookFor;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagToLookFor) && ObjectSeen != null)
        {
            ObjectSeen(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(tagToLookFor) && ObjectLost != null)
        {
            ObjectLost(other.gameObject);
        }
    }
}
