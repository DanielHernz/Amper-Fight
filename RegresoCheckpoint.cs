// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Ayudar a otros dos scripts a reiniciar la escena si el PLAYER cae en acido o termina su vida

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manipular escenas

public class RegresoCheckpoint : MonoBehaviour
{
    ControlesJugador VidaJugador;
    private IACheckpoint IAcheck; // Script complemento de la mecanica
    public static bool CaidaAcido;

    public static bool RespawnHecho;

    // Start is called before the first frame update
    void Start()
    {
        RespawnHecho = false; 
        CaidaAcido = false;

        IAcheck = GameObject.FindGameObjectWithTag("IAcheck").GetComponent<IACheckpoint>(); 
        transform.position = IAcheck.UltimoCheckpoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (CaidaAcido == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            RespawnHecho = true;
            //VidaJugador.Vida = VidaJugador.Vida - 15;
        }
    }
}
