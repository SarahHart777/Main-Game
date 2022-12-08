using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//Resources
//https://www.youtube.com/watch?v=ieyHlYp5SLQ
public class EnemyController : MonoBehaviour
{
    public GameObject player1;

    public NavMeshAgent navMeshAgent;
    public float startWaitTime = 2;
    public float timeToRotate = 2;
    public float speedWalk = 6;
    public float speedRun = 9;

    public float viewDistance = 10;
    public float viewRadius = 15;
    public float viewAngle = 90;
    public LayerMask playerMask;
    public LayerMask obstacleMask;
    public float meshResolution = 1.0f;
    public int edgeIterations = 4;
    public float edgeDistance = 0.5f;
    public float stopChasingDistace = 10;

    [SerializeField] private Animator m_Animator;
    

    public Transform[] waypoints;
    int m_currentWaypointIndex = 0;

    Vector3 playerLastPosition = Vector3.zero;
    Vector3 m_playerPosition;

    float m_WaitTime;
    float m_TimeToRotate;
    bool m_PlayerInRange;
    bool m_playerNear;
    bool m_IsPatrol;
    bool m_CaughtPlayer;
    bool Chase = false;


    // Start is called before the first frame update
    void Start()
    {
        m_playerPosition = Vector3.zero;
        m_IsPatrol = true;
        m_CaughtPlayer = false;
        m_PlayerInRange = false;
        m_WaitTime = startWaitTime;
        m_TimeToRotate = timeToRotate;

        m_currentWaypointIndex = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speedWalk;
        navMeshAgent.SetDestination(waypoints[m_currentWaypointIndex].position);

       
    }

    // Update is called once per frame
    void Update()
    {
        EnviromentView();

        if (!m_IsPatrol)
        {
            Chasing();
        }
        else
        {
            Patroling();
        }
    }

    private void Chasing()
    {
        //Debug.Log("Chassing");
        m_Animator.SetBool("isChasing", true);
        m_Animator.SetBool("isPatroling", false);

        m_playerNear = false;               //  Set false that the player is near because the enemy already sees the player
        playerLastPosition = Vector3.zero;
        if (!m_CaughtPlayer)
        {
            m_playerPosition = player1.transform.position; // Testing to see if it can find the players location
            Move(speedRun);
            navMeshAgent.SetDestination(m_playerPosition);
        }
        //Debug.Log("Remaing Distance: " + navMeshAgent.remainingDistance);
        //Debug.Log("Stopping Distance:" + navMeshAgent.stoppingDistance);

        if (m_WaitTime <= 0 && !m_CaughtPlayer && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= stopChasingDistace)
        {
            m_IsPatrol = true;
            m_playerNear = false;
            Move(speedWalk);
            m_TimeToRotate = timeToRotate;
            m_WaitTime = startWaitTime;
            navMeshAgent.SetDestination(waypoints[m_currentWaypointIndex].position);
        }
        else
        {
            if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= stopChasingDistace)
            {
                Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }

    }

    private void Patroling()
    {
        //Debug.Log("Patrolling");
        m_Animator.SetBool("isChasing", false);
        m_Animator.SetBool("isPatroling", true);
        //if (m_playerNear)
        if (Vector3.Distance(transform.position, player1.transform.position) <= viewDistance)
        {
            m_IsPatrol = false;
            m_playerNear = true;
            LookingAtPlayer(playerLastPosition);
            Chasing();
        }
        else
        {
            m_playerNear = false;
            playerLastPosition = Vector3.zero;
            navMeshAgent.SetDestination(waypoints[m_currentWaypointIndex].position);
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (m_WaitTime <= 0)
                {
                    NextPoint();
                    Move(speedWalk);
                    m_WaitTime = startWaitTime;
                }
                else
                {
                    Stop();
                    m_WaitTime -= Time.deltaTime;
                }
            }
        }
    }
    void Move(float speed)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;
    }

    void Stop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
    }
    public void NextPoint()
    {
        m_currentWaypointIndex = (m_currentWaypointIndex + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[m_currentWaypointIndex].position);
    }
    void CaughtPlayer()
    {
        m_CaughtPlayer = true;
    }

    void LookingAtPlayer(Vector3 player)
    {
        navMeshAgent.SetDestination(player);
        if (Vector3.Distance(transform.position, player) <= 0.3)
        {
            if (m_WaitTime <= 0)
            {
                m_playerNear = false;
                Move(speedWalk);
                navMeshAgent.SetDestination(waypoints[m_currentWaypointIndex].position);
                m_WaitTime = startWaitTime;
                m_TimeToRotate = timeToRotate;
            }
            else
            {
                Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }

    }

    void EnviromentView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);

        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2)
            {
                float dstToPlayer = Vector3.Distance(transform.position, player.position);
                if (!Physics.Raycast(transform.position, dirToPlayer, dstToPlayer, obstacleMask))
                {
                    m_PlayerInRange = true;
                    m_IsPatrol = false;
                }
                else
                {
                    m_PlayerInRange = false;

                }
            }
            if (Vector3.Distance(transform.position, player.position) > viewRadius)
            {
                m_PlayerInRange = false;
            }
            if (m_PlayerInRange)
            {
                m_playerPosition = player.transform.position;
            }
        }
    }
}
