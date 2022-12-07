using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonaAtaque : MonoBehaviour
{
    public bool ataque;
    public void OnTriggerEnter(Collider other)
    {
        if(other.name=="personaje")
            ataque = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
