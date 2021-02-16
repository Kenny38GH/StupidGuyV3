using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jetpack : MonoBehaviour
{
    public Hold hold;
    public GameObject player;

    public Vector3 flyspeed;

    public float carbumax;
    public float carbu;
    public GameObject propulseur;
    public GameObject propulseur2;

    public GameObject fumee;
    RaycastHit hit;
    public Text carbu_text;

    bool IsGrounded()
    {
        return Physics.Raycast(player.transform.position,-player.transform.up, out hit, 3.11226f);
    }
    // Start is called before the first frame update
    void Start()
    {
        carbu = carbumax;
    }

    // Update is called once per frame
    void Update()
    {
        if(hold.jetpackOn == true && carbu >0)
        {
            Envoletoi();
        }

        if(Input.GetKey(KeyCode.Space) && carbu>0)
        {
            carbu-=1;
        }
        if(IsGrounded() && carbu < carbumax)
        {
            carbu+=1;
        }

        if(hold.jetpackOn== true)
        {
            carbu_text.text = carbu.ToString() + "L";
        }
        else
        {
            carbu_text.text = "";
        }
    }

    void Envoletoi()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Vector3 v = player.GetComponent<Rigidbody>().velocity;
            v.y = flyspeed.y;
            player.GetComponent<Rigidbody>().velocity = flyspeed;
            GameObject impactGO = Instantiate(fumee, propulseur.transform.position,propulseur.transform.rotation);
            GameObject impactGO2 = Instantiate(fumee, propulseur2.transform.position,propulseur2.transform.rotation);
            Destroy(impactGO,1.5f);
            Destroy(impactGO2,1.5f);
        }
    }
}