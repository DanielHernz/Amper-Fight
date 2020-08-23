// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer que el jugador pueda disparar en el escudo sin el flipx

using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class GatilloEscudo : MonoBehaviour
{
    // Explicado en GatilloEscudoFlipX **************************************************************

    public bool Gatillo;

    public bool Uno = true;
    public bool Dos = false;
    public bool Tres = false;

    [SerializeField] ControlesJugador AmperScript;
    [SerializeField] Rigidbody2D Bala;
    [SerializeField] Transform[] Cañones;
    [SerializeField] int FuerzaDisparo;

    public float Timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Gatillo == true)
        {
            Timer += Time.deltaTime;
            
            if (AmperScript.Energía < 1)
            {
                Gatillo = false;
            }
            else
            {

                if (Timer > 0.1 )
                {
                    if (Timer < 0.102)
                    {
                        var ProyectilPos0 = Instantiate(Bala) as Rigidbody2D;
                        ProyectilPos0.transform.position = Cañones[0].position;
                        ProyectilPos0.AddForce(Cañones[0].right * FuerzaDisparo);

                        AmperScript.Energía = AmperScript.Energía - 1;

                        Uno = false;
                        Dos = true;
                    }
                    
                }

                if (Timer > 0.2)
                {
                    if (Timer < 0.202)
                    {
                        var ProyectilPos1 = Instantiate(Bala) as Rigidbody2D;
                        ProyectilPos1.transform.position = Cañones[1].position;
                        ProyectilPos1.AddForce(Cañones[1].right * FuerzaDisparo);

                        AmperScript.Energía = AmperScript.Energía - 1;

                        Tres = true;
                    }
                    
                }

                if (Timer > 0.3)
                {
                    if (Timer < 0.302)
                    {
                        var ProyectilPos2 = Instantiate(Bala) as Rigidbody2D;
                        ProyectilPos2.transform.position = Cañones[2].position;
                        ProyectilPos2.AddForce(Cañones[2].right * FuerzaDisparo);

                        AmperScript.Energía = AmperScript.Energía - 1;

                        Uno = true;
                    }    
                }
                if (Timer>0.4)
                {
                    Timer = 0;
                }

            }
        }
    }
}
