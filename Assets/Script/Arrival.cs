using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrival : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
        {
            other.transform.GetComponent<PlayerMovement>().ResetPos();
            other.transform.GetComponent<PlayerMovement>().SetActive();
            MapGeneration.Instance.NextLevel();
        }
        
    }
}
