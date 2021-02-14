using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusMove : MonoBehaviour
{
    public GameObject target;
    public float offsetX = 1f;
    public float offsetY = 1f;
    public float profondeur = 1f;
    public GameObject pointfoc;
    public float turnSpeed = 10.0f;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    pointfoc.transform.position = target.transform.position;
    transform.Translate(offsetX,offsetY,0);
        
    //radius = offsetX;
    //float h = Input.GetAxisRaw ("Mouse X");
    //transform.RotateAround (target.transform.position, Vector3.up, Time.deltaTime * h * 10);
    //transform.position = target.transform.position + new Vector3(offsetX, offsetY, profondeur);

    float yRotation = cam.transform.eulerAngles.y;
    transform.rotation = Quaternion.Euler(0,yRotation,0);

     //transform.RotateAround(target.transform.position, Vector3.up, Input.GetAxis("Mouse X")* turnSpeed );
    }
    
}
