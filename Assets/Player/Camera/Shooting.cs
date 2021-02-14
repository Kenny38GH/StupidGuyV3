using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Shooting : MonoBehaviour
{

    public Camera cam;
    public GameObject impactEffect;
    public Text amoText;
    public Text life;
    public string Recharger;
    public float rangeramasser = 20f;
    public Transform Player;
    public float X;
    public float Y;
    public float Z;
    public Hold hold;
    public AudioClip Grosdeagledesfamilles;
    public AudioClip GrosRechargementquivabien;
    public AudioClip PlusdeballeBoloss;
    public Target vie;
    public AudioSource AudioSource;
    public Weapon weapon;

    void Start()
    {
        weapon.munitions = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && weapon.munitions != 0 && hold.oui == true)
        {
            Shoot();
            weapon.munitions -=1;
            
            AudioSource.PlayOneShot(Grosdeagledesfamilles,0.7f);
        }
        if(Input.GetKeyDown(Recharger) && hold.oui == true && weapon.munitions != weapon.chargeur)
        {
            weapon.munitions = weapon.chargeur;
            AudioSource.PlayOneShot(GrosRechargementquivabien,0.7f);

        }
        if(Input.GetButtonDown("Fire1") && weapon.munitions == 0 && hold.oui == true)
        {
            AudioSource.PlayOneShot(PlusdeballeBoloss,0.7f);
        }
        
        SetMun(weapon.munitions);
        SetLife();
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.forward, out hit, weapon.range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(weapon.damage);
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * weapon.impactForce);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO,2f);
        }
    }
    void SetMun(int amount)
    {
        if(hold.oui == true)
        {
            amoText.text = amount.ToString();
            if (amount == 0)
            {
                amoText.text = "Reload [R]";
            }
        }
        else
        {
            amoText.text = "";
        }
    }

    void SetLife()
    {
        life.text = vie.health.ToString();
    }
}
