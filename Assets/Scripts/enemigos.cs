using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemigos : MonoBehaviour
{
    public Animator enemigoAnim; //El objeto para la maquina de estados
    public int valorAnim;
    public Transform personaje, posInicial;
    public Animator anim;
    public Collider vista, cobertura;
    public bool persigue, detectar;

    public NavMeshAgent agente;
    //public Transform posPersonaje;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //se debe cambiar la logica para que no se desactiven las colisiones y lo que entra en personaje vaya directo en un if aqui
        if (persigue && !detectar)
        {
            agente.destination = personaje.position;
            valorAnim = 1;
            //cobertura.enabled = false;
        }
        else
        {
            agente.destination = posInicial.position;
        }

        if(agente.transform.position == posInicial.position)
        {
            valorAnim = 0;
        }

        enemigoAnim.SetInteger("estado", valorAnim); //estado es el nombre del int en la maquina de estados
        
        //if (Input.GetMouseButton(1))
        //{
        //    //Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    //if(Physics.Raycast(movePosition, out var hitInfo))
        //    //{
        //    //    agente.SetDestination(hitInfo.point);
        //    //}
        //    //persigue();
        //    //agente.SetDestination(Camera.main.transform.position);
        //}

    }

    public void OnColisionEnter(Collision collision)
    {
        if(collision.collider.name == "bala")
        {
            valorAnim = 3;
        }
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.name == "Personaje")
        {
            persigue = true;
            vista.enabled = false;
            cobertura.enabled = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            valorAnim = 2;
        }
    }
    public void OnTrigerExit(Collider other)
    {
        persigue = false;
        cobertura.enabled = false;
        vista.enabled = true;
    }



    public void chase()
    {
        valorAnim = 1;
        agente.SetDestination(Camera.main.transform.position);
    }
}
