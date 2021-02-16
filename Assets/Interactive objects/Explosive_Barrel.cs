using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive_Barrel : MonoBehaviour
{
    public float range;
    public GameObject impactEffect;
    public float explosionForce;
    public Target target;
    private Vector3 pos;
    public GameObject barrel;
    public Weapon weapon;
    public Hold hold;

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(cam.transform.position,cam.transform.forward, out hit, weapon.range))
        {
            if(hit.collider.tag=="Objet" && Input.GetKeyDown(KeyCode.Mouse0))
            {
                Explosive_Barrel explobarrel = hit.transform.GetComponent<Explosive_Barrel>();
                if(explobarrel != null)
                {
                    hit.collider.tag = "Barrel_actif";
                }
            }
        }
        if(tag=="Barrel_actif")
        {
            Explosion();
            GameObject impactGO = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(barrel);
        }

        if(target.health < 100)
        {
            tag = "Barrel_actif";
        }
        
    }

    void Explosion()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position,range);
        
        foreach(Collider enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position,transform.position);
            if(enemy.GetComponent<Target>() != null)
            {
                enemy.GetComponent<Target>().TakeDamage(300 -(20*distance));
            }
            if(enemy.GetComponent<Rigidbody>() != null)
            { 
                enemy.GetComponent<Rigidbody>().AddExplosionForce(explosionForce,transform.position,range,3f,ForceMode.Impulse);
            }
        }
        
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,range);
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
        v = new Vector3(Mathf.Abs(v.x),Mathf.Abs(v.y),Mathf.Abs(v.z));
        float v3 = v.magnitude;
        Debug.Log(v3);
        if (collision.gameObject.layer == 0 && v3 > 20)
        {
            Explosion();
            GameObject impactGO = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(barrel);
        }
    }
}
