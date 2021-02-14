using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CharacterMotor : MonoBehaviour {
 
    // Animations du perso
    Animation animations;

    // Vitesse de deplacement
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;
 
    // Inputs
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;
 
    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;
 
    void Start () {
        animations = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }
 
    bool IsGrounded()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z), 0.07f);
    }
   
    void Update () {

            // si on avance
            if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0, 0, walkSpeed * Time.deltaTime);
                animations.Play("walk");
            }
 
            // Si on sprint
            if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(0, 0, runSpeed * Time.deltaTime);
                animations.Play("run");
            }
 
            // si on recule
            if (Input.GetKey(inputBack))
            {
                transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);
                animations.Play("walk");
            }
 
 
            // rotation a gauche
            if (Input.GetKey(inputLeft))
            {
                transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
            }
 
            // rotation a  droite
            if (Input.GetKey(inputRight))
            {
                transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
            }
 
            // Si on avance pas et que on recule pas non plus
            if (!Input.GetKey(inputFront) && !Input.GetKey(inputBack))
            {
                    animations.Play("idle");    
            }
 
            // Si on saute
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                // Preparation du saut
                Vector3 v = gameObject.GetComponent<  Rigidbody>().velocity;
                v.y = jumpSpeed.y;
 
                // Saut
                gameObject.GetComponent<  Rigidbody>().velocity = jumpSpeed;
            }

      
    }
 
}