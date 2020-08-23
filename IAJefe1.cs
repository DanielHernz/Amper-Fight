// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Definir los tiempos de espera para volver a repetir los ataques del jefe.
// Si el jefe pierde cada cuarto de vida, el tiempo entre ataques se vuelve menor.
// Tambien el Jefe mide fuerzas de disparo entre sus ataques con ayuda de triggers hijos que el PLAYER toca.

// Es el script más avanzado y estable que he hecho en este demo.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAJefe1 : MonoBehaviour
{
    public bool DerrotaJefe01 = false;

    public int VidaJefe1 = 1000;
    public float TiempoCargaAtaque;
    public float Timer = 0f;

    public int FuerzaDisparoAtaque01;
    public int FuerzaDisparoAtaque02;
    public int FuerzaCercaniaAtaque01;
    public int FuerzaCercaniaAtaque02;

    public static bool PlayerOnSiteJefe1 = false;
    public static bool Zona1 = false;
    public static bool Zona2 = false;
    public static bool Zona3 = false;

    public int VecesAtaque01 = 0;
    public int VecesAtaque02 = 0;

    public int AlterarTimerAtaque01 = 0;
    public int AlterarTimerAtaque02 = 0;
    public bool PrimerCuartoPerdido = false;
    public bool SegundoCuartoPerdido = false;
    public bool TercerCuartoPerdido = false;

    public bool AllowAtaque01;
    public bool AllowAtaque02;

    public bool AllowLut = false;

    [SerializeField] Transform Cañon;
    [SerializeField] Rigidbody2D BalaPequeña;
    [SerializeField] Rigidbody2D BalaGrande;
    [SerializeField] Rigidbody2D Moneda;
    [SerializeField] Rigidbody2D Herramienta;
    [SerializeField] Transform EspacioMoneda;
    [SerializeField] Transform EspacioHerramienta;

    // Start is called before the first frame update
    void Start()
    {
        DerrotaJefe01 = false;
        
        InvokeRepeating("Ataque01", 0f, 0.1f);
        InvokeRepeating("Ataque02", 0f, 2.5f);

        AllowAtaque01 = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (VidaJefe1 >= 1)
        {
            if (PlayerOnSiteJefe1 == true)
            {
                Timer += Time.deltaTime;
            }

            if (VidaJefe1 <= 250)
            {
                PrimerCuartoPerdido = false;
                SegundoCuartoPerdido = false;
                TercerCuartoPerdido = true;
                if (TercerCuartoPerdido == true)
                {
                    AlterarTimerAtaque01 = 3;
                }
            }

            if (VidaJefe1 <= 500)
            {
                PrimerCuartoPerdido = false;
                SegundoCuartoPerdido = true;
                if (SegundoCuartoPerdido == true)
                {
                    AlterarTimerAtaque01 = 2;
                }
            }

            if (VidaJefe1 <= 750)
            {
                PrimerCuartoPerdido = true;
                if (PrimerCuartoPerdido == true)
                {
                    AlterarTimerAtaque01 = 1;
                }
            }
        }
        if (VidaJefe1 <= 0)
        {
            AllowAtaque01 = false;
            AllowAtaque02 = false;
            AllowLut = true; // Variable buleana de emergencia útil para evitar un bucle infinito.

            if (AllowLut == true)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (i <= 20)
                    {
                        var Lut2 = Instantiate(Herramienta) as Rigidbody2D;
                        Lut2.transform.position = EspacioHerramienta.position;

                        var Lut = Instantiate(Moneda) as Rigidbody2D;
                        Lut.transform.position = EspacioMoneda.position;
                    }
                }
            }

            DerrotaJefe01 = true;
            Destroy(this.gameObject);
        }
    }

    void Ataque01()
    {
        if (AllowAtaque01 == true)
        {
            if (Timer >= 4 - AlterarTimerAtaque01)
            {
                if (Zona1 == true)
                {
                    FuerzaDisparoAtaque01 = 5200;
                    FuerzaCercaniaAtaque01 = 600;                   
                }
                if (Zona2 == true)
                {
                    FuerzaDisparoAtaque01 = 4600;
                    FuerzaCercaniaAtaque01 = 1000;                    
                }

                if (Zona3 == true)
                {
                    FuerzaDisparoAtaque01 = 4600;
                    FuerzaCercaniaAtaque01 = 1400;              
                }
                var Rafaga = Instantiate(BalaPequeña) as Rigidbody2D;
                Rafaga.transform.position = Cañon.position;
                Rafaga.AddForce(Cañon.right * -FuerzaDisparoAtaque01);
                Rafaga.AddForce(Cañon.up * -FuerzaCercaniaAtaque01);
            }
            if (Timer >= 9)
            {
                VecesAtaque01++;
                Timer = 0;
            }
            if (VecesAtaque01 == 3)
            {
                AllowAtaque01 = false;
                AllowAtaque02 = true;
                VecesAtaque01 = 0;
            }
        }
    }
    void Ataque02()
    {
        if (AllowAtaque02)
        {
            if (Timer >= 3)
            {
                if (Zona1 == true)
                {
                    FuerzaDisparoAtaque02 = 6200;
                    FuerzaCercaniaAtaque02 = 600;
                }
                if (Zona2 == true)
                {
                    FuerzaDisparoAtaque02 = 6200;
                    FuerzaCercaniaAtaque02 = 1000;
                }

                if (Zona3 == true)
                {
                    FuerzaDisparoAtaque02 = 5800;
                    FuerzaCercaniaAtaque02 = 1400;
                }
                var Rafaga = Instantiate(BalaGrande) as Rigidbody2D;
                Rafaga.transform.position = Cañon.position;
                Rafaga.AddForce(Cañon.right * -FuerzaDisparoAtaque02);
                Rafaga.AddForce(Cañon.up * -FuerzaCercaniaAtaque02);
                VecesAtaque02++;
            }
            if (VecesAtaque02 == 6)
            {
                AllowAtaque01 = true;
                AllowAtaque02 = false;
                VecesAtaque02 = 0;
                Timer = 0;
            }
        }
    }

    // Cantidad de vida restada con cada ataque del PLAYER

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Golpe" || collision.gameObject.name == "Golpe (1)")
        {
            VidaJefe1 = VidaJefe1 - 15;
        }

        if (collision.gameObject.name == "Relampagos" || collision.gameObject.name == "Relampagos (1)")
        {
            VidaJefe1 = VidaJefe1 - 100;
        }

        if (collision.gameObject.name == "Laser" || collision.gameObject.name == "Laser (1)")
        {
            VidaJefe1 = VidaJefe1 - 400;
        }

        if (collision.gameObject.tag == "BalaAmper")
        {
            VidaJefe1 = VidaJefe1 - 10;
        }
    }
}
