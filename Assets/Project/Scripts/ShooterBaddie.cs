using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ShooterBaddie : Enemy {

    private Player player;
    public float shootRange = 3f;
    public float shootDelay = 4f;
    private float shootTimer;

    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
        shootTimer = Random.Range(0, shootDelay);
        agent = GetComponent<NavMeshAgent>();

       // agent.SetDestination(player.transform.position);

    }
	
	// Update is called once per frame
	void Update () {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Vector3.Distance(transform.position, player.transform.position) <= shootRange)
        {
            shootTimer = shootDelay;

            GameObject bullet = PoolManager.Instance.getBullet(false);
            bullet.transform.position = transform.position;
            bullet.transform.forward = (player.transform.position - transform.position).normalized;
            agent.SetDestination(player.transform.position);
        }
	}
}
