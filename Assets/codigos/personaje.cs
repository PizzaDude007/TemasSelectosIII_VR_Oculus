using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{
    public Transform miraBala;
    public GameObject bala;
    public CharacterController personajeControl;
    public Vector3 mueve;
    public Vector3 velocidadPersonaje;
    public bool estaEnPiso;
    public float gravedad, aceleracionpersonaje, fuerzaSalto, fuerza, controlGiro;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Shoot"))
        {
            var balas = Instantiate(bala, miraBala);
            balas.GetComponent<Rigidbody>().AddForce(miraBala.transform.forward * fuerza * Time.deltaTime, ForceMode.Impulse);
            balas.transform.parent = null;
        }

        muevePersonaje();

    }
    //control del personaje
    public void muevePersonaje()
    {
        estaEnPiso = personajeControl.isGrounded;
        if (estaEnPiso && velocidadPersonaje.y < 0)
        {
            velocidadPersonaje.y = 0;
        }

        controlGiro = Input.GetAxis("AxisControlGiro");

        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                mueve = gameObject.transform.right;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                mueve = -gameObject.transform.right;
            }

        } 
        if(Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                mueve = gameObject.transform.forward;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                mueve = -gameObject.transform.forward;
            }
        }
        else //(Input.GetAxis("Vertical") == 0 && Input.GetAxis("Vertical") == 0)
            mueve = Vector3.zero;

        if (Input.GetButtonDown("Jump") && estaEnPiso)
        {
            velocidadPersonaje.y += Mathf.Sqrt(fuerzaSalto * -3.0f * gravedad);
        }


        personajeControl.Move(mueve * Time.deltaTime * aceleracionpersonaje);
        velocidadPersonaje.y += gravedad * Time.deltaTime;
        personajeControl.Move(velocidadPersonaje);
        gameObject.transform.RotateAroundLocal(new Vector3 (0,1,0), controlGiro*Time.deltaTime);

    }
}
