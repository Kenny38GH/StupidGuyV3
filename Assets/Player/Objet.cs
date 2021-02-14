using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objet : MonoBehaviour
{
    public Camera cam;
    public Hold hold;
    void Start ()
    {

    }

    void Update()
    {
        if(hold.objetoui == true && tag == "Objet_active")
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
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().freezeRotation = true;
            GetComponent<Rigidbody>().velocity = new Vector3 (0,0,0);
        }
        if(hold.objetoui == false)
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().freezeRotation = false;
            GetComponent<BoxCollider>().enabled = true;
        }
    }
}