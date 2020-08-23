// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Manipular al golpe con el flipx activado

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpeFlipX : MonoBehaviour
{
    // Capturamos el render y el collider trigger para luego introducirlos al script y poder alterar su dos propiedades.

    public EdgeCollider2D TriggerGolpe;
    public SpriteRenderer VisibilidadGolpe;

    // Start is called before the first frame update
    void Start()
    {
        TriggerGolpe = GetComponent<EdgeCollider2D>();
        VisibilidadGolpe = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
