// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer que el asesino dispare cada cierto tiempo, apoyado con el script madre del PLAYER
// Fue muy tarde para averigar hacer un script generico para todos los asesinos

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EA_L02_09 : MonoBehaviour
{
    public int VidaAsesino;

    public static bool EnemigoAsesino_9;

    [SerializeField] Transform[] Cañon;

    [SerializeField] Rigidbody2D Bala;
    [SerializeField] int FuerzaDisparo;

    public float Timer;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Rafaga", 1f, 0.1f);
        Timer = 0f;

        VidaAsesino = 10;
    }

    private void Update()
    {
        if (EnemigoAsesino_9 == true)
        {
            Timer += Time.deltaTime;
            Debug.Log(Timer);
        }

        if (VidaAsesino <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Rafaga()
    {
        if (EnemigoAsesino_9 == true)
        {
            if (Timer <= 3)
            {
                var ProyectilPos0 = Instantiate(Bala) as Rigidbody2D;
                ProyectilPos0.transform.position = Cañon[0].position;
                ProyectilPos0.AddForce(Cañon[0].right * -FuerzaDisparo);

                var ProyectilPos1 = Instantiate(Bala) as Rigidbody2D;
                ProyectilPos1.transform.position = Cañon[1].position;
                ProyectilPos1.AddForce(Cañon[1].right * -FuerzaDisparo);
            }
        }

        if (Timer >= 5f)
        {
            Timer = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Golpe" || collision.gameObject.name == "Golpe (1)")
        {
            VidaAsesino = VidaAsesino - 2;
        }

        if (collision.gameObject.name == "Relampagos" || collision.gameObject.name == "Relampagos (1)")
        {
            VidaAsesino = VidaAsesino - 5;
        }

        if (collision.gameObject.name == "Laser" || collision.gameObject.name == "Laser (1)")
        {
            VidaAsesino = VidaAsesino - 10;
        }

        if (collision.gameObject.tag == "BalaAmper")
        {
            VidaAsesino = VidaAsesino - 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BalaAmper")
        {
            VidaAsesino = VidaAsesino - 1;
        }
    }
}
