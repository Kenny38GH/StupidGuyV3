using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Enemy : MonoBehaviour
{
    public GameObject tire;
    public float degats;
    public float range;
    public int w;
    public GameObject impactEffect;
    public AudioClip boom;
    public AudioSource AudioSource;
    public RaycastHit hit;
    public bool tombe = false;

    // Start is called before the first frame update
    void Start()
    {
        w=100;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        if (w<100)
        {
            w+=1;
        }

    }

    void Shoot()
    {
        
        if (Physics.Raycast(tire.transform.position, tire.transform.forward, out hit, range))
        {
            if(hit.collider.tag=="Player" && w==100)
            {
                Target target = hit.transform.GetComponent<Target>();
                target.TakeDamage(degats);
                AudioSource.PlayOneShot(boom,0.3f);
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO,2f);
                w=0;
                tombe=true;
            }
        }

    }

}
