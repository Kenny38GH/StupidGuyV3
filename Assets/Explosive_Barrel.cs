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
            if(hit.collider.tag=="Barrel" && Input.GetKeyDown(KeyCode.Mouse0))
            {
                hit.collider.tag = "Barrel_actif";
            }
        }
        if(tag=="Barrel_actif")
            {
                Explosion();
                GameObject impactGO = Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(barrel);
            }
    }

    void Explosion()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position,range);
        
        foreach(Collider enemy in enemies)
        {
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
}
