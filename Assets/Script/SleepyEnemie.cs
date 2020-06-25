using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SleepyEnemie : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerMastask;
    [SerializeField] private GameObject light;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float distanceMax;

    private Transform initPos;
    private MeshRenderer mesh;
    private Transform m_target;
    private bool active;

    private void Start()
    {
        Init();
    }

    private void FixedUpdate()
    {
        if (active)
        {
            GoToDest(m_target);

            if (Vector3.Distance(transform.position, m_target.position) > distanceMax)
            {
                SetSleep();
            }
        }
        else
        {
            GoToDest(initPos);
            PlayerDetection();
        }
    }
    private void Init()
    {
        initPos = this.transform;
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }
    public void SetActive()
    {
        active = true;
        mesh.enabled = true;
        light.SetActive(true);
    }
    private void SetSleep()
    {
        active = false;
        mesh.enabled = false;
        light.SetActive(false);
    }
    private bool IsAsctive()
    {
        return active;
    }
    private void PlayerDetection()
    {
        Collider[] target = Physics.OverlapSphere(transform.position, radius, playerMastask);

        if (target.Length > 0 && !IsAsctive())
        {
            m_target = target[0].transform;
            SetActive();
        }
    }
    private void GoToDest(Transform dest)
    {
        float step = rotateSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, dest.transform.position,  movementSpeed * Time.deltaTime);
        Vector3 targetDir = dest.transform.position - transform.position;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
          SceneManager.LoadScene("Gameplay1");
    }
}
