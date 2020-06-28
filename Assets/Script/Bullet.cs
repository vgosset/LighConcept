using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float m_speed = 0;
    
    private void Update()
    {
        transform.localPosition += Vector3.forward * m_speed * Time.deltaTime;
    }
    public void SetSpeed(float speed)
    {
        m_speed = speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
        {
            other.transform.GetComponent<PlayerMovement>().ResetPos();
            MapGeneration.Instance.DelayedDeath();
        }
        else if (other.transform.tag == "Enemie" || other.transform.tag == "Wall")
            Destroy(this.gameObject);
    }
}
