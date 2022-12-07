using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tiempo : MonoBehaviour
{
    public float TiempoRestante;
    public bool TiempoActivo = false;

    public TMP_Text TimerTxt;

    // Start is called before the first frame update
    void Start()
    {
        TiempoActivo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TiempoActivo)
        {
            if(TiempoRestante > 0)
            {
                TiempoRestante -= Time.deltaTime;
                actualizaTiempo(TiempoRestante);
            }
            else
            {
                print("Se acabo el tiempo");
                TiempoRestante = 0;
                TiempoActivo = false;
            }
        }
    }

    void actualizaTiempo(float tiempoActual)
    {
        tiempoActual += 1;

        float minutos = Mathf.FloorToInt(tiempoActual / 60);
        float segundos = Mathf.FloorToInt(tiempoActual % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public void setTiempoRestante(float TiempoRestante)
    {
        this.TiempoRestante = TiempoRestante;
    }
}
