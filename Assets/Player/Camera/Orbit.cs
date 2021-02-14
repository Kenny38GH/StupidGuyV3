using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
 
    float rotationSpeed = 1;
    public float zoomspeed = 100;
    public Transform Player, cam;
    public float mouseX, mouseY,zoom = 0;
    public float X;
    public float Y;
    public float Z;
    bool fpsCam;
    bool tpsCam;
    public string inputfps;
    public string inputtps;
    public GameObject partie1;
    public GameObject partie2;
    public GameObject partie3;
    public GameObject partie4;
    public GameObject partie5;
    public float minZoom = 5.0f;
    public float maxZoom = 250.0f;

    void Start ()
    {
        tpsCam = true;
        fpsCam = false;
    }
  
    void Update()
    {
    if(tpsCam == true)
    {
        transform.position = Player.transform.position;
        transform.Translate (X,Y,Z);
        zoom += Input.GetAxisRaw("Mouse ScrollWheel")* zoomspeed * Time.deltaTime;
        transform.Translate (0,0,zoom);
        
        if(zoom <= maxZoom)
        {
            zoom = maxZoom;
        }
        if(zoom>= minZoom)
        {
            zoom = minZoom;
        }
        
    }
    if(fpsCam == true)
    {
        transform.position = Player.transform.position;
        transform.Translate (0,2.3f,0.4f);
    }
    if(Input.GetKeyDown(inputfps) && fpsCam == false)
    {
        tpsCam = false;
        fpsCam = true;
        partie1.gameObject.SetActive(false);
        partie2.gameObject.SetActive(false);
        partie3.gameObject.SetActive(false);
        partie4.gameObject.SetActive(false);
        partie5.gameObject.SetActive(false);
    }
    if(Input.GetKeyDown(inputtps) && tpsCam == false)
    {
        tpsCam = true;
        fpsCam = false;
        partie1.gameObject.SetActive(true);
        partie2.gameObject.SetActive(true);
        partie3.gameObject.SetActive(true);
        partie4.gameObject.SetActive(true);
        partie5.gameObject.SetActive(true);
    }
    
    }
    void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        if(fpsCam == true)
        {
            mouseY = Mathf.Clamp(mouseY, -80, 80);
        }
        if(tpsCam == true)
        {
            mouseY = Mathf.Clamp(mouseY, -15, 60);
        }        
        cam.rotation = Quaternion.Euler(mouseY, mouseX,0);
    }
 }