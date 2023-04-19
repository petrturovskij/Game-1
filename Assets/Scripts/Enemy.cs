using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform spownEnemyGun;
    private float dist;
    private Transform player;
    public float angylarspeed;
    public float fireDist;
    public float fireTime;
    private float nextfire;
    private NavMeshAgent agent;
    [SerializeField] private Transform[] points;
    private int index;
    private float enemy;
    public float damage;
    private float EnemyHealth = 100f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        FindDistance();

        if (dist < fireDist)
        {
            LookPlayer();
            agent.SetDestination(player.position);
            Fire();
        }
       if (dist <= 3f)
        {
            EnemyStop();
        }
        else
        {
            Patrol();
        }
    }
    private void Fire()
    {
        if (Time.time > nextfire)
        {
            Instantiate(bullet, spownEnemyGun.position, spownEnemyGun.rotation);
            nextfire = Time.time + fireTime;
        }
    }
    private void LookPlayer()
    {
        var direction = player.transform.position - transform.position;
        var rotation = Vector3.RotateTowards(transform.forward, direction, angylarspeed * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(rotation);
    }
    private void FindDistance()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
    }
    private void Patrol()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            index = (index + 1) % points.Length;
            agent.SetDestination(points[index].position);
        }
    }
    private void EnemyStop()
    {
        agent.Stop();
    }
    public void Hurt(float damage)
    {

        EnemyHealth -= damage; ;
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
            
        }
    }

}
