// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer que el tanque dispare cada cierto tiempo, además de soltar elementos cuando muera

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T02_L03 : MonoBehaviour
{
    public static bool Tanque02;

    public float VidaTanque;

    [SerializeField] Transform EspacioEnergía;
    [SerializeField] Transform EspacioMoneda;
    [SerializeField] Transform EspacioHerramienta;

    [SerializeField] Rigidbody2D Moneda;
    [SerializeField] Rigidbody2D Herramienta;
    [SerializeField] Rigidbody2D Energía;

    [SerializeField] Transform Cañon;
    [SerializeField] Rigidbody2D Bala;
    [SerializeField] int FuerzaDisparo;
    


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Disparo", 1f, 2.5f);

        VidaTanque = 25f;
    }

    // Update is called once per frame
    void Disparo()
    {
        if (Tanque02 == true)
        {
            var ProyectilPos0 = Instantiate(Bala) as Rigidbody2D;
            ProyectilPos0.transform.position = Cañon.position;
            ProyectilPos0.AddForce(Cañon.right * FuerzaDisparo);
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
