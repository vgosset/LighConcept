using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class SleepyEnemie : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerMastask;
    [SerializeField] private GameObject light;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float distanceMax;
    [SerializeField] private float triggerTimer;
    [SerializeField] private float delayChase;

    private Transform initPos;
    private Animator anim;
    private MeshRenderer mesh;
    private Transform m_target;
    private bool active;
    private NavMeshAgent agent;
    private float delayChaseTimer;

    private void Awake()
    {
        Init();
    }

    private void FixedUpdate()
    {
        if (active)
        {
            delayChaseTimer -= Time.deltaTime;
            agent.SetDestination(m_target.position);

            // if (Vector3.Distance(transform.position, m_target.position) > distanceMax)
            // {
            //     SetSleep();
            // }
            if (delayChaseTimer <= 0)
            {
                SetSleep();
            }
        }
        else
        {
            PlayerDetection();
        }
    }
    private void Init()
    {
        initPos = this.transform;

        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        mesh = transform.GetChild(0).GetComponent<MeshRenderer>();

        mesh.enabled = false;
    }
    public void SetActive()
    {
        delayChaseTimer = delayChase;

        StartCoroutine(TriggerState());
    }
    private IEnumerator TriggerState()
    {
        mesh.enabled = true;
        light.SetActive(true);
        anim.SetTrigger("TriggerSleep");

        yield return new WaitForSeconds(triggerTimer);

        anim.SetTrigger("Rush");
        agent.isStopped = false;
        active = true;
    }
    private void SetSleep() 
    {
        active = false;
        mesh.enabled = false;
        light.SetActive(false);
        agent.isStopped = true;

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
        // Vector3 targetDir = dest.transform.position - transform.position;

        // Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        // transform.rotation = Quaternion.LookRotation(new Dir);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
          SceneManager.LoadScene("Gameplay1");
    }
}
