using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemigos : MonoBehaviour
{
    public Animator enemigoAnim; //El objeto para la maquina de estados
    public int valorAnim;

    public NavMeshAgent agente;
    //public Transform posPersonaje;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemigoAnim.SetInteger("estado", valorAnim); //estado es el nombre del int en la maquina de estados

        if (Input.GetMouseButton(1))
        {
            //Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if(Physics.Raycast(movePosition, out var hitInfo))
            //{
            //    agente.SetDestination(hitInfo.point);
            //}
            persigue();
            //agente.SetDestination(Camera.main.transform.position);
        }

    }

    public void persigue()
    {
        valorAnim = 1;
        agente.SetDestination(Camera.main.transform.position);
    }
}
