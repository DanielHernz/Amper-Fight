// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer disparar en tiro parabolico 3 balas al mismo tiempo, midiendo fuerzas gracias a triggers hijos con los que el PLAYER colisiona

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T04_L03 : MonoBehaviour
{
    public static bool Tanque04;
    public static bool Tanque0402;
    public static bool Tanque0403;

    public float VidaTanque;

    [SerializeField] Transform EspacioEnergía;
    [SerializeField] Transform EspacioMoneda;
    [SerializeField] Transform EspacioHerramienta;

    [SerializeField] Rigidbody2D Moneda;
    [SerializeField] Rigidbody2D Herramienta;
    [SerializeField] Rigidbody2D Energía;

    [SerializeField] Transform[] Cañon;
    [SerializeField] Rigidbody2D Bala;
    [SerializeField] int FuerzaDisparo01;
    [SerializeField] int FuerzaDisparo0102;
    [SerializeField] int FuerzaDisparo0103;

    [SerializeField] int FuerzaDisparo02;
    [SerializeField] int FuerzaDisparo0202;
    [SerializeField] int FuerzaDisparo0203;

    [SerializeField] int FuerzaDisparo03;
    [SerializeField] int FuerzaDisparo0302;
    [SerializeField] int FuerzaDisparo0303;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Disparo", 1f, 2.5f);
        InvokeRepeating("Disparo02", 1f, 2.5f);
        InvokeRepeating("Disparo03", 1f, 2.5f);


        VidaTanque = 50f;
    }

    // Update is called once per frame
    void Disparo()
    {
        if (Tanque04 == true)
        {
            var ProyectilPos0 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos0.transform.position = Cañon[0].position;
            ProyectilPos0.AddForce(Cañon[0].right * FuerzaDisparo01);
            ProyectilPos0.AddForce(Cañon[0].up * FuerzaDisparo01);

            var ProyectilPos1 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos1.transform.position = Cañon[1].position;
            ProyectilPos1.AddForce(Cañon[1].right * FuerzaDisparo0102);
            ProyectilPos1.AddForce(Cañon[1].up * FuerzaDisparo0102);

            var ProyectilPos2 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos2.transform.position = Cañon[2].position;
            ProyectilPos2.AddForce(Cañon[2].right * FuerzaDisparo0103);
            ProyectilPos2.AddForce(Cañon[2].up * FuerzaDisparo0103);
        }
    }

    void Disparo02()
    {
        if (Tanque0402 == true)
        {
            var ProyectilPos0 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos0.transform.position = Cañon[0].position;
            ProyectilPos0.AddForce(Cañon[0].right * FuerzaDisparo02);
            ProyectilPos0.AddForce(Cañon[0].up * FuerzaDisparo02);

            var ProyectilPos1 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos1.transform.position = Cañon[1].position;
            ProyectilPos1.AddForce(Cañon[1].right * FuerzaDisparo0202);
            ProyectilPos1.AddForce(Cañon[1].up * FuerzaDisparo0202);

            var ProyectilPos2 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos2.transform.position = Cañon[2].position;
            ProyectilPos2.AddForce(Cañon[2].right * FuerzaDisparo0203);
            ProyectilPos2.AddForce(Cañon[2].up * FuerzaDisparo0203);
        }
    }

    void Disparo03()
    {
        if (Tanque0403 == true)
        {
            var ProyectilPos0 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos0.transform.position = Cañon[0].position;
            ProyectilPos0.AddForce(Cañon[0].right * FuerzaDisparo03);
            ProyectilPos0.AddForce(Cañon[0].up * FuerzaDisparo03);

            var ProyectilPos1 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos1.transform.position = Cañon[1].position;
            ProyectilPos1.AddForce(Cañon[1].right * FuerzaDisparo0302);
            ProyectilPos1.AddForce(Cañon[1].up * FuerzaDisparo0302);

            var ProyectilPos2 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos2.transform.position = Cañon[2].position;
            ProyectilPos2.AddForce(Cañon[2].right * FuerzaDisparo0303);
            ProyectilPos2.AddForce(Cañon[2].up * FuerzaDisparo0303);
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
