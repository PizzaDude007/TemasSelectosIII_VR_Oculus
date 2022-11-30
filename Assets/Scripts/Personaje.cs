using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public CharacterController personaje;
    public Vector3 velocidadPersonaje;
    public bool estaEnPiso;
    public float gravedad, aceleracionPersonaje, fuerzaSalto;

    //public Collider camina;
    public GameObject EnemigoObject;
    public enemigos Enemigo;

    // Start is called before the first frame update
    void Start()
    {
        Enemigo = EnemigoObject.GetComponent<enemigos>();
    }

    // Update is called once per frame
    void Update()
    {
        estaEnPiso = personaje.isGrounded;
        if (estaEnPiso && velocidadPersonaje.y < 0)
        {
            velocidadPersonaje.y = 0;
        }

        Vector3 mueve = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        personaje.Move(mueve * Time.deltaTime * aceleracionPersonaje);

        if (mueve != Vector3.zero)
        {
            mueve=gameObject.transform.forward;
        }

        velocidadPersonaje.y += gravedad * Time.deltaTime;
        personaje.Move(velocidadPersonaje * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Collider")
        {
            print("empieza persecusion");
            Enemigo.persigue();
        }
    }
}
