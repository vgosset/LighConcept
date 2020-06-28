using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private List<Animator> a_gateLst;
    [SerializeField] private List<bool> statesLst;
    
    private bool isOpen = false;

    void Start()
    {
        InitStates();
    }

    void Update()
    {
        
    }
    private void InitStates()
    {
        for (int i = 0; i < statesLst.Count; i++)
        {
            if (statesLst[i])
            {
                a_gateLst[i].SetBool("IsOpen", false);
                a_gateLst[i].SetTrigger("Close");
            }
            else
            {
                a_gateLst[i].SetBool("IsOpen", true);
                a_gateLst[i].SetTrigger("Open");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
        {
            
            for (int i = 0; i < a_gateLst.Count; i++)
            {
                if (a_gateLst[i].GetBool("IsOpen"))
                {
                    a_gateLst[i].SetBool("IsOpen", false);
                    a_gateLst[i].SetTrigger("Close");
                }
                else
                {
                    a_gateLst[i].SetBool("IsOpen", true);
                    a_gateLst[i].SetTrigger("Open");
                }
            }
        }
    }
}
