// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer destruir las balas grandes del jefe cuando toque ciertas superficies

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala02Jefe01 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Piso")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "EscudoFrontal")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "EscudoFrontal (1)")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Pared")
        {
            Destroy(this.gameObject);
        }
    }
}
