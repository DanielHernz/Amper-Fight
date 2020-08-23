// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Manipular a los relampagos con el flix desactivado

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relampagos : MonoBehaviour
{
    // Es lo mismo con el Script Relampagos Flip X, solo que la unica diferencia es que en el software, uno si tiene activado el flip x, cosa que quiza pudo solucionarse en un solo script.

    [SerializeField] ControlesJugador AmperScript;
    public SpriteRenderer ApariciónRelampagos;
    public PolygonCollider2D TriggerRelampagos;

    // Start is called before the first frame update
    void Start()
    {
        ApariciónRelampagos = GetComponent<SpriteRenderer>();
        TriggerRelampagos = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
