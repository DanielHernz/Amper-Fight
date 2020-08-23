// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer que la bala de los tanques se destruya al tocar ciertas superficies.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaTanques : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
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
