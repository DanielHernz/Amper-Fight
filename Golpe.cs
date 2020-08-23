// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Mostrar al golpe sin el flipx activado

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe : MonoBehaviour
{
    // Capturamos el render y el collider trigger para luego introducirlos al script y poder alterar su dos propiedades.
    // Utilizo dos scripts ya que desconocía si podía alterar el flip X y Y mediante codigos.

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
