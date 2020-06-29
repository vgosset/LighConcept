using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCannon : MonoBehaviour
{
    [SerializeField] private Transform boxCenter;
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private LayerMask playerMask;

    private Light light;
    private Animator anim;
    private bool fireOn = false;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        light = transform.GetChild(0).transform.GetChild(0).GetComponent<Light>();
    }
    void Update()
    {
        PlayerDetection();
    }
    private void PlayerDetection()
    {
        Collider[] target = Physics.OverlapBox(boxCenter.position, boxSize, Quaternion.identity, playerMask);

        if (!fireOn && target.Length > 0)
        {
            SetActive();
        }
    }
    public void SetActive()
    {
        fireOn = true;
        anim.SetTrigger("FireCannon");
    }
    private void FireEnd() 
    {
        fireOn = false;
    }
    private void SetLightOn() 
    {
        light.enabled = true;
    }
    private void SetLightOff() 
    {
        light.enabled = false;
    }
}
