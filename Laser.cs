// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Manipular al laser sin el flipx desactivado

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Capturamos el render y el collider trigger para luego introducirlos al script y poder alterar su dos propiedades.

    [SerializeField] ControlesJugador AmperScript;
    public SpriteRenderer ApariciónLaser;
    public CapsuleCollider2D TriggerLaser;

    // Start is called before the first frame update
    void Start()
    {
        ApariciónLaser = GetComponent<SpriteRenderer>();
        TriggerLaser = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
