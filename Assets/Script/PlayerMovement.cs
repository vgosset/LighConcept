using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private VariableJoystick joysticMov;
    [SerializeField] private float speed;
    [SerializeField] private GameObject trail;
    [SerializeField] private float boostDecrease;
    
    private Vector3 dest = new Vector3();
    private float destSpeed;
    private Vector3 initPos;
    private bool active = true;

    void Start()
    {
        destSpeed = speed;
        initPos = transform.position;
    }

    void Update()
    {
        if (active)
        {
            Movement();
        }
    }
    private void Movement()
    {
        float dt = Time.deltaTime;
        dest = new Vector3(joysticMov.Horizontal, 0.0f, joysticMov.Vertical);

        if (dest != Vector3.zero)
        {
            transform.position += dest * Time.deltaTime * speed;
            // transform.rotation = Quaternion.LookRotation(dest);
            // transform.Translate (dest * speed * dt, Space.World);
        }
        if (speed > destSpeed)
        {
            speed -= dt * boostDecrease;
        }
        else
            trail.SetActive(false);
            
    }
    public void ResetPos()
    {
        active = false;
        transform.position = initPos;
        joysticMov.ResetValue();
    }
    public void SetSpeedBoost(float amout, float delay)
    {
        // StartCoroutine(Cor_SpeedBoost(amout, delay));
        destSpeed = speed;
        speed += amout;
        trail.SetActive(true);
    }
    public void SetActive()
    {
        active = true;
    }
    // private IEnumerator Cor_SpeedBoost(float amout, float delay)
    // {
            // speed += amout;
    //     yield return new WaitForSeconds(delay);
    //     speed -= amout;
    // }
}
