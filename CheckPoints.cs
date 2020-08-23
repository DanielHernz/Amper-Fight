// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Junto a otros dos scripts, hacer que cuando se reinicie una escena por haber caido en acido o tener la vida en cero, reaparecer en el checkPoint respectivo a la escena

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    private IACheckpoint IAcheck;

    // Start is called before the first frame update
    void Start()
    {
        IAcheck = GameObject.FindGameObjectWithTag("IAcheck").GetComponent<IACheckpoint>();
    }
    private void OnTriggerEnter2D(Collider2D Otro)
    {
        if (Otro.CompareTag("Player"))
        {
            IAcheck.UltimoCheckpoint = transform.position;

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
