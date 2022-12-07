using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float tiempoVisible;
    public void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoVisible < 0)
            Destroy(this.gameObject);
        else
            tiempoVisible -= Time.deltaTime;
    }
}
