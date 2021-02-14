using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{
    public GameObject goPoint,goPoint2,goPoint3,goPoint4;
    public NavMeshAgent agent;
    public bool gopoint1 = false;
    public bool gopoint2 = false;
    public bool gopoint3 = false;
    public bool gopoint4 = false;
    Vector3 valabas,valabas2,valabas3,valabas4;
    public bool follow_player = false;
    public Shooting_Enemy shooten;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        valabas = goPoint.transform.position;
        valabas2 = goPoint2.transform.position;
        valabas3 = goPoint3.transform.position;
        valabas4 = goPoint4.transform.position;
        gopoint1 = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (gopoint1 == true && follow_player == false)
        {
            agent.SetDestination(valabas);
        }
        if(agent.transform.position.x == goPoint.transform.position.x && agent.transform.position.z == goPoint.transform.position.z)
        {
            gopoint1 = false;
            gopoint2 = true;
        }
        if(gopoint2 == true && follow_player == false)
        {
            agent.SetDestination(valabas2);
        }
        if(agent.transform.position.x == goPoint2.transform.position.x && agent.transform.position.z == goPoint2.transform.position.z)
        {
            gopoint2 = false;
            gopoint3 = true;
        }
        if(gopoint3 == true && follow_player == false)
        {
            agent.SetDestination(valabas3);
        }
        if(agent.transform.position.x == goPoint3.transform.position.x && agent.transform.position.z == goPoint3.transform.position.z)
        {
            gopoint3 = false;
            gopoint4 = true;
        }
        if(gopoint4 == true && follow_player == false)
        {
            agent.SetDestination(valabas4);
        }
        if(agent.transform.position.x == goPoint4.transform.position.x && agent.transform.position.z == goPoint4.transform.position.z)
        {
            gopoint4 = false;
            gopoint1 = true;
        }

        float distance = Vector3.Distance(player.transform.position,transform.position);
      
        if (distance <= shooten.range)
        {
            follow_player = true;
            agent.SetDestination(player.transform.position);
            if (distance <= shooten.range)
            {
                FaceTarget();
            }
        }
        if (distance > shooten.range)
        {
            follow_player = false;
        }
    }
    void FaceTarget()
        {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        }
}
