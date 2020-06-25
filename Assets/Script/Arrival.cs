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
            SceneManager.LoadScene("Gameplay1");
    }
}
