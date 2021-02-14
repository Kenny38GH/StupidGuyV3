using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Can_Take : MonoBehaviour
{
    public Hold hold;
    public Text texte_take;
    public Text texte_take_arme;

    // Start is called before the first frame update
    void Start()
    {
        texte_take.text = "";
        texte_take_arme.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(hold.cam.transform.position,hold.cam.transform.forward, out hit, hold.rangegrab))
        {
            if(hit.collider.tag=="Objet" && hold.objetoui == false)
            {
                texte_take.text = "Grab [F]";
            }
            else
            {
                texte_take.text = "";
            } 
            if(hit.collider.tag=="Weapon" && hold.oui == false)    
            {
                texte_take_arme.text = "Grab Weapon [F]";
            }  
            else
            {
                texte_take_arme.text = "";
            } 
        }   
    }
}
