﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hold : MonoBehaviour
{
    public Transform theDesttps;
    public Transform theDestfps;
    public Transform emplacement;
    public Transform emplacementtps;
    public Transform emplacementjetpack;
    public string Prendre,Lacher;
    public Camera cam;
    public float rangegrab = 30f;
    public bool fpsCam;
    public bool tpsCam;
    public string inputfps;
    public string inputtps;
    public bool oui = false;
    public bool objetoui = false;
    public bool jetpackOn = false;
    public Weapon arme;
    public Objet objet;
    public Jetpack jetpack;
    public float throwForce;
    public float force = 1f;
    public Text pourcentage;

    
    

    void Start ()
    {
        tpsCam = true;
        fpsCam = false;
    }
    void Update()
    {   
        if(Input.GetKey(KeyCode.Mouse1) && force < 100f)
        {
            force += 1f;
        }
        
        if(objetoui== true)
        {
            pourcentage.text = force.ToString() + "%";
        }
        else
        {
            pourcentage.text = "";
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

        if(jetpackOn == true)
        {
            jetpack.transform.position = emplacementjetpack.position;
            jetpack.transform.parent = GameObject.Find("Emplacement_jetpack").transform;
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
            if(hit.collider.tag=="Jetpack" && jetpackOn == false)
            {
                jetpackOn = true;
                jetpack = hit.transform.GetComponent<Jetpack>();
                jetpack.transform.position = emplacementjetpack.position;
                jetpack.transform.parent = GameObject.Find("Emplacement_jetpack").transform;
                float yRotation = jetpack.player.transform.eulerAngles.y;
                float xRotation = jetpack.player.transform.eulerAngles.x;
                jetpack.transform.rotation = Quaternion.Euler(260-xRotation,+yRotation+180,0);   
                jetpack.transform.GetComponent<Rigidbody>().useGravity = false;
                jetpack.transform.GetComponent<BoxCollider>().enabled = false;
                jetpack.transform.GetComponent<Rigidbody>().freezeRotation = true;
                jetpack.transform.GetComponent<Rigidbody>().velocity = new Vector3 (0,0,0);
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
