using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float m_speed = 0;
    private Vector3 m_dir;
    
    private void LateUpdate()
    {
        transform.position += m_dir * m_speed * Time.deltaTime;
    }
    public void SetSpeed(float speed, Vector3 dir)
    {
        m_speed = speed;
        m_dir = dir;
        transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
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
