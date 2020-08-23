// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Que el jugador pueda disparar mientras se cubre con el escudo con el flipx activado

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilloEscudoFlipX : MonoBehaviour
{
    public bool GatilloFlipX; 

    public float Timer = 0f;

    public bool Uno;
    public bool Dos;
    public bool Tres;

    [SerializeField] ControlesJugador AmperScript;
    [SerializeField] Rigidbody2D Bala;
    [SerializeField] Transform[] Cañones;
    [SerializeField] int FuerzaDisparo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GatilloFlipX == true) // Variable buleana que me permite controlar todas las acciones en su interior y evitar que se ejecuten mientras mecanicas externas estan en ejecución.
        {
            Timer += Time.deltaTime; // Inicio del timer 

            if (AmperScript.Energía < 1)
            {
                GatilloFlipX = false; // Seguro que puede ayudar a evitar el glich en la mayoría de los casos.
            }
            else
            {
                // Cada proyectil es lanzado cuando el timer llega a ciertas centesimas de segundo para evitar una rafaga y descontrol de los recursos

                if (Timer > 0.1)
                {
                    if (Timer < 0.102)
                    {
                        var ProyectilPos0 = Instantiate(Bala) as Rigidbody2D;
                        ProyectilPos0.transform.position = Cañones[0].position;
                        ProyectilPos0.AddForce(Cañones[0].right * -FuerzaDisparo);

                        AmperScript.Energía = AmperScript.Energía - 1;

                        Uno = false; // Variables resagadas de otro metodo que resulto en fracaso
                        Dos = true; // Estas variables siguen aquí para dar una idea sobre otro metodo mas eficas de disparo
                    }

                }

                if (Timer > 0.2)
                {
                    if (Timer < 0.202)
                    {
                        var ProyectilPos1 = Instantiate(Bala) as Rigidbody2D;
                        ProyectilPos1.transform.position = Cañones[1].position;
                        ProyectilPos1.AddForce(Cañones[1].right * -FuerzaDisparo);

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
                        ProyectilPos2.AddForce(Cañones[2].right * -FuerzaDisparo);

                        AmperScript.Energía = AmperScript.Energía - 1;

                        Uno = true;
                    }
                }

                // Para poder repetir los disparos, cuando el timer llega a cierto tiempo, se reinicia y comienza de nuevo en cero

                if (Timer > 0.4)
                {
                    Timer = 0;
                }

            }
        }
    }
}
