// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer que el asesino dispare cada cierto tiempo, apoyado con el script madre del PLAYER
// Fue muy tarde para averigar hacer un script generico para todos los asesinos

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EA_L02_04 : MonoBehaviour
{
    public int VidaAsesino;

    public bool ConMandoble;
    public bool SinMandoble;

    public bool AllowLut;

    public static bool EnemigoAsesino_4;

    [SerializeField] Transform[] Cañon;
    [SerializeField] Transform[] EspacioMoneda;
    [SerializeField] Transform[] EspacioHerramienta;

    [SerializeField] Rigidbody2D Bala;
    [SerializeField] int FuerzaDisparo;

    [SerializeField] Rigidbody2D Moneda;
    [SerializeField] Rigidbody2D Herramienta;
    [SerializeField] Rigidbody2D LutEnergía;

    public float Timer;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Rafaga", 1f, 0.1f);
        Timer = 0f;

        VidaAsesino = 10;

        ConMandoble = false;
        SinMandoble = false;

        AllowLut = true;
    }

    private void Update()
    {
        if (EnemigoAsesino_4 == true)
        {
            Timer += Time.deltaTime;
            Debug.Log(Timer);
        }

        if (VidaAsesino <= 0)
        {
            if (ConMandoble == true)
            {
                if (AllowLut == true)
                {
                    //Lut supremo
                    var Lut = Instantiate(Moneda) as Rigidbody2D;
                    Lut.transform.position = EspacioMoneda[0].position;
                    EnemigoAsesino_4 = false;

                    var Lut01 = Instantiate(Moneda) as Rigidbody2D;
                    Lut01.transform.position = EspacioMoneda[1].position;
                    EnemigoAsesino_4 = false;

                    var Lut02 = Instantiate(Moneda) as Rigidbody2D;
                    Lut02.transform.position = EspacioMoneda[2].position;
                    EnemigoAsesino_4 = false;

                    var Lut3 = Instantiate(LutEnergía) as Rigidbody2D;
                    Lut3.transform.position = Cañon[0].position;
                    EnemigoAsesino_4 = false;

                    var Lut301 = Instantiate(LutEnergía) as Rigidbody2D;
                    Lut301.transform.position = Cañon[1].position;

                    AllowLut = false;
                    EnemigoAsesino_4 = false;
                    Destroy(this.gameObject);
                }
            }
        }

        if (VidaAsesino <= 0)
        {
            if (SinMandoble == true)
            {
                if (AllowLut == true)
                {
                    //Lut bajo
                    var Lut2 = Instantiate(Herramienta) as Rigidbody2D;
                    Lut2.transform.position = EspacioHerramienta[0].position;

                    var Lut201 = Instantiate(Herramienta) as Rigidbody2D;
                    Lut201.transform.position = EspacioHerramienta[1].position;

                    var Lut202 = Instantiate(Herramienta) as Rigidbody2D;
                    Lut202.transform.position = EspacioHerramienta[2].position;

                    AllowLut = false;
                    EnemigoAsesino_4 = false;
                    Destroy(this.gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Rafaga()
    {
        if (EnemigoAsesino_4 == true)
        {
            if (Timer <= 3)
            {
                var ProyectilPos0 = Instantiate(Bala) as Rigidbody2D;
                ProyectilPos0.transform.position = Cañon[0].position;
                ProyectilPos0.AddForce(Cañon[0].right * FuerzaDisparo);

                var ProyectilPos1 = Instantiate(Bala) as Rigidbody2D;
                ProyectilPos1.transform.position = Cañon[1].position;
                ProyectilPos1.AddForce(Cañon[1].right * FuerzaDisparo);
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
            ConMandoble = true;
            VidaAsesino = VidaAsesino - 2;
        }

        if (collision.gameObject.name == "Relampagos" || collision.gameObject.name == "Relampagos (1)")
        {
            SinMandoble = true;
            VidaAsesino = VidaAsesino - 5;
        }

        if (collision.gameObject.name == "Laser" || collision.gameObject.name == "Laser (1)")
        {
            SinMandoble = true;
            VidaAsesino = VidaAsesino - 10;
        }

        if (collision.gameObject.tag == "BalaAmper")
        {
            VidaAsesino = VidaAsesino - 1;
            SinMandoble = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BalaAmper")
        {
            VidaAsesino = VidaAsesino - 1;
            SinMandoble = true;
        }
    }
}
