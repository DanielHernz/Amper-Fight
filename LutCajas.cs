// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer que cuando el PLAYER golpee con una mecanica al gameObject, este haga aparecer ciertos prefabs con respectivos scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LutCajas : MonoBehaviour
{
    [SerializeField] Rigidbody2D LutVida;
    [SerializeField] Rigidbody2D LutEnergia;
    [SerializeField] Transform[] SpawnEnergiaLut;
    [SerializeField] Transform[] SpawnVidaLut;

    SpriteRenderer VisualizaciónCaja;
    BoxCollider2D ColliderCaja;
    public static bool DestrucciónCaja;

    void Start()
    {
        VisualizaciónCaja = GetComponent<SpriteRenderer>();
        ColliderCaja = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Golpe" || collision.gameObject.name == "Golpe (1)")
        {
            VisualizaciónCaja.enabled = false;
            ColliderCaja.enabled = false;
            DestrucciónCaja = true;
        }

        if (collision.gameObject.name == "Relampagos" || collision.gameObject.name == "Relampagos (1)")
        {
            VisualizaciónCaja.enabled = false;
            ColliderCaja.enabled = false;
            DestrucciónCaja = true;
        }

        if (collision.gameObject.name == "Laser" || collision.gameObject.name == "Laser (1)")
        {
            VisualizaciónCaja.enabled = false;
            ColliderCaja.enabled = false;
            DestrucciónCaja = true;
        }

        if (collision.gameObject.name == "Bala")
        {
            VisualizaciónCaja.enabled = false;
            ColliderCaja.enabled = false;
            DestrucciónCaja = true;
        }
    }

    private void Update()
    {
        if (DestrucciónCaja==true)
        {
            // LutVida

            var VidaPos = Instantiate(LutVida) as Rigidbody2D;
            VidaPos.transform.position = SpawnEnergiaLut[0].position;

            var VidaPos1 = Instantiate(LutVida) as Rigidbody2D;
            VidaPos1.transform.position = SpawnEnergiaLut[1].position;

            var VidaPos2 = Instantiate(LutVida) as Rigidbody2D;
            VidaPos2.transform.position = SpawnEnergiaLut[2].position;
            DestrucciónCaja = false;

            // LutEnergía

            var EnergiaPos = Instantiate(LutEnergia) as Rigidbody2D;
            EnergiaPos.transform.position = SpawnVidaLut[0].position;

            var EnergiaPos1 = Instantiate(LutEnergia) as Rigidbody2D;
            EnergiaPos1.transform.position = SpawnVidaLut[1].position;

            var EnergiaPos2 = Instantiate(LutEnergia) as Rigidbody2D;
            EnergiaPos2.transform.position = SpawnVidaLut[2].position;

            var EnergiaPos3 = Instantiate(LutEnergia) as Rigidbody2D;
            EnergiaPos3.transform.position = SpawnVidaLut[3].position;

            var EnergiaPos4 = Instantiate(LutEnergia) as Rigidbody2D;
            EnergiaPos4.transform.position = SpawnVidaLut[4].position;
            DestrucciónCaja = false;
        }
    }
}
