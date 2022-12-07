using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemigos : MonoBehaviour
{
    public zonaAtaque atacar;
    public Transform personaje, posInicial;
    public NavMeshAgent enemigoNav;
    public Animator enemigoAnim;
    public int valorAnim;
    public bool persigue,detectar;
    // Update is called once per frame
    void Update()
    {
        
           
        if (valorAnim != 3)
        {
            if (persigue && !detectar)
            {
                enemigoNav.destination = personaje.position;
                valorAnim = 1;

            }
            if (atacar.ataque)
                valorAnim = 2;
            if (persigue && detectar)
            {

                valorAnim = 2;

            }
        }
        else
            enemigoNav.isStopped = true;
        enemigoAnim.SetInteger("estado", valorAnim);
        

        
            
        
    }
    public void OnTriggerEnter(Collider vista1)
    {
        
        
        if (vista1.tag == "Player")
        {
            print("detecta");
            detectar = true;
            
        }


    }

    public void OnTriggerStay(Collider other)
    {
        if (other.name == "personaje")
        {
            persigue = true;
            
        }
        

    }
    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.name == "bala(Clone)") {
            print("balazo");
            valorAnim = 3;
            
        }
    }
    public void OnTriggerExit(Collider other)
    {
        persigue = false;
        
    }

}
