using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy_control_V2 : MonoBehaviour
{
    //Paramètres et objets

    Animator GuyAnimation;
    public float walkSpeed;
    public GameObject cam;
    Rigidbody rb;
    public float petitspas;
    public GameObject player;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public Vector3 jumpSpeed;
    public float jumpForce = 2.0f;



    //Inputs
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;
    public float runSpeed;


    // Start is called before the first frame update
    void Start()
    {
        GuyAnimation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        
        
        //proba grattage de cul

        var boolgrattage = (Random.value < 0.003);
        GuyAnimation.SetBool("Grattage",boolgrattage);

        bool boolmarche = Input.GetKey(inputFront);
        GuyAnimation.SetBool("Marcher",boolmarche);

        bool boolreculer = Input.GetKey(inputBack);
        GuyAnimation.SetBool("Reculer",boolreculer);

        bool boolsprint = Input.GetKey(KeyCode.LeftShift);
        GuyAnimation.SetBool("sprint",boolsprint);

        bool boolsaut = Input.GetKeyDown(KeyCode.Space);
        GuyAnimation.SetBool("Saut",boolsaut);

        GuyAnimation.SetBool("GroundCheck", isGrounded);
        

        //Marcher
        if (boolmarche == true && boolsprint == false)
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
            float yRotation = cam.transform.eulerAngles.y;
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler(0, yRotation, 0), Time.deltaTime*5);
        }
        
    
        //sprinter
        if (boolmarche == true && boolsprint == true )
        {
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
            float yRotation = cam.transform.eulerAngles.y;
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler(0, yRotation, 0), Time.deltaTime*5);
        }
    
        //Sprint à gauche
        if (Input.GetKey(inputLeft) && boolsprint == true)
        {
            transform.Translate(-runSpeed * Time.deltaTime,0,0);
        }

        //Sprint à droite
        if (Input.GetKey(inputRight) && boolsprint == true)
        {
            transform.Translate(runSpeed * Time.deltaTime,0,0);
        }

        if (Input.GetKey(inputBack))
        {
            transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);

        }


        //Marche à gauche
        if (Input.GetKey(inputLeft) && boolsprint == false )
        {
            transform.Translate(-petitspas,0,0);
        }

        //Marche à droite
        if (Input.GetKey(inputRight) && boolsprint == false)
        {
            transform.Translate(petitspas,0,0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded==true)
            {
                rb.AddForce(jumpSpeed*jumpForce, ForceMode.Impulse);
            }


    }
}
