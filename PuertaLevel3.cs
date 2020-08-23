// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer que al una respectiva puerta, el PLAYER llegase al nivel tres

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaLevel3 : MonoBehaviour
{
    public static bool PuertaAbiertaNivel_3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || PuertaAbiertaNivel_3 == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }
    }
}
