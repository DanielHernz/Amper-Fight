// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer que el tanque dispare cada cierto tiempo, además de soltar elementos cuando muera
// Este mide fuerzas por variables buleanas y triggers hijos activados por el PLAYER.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T01_L03 : MonoBehaviour
{
    public static bool Tanque01;
    public static bool Tanque0102;
    public static bool Tanque0103;
    public static bool Tanque0104;
    public static bool Tanque0105;

    public float VidaTanque;

    [SerializeField] Transform Cañon;
    [SerializeField] Transform EspacioEnergía;
    [SerializeField] Transform EspacioMoneda;
    [SerializeField] Transform EspacioHerramienta;

    [SerializeField] Rigidbody2D Moneda;
    [SerializeField] Rigidbody2D Herramienta;
    [SerializeField] Rigidbody2D Energía;

    [SerializeField] Rigidbody2D Bala;
    [SerializeField] int FuerzaDisparo;
    [SerializeField] int FuerzaDisparo02;
    [SerializeField] int FuerzaDisparo03;
    [SerializeField] int FuerzaDisparo04;
    [SerializeField] int FuerzaDisparo05;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Disparo01", 1f, 2.5f);
        InvokeRepeating("Disparo02", 1f, 2.5f);
        InvokeRepeating("Disparo03", 1f, 2.5f);
        InvokeRepeating("Disparo04", 1f, 2.5f);
        InvokeRepeating("Disparo05", 1f, 2.5f);

        VidaTanque = 25f;

    }

    // Update is called once per frame
    void Disparo01()
    {
        if (Tanque01 == true)
        {
            var ProyectilPos0 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos0.transform.position = Cañon.position;
            ProyectilPos0.AddForce(Cañon.right * FuerzaDisparo);
        }
    }

    void Disparo02()
    {
        if (Tanque0102 == true)
        {
            var ProyectilPos2 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos2.transform.position = Cañon.position;
            ProyectilPos2.AddForce(Cañon.right * FuerzaDisparo02);
        }
    }

    void Disparo03()
    {
        if (Tanque0103 == true)
        {
            var ProyectilPos3 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos3.transform.position = Cañon.position;
            ProyectilPos3.AddForce(Cañon.right * FuerzaDisparo03);
        }
    }

    void Disparo04()
    {
        if (Tanque0104 == true)
        {
            var ProyectilPos4 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos4.transform.position = Cañon.position;
            ProyectilPos4.AddForce(Cañon.right * FuerzaDisparo04);
        }
    }

    void Disparo05()
    {
        if (Tanque0105 == true)
        {
            var ProyectilPos4 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos4.transform.position = Cañon.position;
            ProyectilPos4.AddForce(Cañon.right * FuerzaDisparo04);
        }
    }

    private void Update()
    {
        if (VidaTanque <= 0)
        {
            for (int i = 0; i < 20; i++)
            {
                if (i < 10)
                {
                    var Lut = Instantiate(Moneda) as Rigidbody2D;
                    Lut.transform.position = EspacioMoneda.position;
                }
                
                if (i <= 20)
                {
                    var Lut2 = Instantiate(Herramienta) as Rigidbody2D;
                    Lut2.transform.position = EspacioHerramienta.position;

                    var Lut3 = Instantiate(Energía) as Rigidbody2D;
                    Lut3.transform.position = EspacioEnergía.position;
                    Destroy(this.gameObject);
                }
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Golpe" || collision.gameObject.name == "Golpe (1)")
        {
            VidaTanque = VidaTanque - 1;
        }

        if (collision.gameObject.name == "Relampagos" || collision.gameObject.name == "Relampagos (1)")
        {
            VidaTanque = VidaTanque - 8;
        }

        if (collision.gameObject.name == "Laser" || collision.gameObject.name == "Laser (1)")
        {
            VidaTanque = VidaTanque - 20;
        }

        if (collision.gameObject.tag == "BalaAmper")
        {
            VidaTanque = VidaTanque - 1;
        }
    }

}
