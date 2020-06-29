using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
    [SerializeField] private float sideX;
    [SerializeField] private float sideZ;
    
    private float sidePosX;
    private float sidePosZ;
    

    void Start()
    {
        sidePosZ = Mathf.Abs(transform.position.z);
        sidePosX = Mathf.Abs(transform.position.x);
    }

    void Update()
    {
        transform.localPosition = new Vector3((transform.position.x / sidePosX * sideX) , transform.localPosition.y , transform.localPosition.z);
    }
}
