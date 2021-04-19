using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraV2 : MonoBehaviour
{

    public GameObject Character;
    public GameObject CameraCenter;
    public float yOffset;
    public float sensitivity;
    public Camera cam;
    RaycastHit camHit;
    public Vector3 CamDist;
    bool fpsCam;
    bool tpsCam;
    public float X;
    public float Y;
    public float Z;
    public GameObject partie1;
    public GameObject partie2;
    public GameObject partie3;
    public GameObject partie4;
    public GameObject partie5;
    public string inputfps;
    public string inputtps;



    void Start()
    {

        CamDist = new Vector3 (Character.transform.position.x + X,Character.transform.position.y+Y,Character.transform.position.z+Z);
        cam.transform.position = CamDist;

        CamDist = cam.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        CameraCenter.transform.position = new Vector3(Character.transform.position.x, Character.transform.position.y + yOffset, Character.transform.position.z);
		
        CameraCenter.transform.rotation = Quaternion.Euler(CameraCenter.transform.rotation.eulerAngles.x + -Input.GetAxis("Mouse Y") * sensitivity/2,
            CameraCenter.transform.rotation.eulerAngles.y + Input.GetAxis("Mouse X") * sensitivity, CameraCenter.transform.rotation.eulerAngles.z);
			
        cam.transform.localPosition = CamDist;
        GameObject obj = new GameObject();
        obj.transform.SetParent(cam.transform.parent);
        obj.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, cam.transform.localPosition.z - 0.1f);

        if(Physics.Linecast(CameraCenter.transform.position, obj.transform.position,out camHit))
        {

                cam.transform.position = camHit.point;
                cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, cam.transform.localPosition.z + 0.1f);
        }
		Destroy(obj);

    if(fpsCam == true)
    {
        cam.transform.position = Character.transform.position;
        cam.transform.Translate (0,2.3f,0.4f);
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
}
