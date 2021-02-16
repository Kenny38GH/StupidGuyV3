using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ennemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public GameObject player;

    public GameObject impactEffect;

    public float enemy_damage;

    public float angleBetween = 0.0f;

    Vector3 direction;
    float distance;
    
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
      distance = Vector3.Distance(player.transform.position, transform.position);
      
      if (distance <= lookRadius)
        {
        agent.SetDestination(player.transform.position);

        if (distance <= agent.stoppingDistance)

        {
                // faire face au jouer
                FaceTarget();
                //attaquer

        }

        }
        Vector3 targetDir = player.transform.position - transform.position;
        angleBetween = Vector3.Angle(transform.forward, targetDir);
        //Debug.Log(angleBetween);

        InvokeRepeating("EnnemyShoot",0f,1.5f);

        
    }
    void FaceTarget()
        {

        direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        }
    void EnnemyShoot()
    {
        Debug.Log("LOOOOOOOL");
        
        if (angleBetween < 10 && distance < lookRadius)
            {
                
                Target target = player.transform.GetComponent<Target>();
                //Target target = hit.transform.GetComponent<Target>();
                target.TakeDamage(enemy_damage);
                //GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                //Destroy(impactGO,0.3f);
            }
        
    }    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position , lookRadius);
        Gizmos.DrawLine(transform.position,direction);
    }
}