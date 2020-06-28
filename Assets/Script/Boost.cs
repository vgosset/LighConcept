using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boost : MonoBehaviour
{
    [SerializeField] private GameObject light;
    [SerializeField] private LayerMask playerMastask;
    [SerializeField] private float radius;
    [SerializeField] private float speedBonus;
    [SerializeField] private float speedDelay;
    [SerializeField] private float respawnDelay;
    
    private MeshRenderer mesh;
    private bool active = true;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        PlayerDetection();
    }

    private void OnTriggerStay(Collider other)
    {
        if (active && other.transform.name == "Player")
        {
            other.transform.GetComponent<PlayerMovement>().SetSpeedBoost(speedBonus, speedDelay);
            mesh.enabled = false;
            StartCoroutine(Cor_Respawn());
        }
    }
    private IEnumerator Cor_Respawn()
    {
        active = false;
        yield return new WaitForSeconds(respawnDelay);
        mesh.enabled = true;
        active = true;
    }
    private void PlayerDetection()
    {
        Collider[] target = Physics.OverlapSphere(transform.position, radius, playerMastask);

        if (target.Length > 0)
        {
            SetActive();
        }
        else
            SetSleep();
    }
    private void SetSleep() 
    {
        light.SetActive(false);
    }
    private void SetActive() 
    {
        light.SetActive(true);
    }
}
