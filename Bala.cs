// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer que las balas del PLAYER se destruyan al entrar en contacto conciertas superficies 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float DuraciónBalaAmper;
    public bool Impacto;

    private void Start()
    {
        DuraciónBalaAmper = 0f;
        Impacto = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Destroy(this.gameObject);
            Impacto = true;
        }
        if (collision.gameObject.tag == "Jefe")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "LimitesCollider")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Piso")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Pared")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Jefe")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "LimitesCollider")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Piso")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Pared")
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (Impacto == true)
        {
            DuraciónBalaAmper+=Time.deltaTime;
        }
        if (DuraciónBalaAmper >= 2)
        {
            Destroy(this.gameObject);
        }
    }
}
