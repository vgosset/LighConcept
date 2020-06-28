using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
        {
            other.transform.GetComponent<PlayerMovement>().ResetPos();
            MapGeneration.Instance.DelayedDeath();
        }
    }
}
