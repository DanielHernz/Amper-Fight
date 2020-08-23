// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer destruir al lut cuando el PLAYER lo toque, además de activar una buleana que con otro script; hace que lo acumule cada uno

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaLut : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
