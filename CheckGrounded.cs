// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Saber si el PLAYER esta en una superficie para poder saltar, asi evitamos saltos infinitos que hacen volar al PLAYER

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    public static bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
