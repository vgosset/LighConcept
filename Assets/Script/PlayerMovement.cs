using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private VariableJoystick joysticMov;
    [SerializeField] private float speed;
    
    private Vector3 dest = new Vector3();

    void Start()
    {
        
    }

    void Update()
    {
        dest = new Vector3(joysticMov.Horizontal, 0.0f, joysticMov.Vertical);
        if (dest != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dest);
            transform.Translate (dest * speed * Time.deltaTime, Space.World);
        }
        
    }
}
