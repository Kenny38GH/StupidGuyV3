using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public int munitions;
    public int chargeur;
    public float impactForce = 60f; 

    public Camera cam;
    public Hold hold;
    void Start ()
    {

    }

    void Update()
    {
        if(hold.oui == true && tag == "Weapon_active")
        {
            if(hold.fpsCam == true)
            {
                float yRotation = cam.transform.eulerAngles.y;
                float xRotation = cam.transform.eulerAngles.x;
                transform.rotation = Quaternion.Euler(260-xRotation,+yRotation+180,0);   
            }
            if(hold.tpsCam == true)
            {
                float yRotation = cam.transform.eulerAngles.y;
                float xRotation = cam.transform.eulerAngles.x;
                transform.rotation = Quaternion.Euler(260-xRotation,+yRotation+180,0);
            }
            transform.GetComponent<Rigidbody>().useGravity = false;
            transform.GetComponent<BoxCollider>().enabled = false;
            transform.GetComponent<Rigidbody>().freezeRotation = true;
            transform.GetComponent<Rigidbody>().velocity = new Vector3 (0,0,0);
        }
        if(hold.oui == false)
        {
            transform.GetComponent<Rigidbody>().useGravity = true;
            transform.GetComponent<Rigidbody>().freezeRotation = false;
            transform.GetComponent<BoxCollider>().enabled = true;
        }
    }
}