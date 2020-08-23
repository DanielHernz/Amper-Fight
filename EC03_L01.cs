// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer que el enemigo asesino dispare cada cierto tiempo, apoyado con el script madre del PLAYER
// Fue muy tarde para averigar hacer un script generico para todos 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EC03_L01 : MonoBehaviour
{
    public int VidaEnemigoComun;

    public bool ConMandoble;
    public bool SinMandoble;

    public bool AllowLut;

    public static bool EnemigoComun_3;

    [SerializeField] Transform[] Cañon;
    [SerializeField] Transform[] EspacioMoneda;
    [SerializeField] Transform[] EspacioHerramienta;

    [SerializeField] Rigidbody2D Bala;
    [SerializeField] int FuerzaDisparo;

    [SerializeField] Rigidbody2D Moneda;
    [SerializeField] Rigidbody2D Herramienta;
    [SerializeField] Rigidbody2D LutEnergía;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 1f, 2f);

        VidaEnemigoComun = 5;

        ConMandoble = false;
        SinMandoble = false;

        AllowLut = true;
    }

    // Update is called once per frame
    void Shoot()
    {
        if (EnemigoComun_3 == true)
        {
            var ProyectilPos0 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos0.transform.position = Cañon[0].position;
            ProyectilPos0.AddForce(Cañon[0].right * FuerzaDisparo);

            var ProyectilPos1 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos1.transform.position = Cañon[1].position;
            ProyectilPos1.AddForce(Cañon[1].right * FuerzaDisparo);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Golpe" || collision.gameObject.name == "Golpe (1)")
        {
            ConMandoble = true;
            VidaEnemigoComun = VidaEnemigoComun - 2;
        }

        if (collision.gameObject.name == "Relampagos" || collision.gameObject.name == "Relampagos (1)")
        {
            SinMandoble = true;
            VidaEnemigoComun = VidaEnemigoComun - 5;
        }

        if (collision.gameObject.name == "Laser" || collision.gameObject.name == "Laser (1)")
        {
            SinMandoble = true;
            VidaEnemigoComun = VidaEnemigoComun - 5;
        }

        if (collision.gameObject.tag == "BalaAmper")
        {
            VidaEnemigoComun = VidaEnemigoComun - 1;
            SinMandoble = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BalaAmper")
        {
            VidaEnemigoComun = VidaEnemigoComun - 1;
            SinMandoble = true;
        }
    }

    void Update()
    {
        if (VidaEnemigoComun <= 0)
        {
            if (ConMandoble == true)
            {
                if (AllowLut == true)
                {
                    //Lut supremo
                    var Lut = Instantiate(Moneda) as Rigidbody2D;
                    Lut.transform.position = EspacioMoneda[0].position;
                    EnemigoComun_3 = false;

                    var Lut01 = Instantiate(Moneda) as Rigidbody2D;
                    Lut01.transform.position = EspacioMoneda[1].position;
                    EnemigoComun_3 = false;

                    var Lut3 = Instantiate(LutEnergía) as Rigidbody2D;
                    Lut3.transform.position = Cañon[0].position;
                    EnemigoComun_3 = false;

                    var Lut301 = Instantiate(LutEnergía) as Rigidbody2D;
                    Lut301.transform.position = Cañon[1].position;

                    AllowLut = false;
                    EnemigoComun_3 = false;
                    Destroy(this.gameObject);
                }
            }
        }

        if (VidaEnemigoComun <= 0)
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

                    AllowLut = false;
                    EnemigoComun_3 = false;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
