// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Manipular la aparición y que pueda interactuar con otros gameObject el escudo con el flix activado

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoFrontFlipX : MonoBehaviour
{
    // Capturamos el render y el collider trigger para luego introducirlos al script y poder alterar su dos propiedades.
    // Utilizo dos scripts ya que desconocía si podía alterar el flip X y Y mediante codigos.

    [SerializeField] ControlesJugador AmperScript;
    public SpriteRenderer VisibilidadEscudo;
    public EdgeCollider2D ProtecciónEscudo;

    // Start is called before the first frame update
    void Start()
    {
        VisibilidadEscudo = GetComponent<SpriteRenderer>();
        ProtecciónEscudo = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
