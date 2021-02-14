using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyControl : MonoBehaviour
{
    // Animations du perso
    Animation animations;

    // Vitesse de deplacement
    public float walkSpeed;
    public float turnSpeed;
    public float runSpeed;
    public float petitspas;
    // Inputs
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;
    public GameObject player;
    public Vector3 jumpSpeed;
    public float jumpForce = 2.0f;
    CapsuleCollider playerCollider;
    public GameObject cam;
    public float next_time;
    bool test2 = false;
    bool test4 = false;
    RaycastHit hit;
    Rigidbody rb;

    // Start is called before the first frame updatee
    //Add commentifezifbzif
    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }
    bool IsGrounded()
    {
        return Physics.Raycast(player.transform.position,-player.transform.up, out hit, 3.11226f);
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time);
        // si on avance
        if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
            animations.Play("rig|Walk_devant");
            float yRotation = cam.transform.eulerAngles.y;
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler(0, yRotation, 0), Time.deltaTime*5);
            test2 = false;
            test4= false;
        }

        if (!Input.GetKey(inputFront) & !Input.GetKey(inputBack) & !Input.GetKey(inputLeft) & !Input.GetKey(inputRight)) 
        {
            if(test2 ==false)
            {
                Invoke("Metho_Wait0", 0.0f);
                Invoke("test", 0.9166f);
            }
            if(test2 == true && test4 == false)
            {
                Invoke("Metho_Wait2",0.0f);
                Invoke("test3",5f);
            }
            if(test4 == true)
            {
                 Invoke("grattagedefion",0.0f);
                 Invoke("reset",2.2f);
            }
            

        }
        // Si on sprint
        if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
            animations.Play("rig|Run_boy_run");
            float yRotation = cam.transform.eulerAngles.y;
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler(0, yRotation, 0), Time.deltaTime*5);
            test2 = false;
            test4= false;
        }
        // Sprint à gauche
        if (Input.GetKey(inputLeft) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(-petitspas * 2,0,0);
            animations.Play("rig|Run_boy_run");
            test2 = false;
            test4= false;
        }
        // Sprint à droite
        if (Input.GetKey(inputRight) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(petitspas * 2,0,0);
            animations.Play("rig|Run_boy_run");
            test2 = false;
            test4= false;
        }
        // si on recule
        if (Input.GetKey(inputBack))
        {
            transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);
            animations.Play("rig|Walk_devant");
            test2 = false;
            test4= false;
        }
        // Marche à gauche
        if (Input.GetKey(inputLeft) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(-petitspas,0,0);
            animations.Play("rig|Walk_devant");
            test2 = false;
            test4= false;
        }

        // Marche a  droite
        if (Input.GetKey(inputRight) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(petitspas,0,0);
            animations.Play("rig|Walk_devant");
            test2 = false;
            test4= false;
        }
        // Si on saute
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            // Preparation du saut
            //Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            //v.y = jumpSpeed.y;
            // Saut
            //gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
            rb.AddForce(jumpSpeed*jumpForce, ForceMode.Impulse);
            animations.Play("jump");
            test2 = false;
            test4= false;
        }
    }
    void Metho_Wait0()
    {
        animations.Play("rig|Wait");
    }
    void test()
    {
        animations.Stop("rig|Wait");


        test2 = true;
    }

    void Metho_Wait2()
    {
        animations.Play("rig|Wait_suite");
    }

    void grattagedefion()
    {
        animations.Play("rig|gratte_de_cul");
    }

    void test3()
    {
        animations.Stop("rig|Wait_suite");
        test4 = true;

    }
    void reset()
    {
        animations.Stop("rig|gratte_de_cul");
        test4 = false;
    }
}