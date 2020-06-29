using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float cooldown;
    [SerializeField] private float startDelay;
    [SerializeField] private Light light;
    [SerializeField] private Vector3 dirBullet;

    private bool fireOn = false;
    private float timer;

    void Start()
    {
        timer = startDelay;
    }

    void Update()
    {
        PlayerDetection();
        TimerHandler();
    }
    private void TimerHandler()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            light.intensity = (cooldown - timer) / cooldown * 4;

            if (timer < 0)
            {
                timer = cooldown;
                if (fireOn)
                {
                    SpawnBullet();
                }
            }
        }
    }
    private void SpawnBullet()
    {
        GameObject tmp = Instantiate(bullet);
        Transform t = tmp.transform;

        t.parent = this.transform.GetChild(0);
        t.localPosition = Vector3.zero;
        t.parent = null;

        t.GetComponent<Bullet>().SetSpeed(bulletSpeed, dirBullet);
    }
    private void PlayerDetection()
    {
        Collider[] target = Physics.OverlapSphere(transform.position, radius, playerMask);

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
        fireOn = true;
    }
    private void SetSleep() 
    {
        light.gameObject.SetActive(false);
        fireOn = false;
    }
}
