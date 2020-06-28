using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerMastask;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float cooldown;
    [SerializeField] private float startDelay;
    [SerializeField] private Light light;

    private float timer;

    void Start()
    {
        timer = startDelay;
    }

    void Update()
    {
        PlayerDetection();

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            light.intensity = (cooldown - timer) / cooldown * 6;

            if (timer < 0)
            {
                timer = cooldown;
                SpawnBullet();
            }
        }
    }
    private void SpawnBullet()
    {
        GameObject tmp = Instantiate(bullet);
        Transform t = tmp.transform;

        t.parent = this.transform.GetChild(0);
        t.localPosition = Vector3.zero;

        t.GetComponent<Bullet>().SetSpeed(bulletSpeed);
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
    public void SetActive()
    {

        light.gameObject.SetActive(true);
    }
    private void SetSleep() 
    {
        light.gameObject.SetActive(false);
    }
}
