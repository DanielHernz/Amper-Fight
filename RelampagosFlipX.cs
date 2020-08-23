// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer que lso relampagos con el fliX activado aparezcan y puedan interactuar con otros GameObjects

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelampagosFlipX : MonoBehaviour
{
    [SerializeField] ControlesJugador AmperScript; // Añadimos el script madre del PLAYER 
    public SpriteRenderer ApariciónRelampagos; // Accedemos al spriteRenderer del gameObject Relampagos
    public PolygonCollider2D TriggerRelampagos; // Tambien su collider para evitar choques invisibles

    // Start is called before the first frame update
    void Start()
    {
        ApariciónRelampagos = GetComponent<SpriteRenderer>(); // Lo acoplamos para poder acceder sin problema a las dos propiedades
        TriggerRelampagos = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
