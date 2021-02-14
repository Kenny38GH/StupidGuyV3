using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modif_in_game : MonoBehaviour
{
    public GameObject[] mains;
    public GameObject[] pieds;
    public GameObject[] bras;
    private int mainactuelle;
    public bool changementfait = false;
    public ParticleSystem blood;
    public Shooting_Enemy shooten;
    



    // Start is called before the first frame update

    void Start()
    {

    mains[2].SetActive(false); 
    blood.Stop();
    
    }

    // Update is called once per frame
    void Update()
    {
    
        if(shooten.tombe == true)
        {
           mainactuelle = 1;

        }

        if (mainactuelle == 1 && changementfait == false )
        {
            //for (int i = 0; i < mains.Length; i++) 
            //{
              //  if(i == mainactuelle)
                //{
                  //  mains[i].SetActive(true);
               // }
                //else
                //{
                  //  mains[i].SetActive(false);
                //}
            //}
            mains[2].SetActive(true);
            mains[2].transform.position = mains[0].transform.position;
            mains[2].transform.rotation = mains[0].transform.rotation;
            blood.Play();        
            mains[0].SetActive(false);
            changementfait = true;
                
        } 
    }
}