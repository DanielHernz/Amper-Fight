// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Complemetar con otro script para hacer aparecer el texto mostrado al final del demo

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MensajeFinal : MonoBehaviour
{
    public static Text Mensaje;

    // Start is called before the first frame update
    void Start()
    {
        Mensaje = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
