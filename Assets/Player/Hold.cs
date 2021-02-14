using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour
{
    public Transform theDesttps;
    public Transform theDestfps;
    public Transform emplacement;
    public Transform emplacementtps;
    public string Prendre,Lacher;
    public Camera cam;
    public float rangegrab = 30f;
    public bool fpsCam;
    public bool tpsCam;
    public string inputfps;
    public string inputtps;
    public bool oui = false;
    public bool objetoui = false;
    public Weapon arme;
    public Objet objet;
    public float throwForce;
    public float force = 1f;
    

    void Start ()
    {
        tpsCam = true;
        fpsCam = false;
    }
    void Update()
    {   
        if(Input.GetKey(KeyCode.Mouse1) && force < 100f)
        {
            force += 0.5f;
        }
        if(Input.GetKeyDown(inputtps) & Input.GetKey(inputtps))
        {
            fpsCam = false;
            tpsCam = true;
        }
        if(Input.GetKeyDown(inputfps) & Input.GetKey(inputfps))
        {
            fpsCam = true;
            tpsCam = false;
        }

        if(Input.GetKeyDown(Prendre))
        {
            Grab();
        }

        if(Input.GetKeyDown(Lacher))
        {
            Leave();
        }

        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            Jetter();
        }

        if(fpsCam == true)
        {
            if(arme != null)
            {
                arme.transform.position = emplacement.position;
                arme.transform.parent = GameObject.Find("Emplacement_arme").transform;
            }
            if(objet != null)
            {
                objet.transform.position = theDestfps.position;
                objet.transform.parent = GameObject.Find("Destination_fps").transform;
            }
            
            
        }
        
        if(tpsCam == true)
        {
            if(arme != null)
            {
                arme.transform.position = emplacementtps.position;
                arme.transform.parent = GameObject.Find("Emplacement_armetps").transform;
            }
            if(objet != null)
            {
                objet.transform.position = theDesttps.position;
                objet.transform.parent = GameObject.Find("Destination_tps").transform;
            } 
        }


        
    }
    void Grab()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.forward, out hit, rangegrab))
        {
            if(hit.collider.tag=="Objet" && objetoui == false)
            {
                hit.collider.tag="Objet_active";
                objetoui = true;
                objet = hit.transform.GetComponent<Objet>();
                if(fpsCam == true)
                {
                    objet.transform.position = theDestfps.position;
                    objet.transform.parent = GameObject.Find("Destination_fps").transform;
                }
                if(tpsCam == true)
                {
                    objet.transform.position = theDesttps.position;
                    objet.transform.parent = GameObject.Find("Destination_tps").transform;
                }
            }
            if(hit.collider.tag=="Weapon" && oui == false)
            {
                hit.collider.tag="Weapon_active";
                oui = true;
                arme = hit.transform.GetComponent<Weapon>();
                
                if(fpsCam == true)
                {
                    arme.transform.position = emplacement.position;
                    arme.transform.parent = GameObject.Find("Emplacement_arme").transform;
                }
                if(tpsCam == true)
                {
                    arme.transform.position = emplacementtps.position;
                    arme.transform.parent = GameObject.Find("Emplacement_armetps").transform;
                }
            }
        }     
    }

    void Leave()
    {
        if(arme != null)
        {
            arme.tag = "Weapon";
            arme.transform.parent = null;
            arme = null;
            oui = false;
        }
        
        if(objet != null)
        {
            objet.tag = "Objet";
            objet.transform.parent = null;
            objet = null;
            objetoui = false;  
        }
    }

    void Jetter()
    {
        if(objet != null)
        {
            
            objet.transform.parent = null;
            objetoui = false;
            objet.tag = "Objet";
            objet.GetComponent<Rigidbody>().AddForce(emplacement.forward * throwForce * force);
            objet = null;
            force = 0;
        }
    }
}
