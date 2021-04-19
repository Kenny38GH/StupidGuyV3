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
    public bool camenplace;
    public Vector3 camrayorigin, camraydirection;
    RaycastHit hit;
    Ray camRay;
    public Vector3 poscam;

    public float dist,camX,camY,camZ;
    public float clipdist;

    //public float minZoom = 5.0f;
    //public float maxZoom = 250.0f;

    void Start ()
    {
        tpsCam = true;
        fpsCam = false;
        
    }
  
    void Update()
    {
        
        


    if(tpsCam == true)
    {

        
        camX = cam.transform.position.x;
        camY = cam.transform.position.y;
        camZ = Player.localPosition.z;
        poscam = new Vector3 (camX, camY, camZ-7);
        
        
        Debug.DrawLine(poscam,Player.transform.position,Color.blue);


        if(Physics.Linecast(poscam,Player.transform.position,out hit, 1 << LayerMask.NameToLayer("Default")))
        {

          dist = hit.distance*1.2f;


        }

        else
        {

          dist = -7;

        }
       


        //if (Physics.Raycast(cam.transform.position,cam.transform.forward, out hit,3))
        //{
          //dist = new Vector3 (X,Y,hit.distance*1.2f);
            
        //}
        
        //else
        
        //{
          //dist = new Vector3(X,Y,Z);
          //transform.position = Player.transform.position;
          //transform.Translate (X,Y,Z);

        //}

        transform.position = Player.transform.position;
        transform.Translate (X,Y,dist);

            


        
        
        
      //  zoom += Input.GetAxisRaw("Mouse ScrollWheel")* zoomspeed * Time.deltaTime;
       // transform.Translate (0,0,zoom);
        
        //if(zoom <= maxZoom)
        //{
          //  zoom = maxZoom;
        //}
        //if(zoom>= minZoom)
        //{
          //  zoom = minZoom;
        //}
        
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