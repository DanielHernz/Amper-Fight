// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Controlar al PLAYER y modificar o brindar apoyo al entorno con el que interactua.

using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI; // Canvas

public class ControlesJugador : MonoBehaviour
{
    // Variables integrales, flotantes y buleanas, asi como gameObjects que se relacionan con el PLAYER para poder hacer realidad las mecanicas del mismo 

    #region Variables

    [SerializeField] int FuerzaSalto;
    [SerializeField] int FuerzaDobleSalto;
    [SerializeField] bool CanDobleSalto;

    public Image BarraVida;
    public Image BarraEnergía;

    [SerializeField] int FuerzaMovimiento;
    [SerializeField] int FuerzaPropulsor;
    public float Vida;
    public float Energía;
    public bool Inmovilizado;
    public bool CubriendoseFront;
    public bool CubriendoseFrontFlipX;

    public int HerramientasGuardadas;
    public int MonedasGuardadas;


    Rigidbody2D Amper;
    [SerializeField] SpriteRenderer VisualizaciónAmper;
    [SerializeField] PolygonCollider2D AmperCollider;

    [SerializeField] Escudo EscudoScript;
    [SerializeField] EscudoFrontFlipX EscudoFrontFlipXScript;

    [SerializeField] Relampagos RelampagosScript;
    [SerializeField] RelampagosFlipX RelampagosFlipXScript;

    [SerializeField] Laser LaserScript;
    [SerializeField] LaserFlipX LaserFlipXScript;

    [SerializeField] Golpe GolpeScript;
    [SerializeField] GolpeFlipX GolpeFlipXScript;

    [SerializeField] GatilloEscudo GatilloEscudoScript;
    [SerializeField] GatilloEscudoFlipX GatilloEscudoFlipXScript;
    
    public static bool CheckPoint_Lobby;
    public static bool CheckPoint_1;
    public static bool CheckPoint_2;
    public static bool CheckPoint_4;

    public float VidaRestante;
    public float EnergíaRestante;
    public float VariableINT;

    
    public bool Final;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Valores iniciales con los que se empieza a jugar

        Vida = 100f;
        Energía = 80f;

        Amper = GetComponent<Rigidbody2D>();
        VisualizaciónAmper = GetComponent<SpriteRenderer>();

        // Las hacemos falsas para evitar que se mantengan verdaderas

        CubriendoseFront = false;
        CubriendoseFrontFlipX = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Final == true) // Hace que podamos ver lo que define el final del demo
        {
            MensajeFinal.Mensaje.enabled = true;
            PanelFinal.Panel.enabled = true;
        }

        #region Vida y energía

        // Delimitamos la vida y energía para que no salga de los valores establecidos en las mecanicas
        // Accedemos a los elementos del canvas y hacemos que se alteren con respecto a lso valores de la vida y energía en constante cambio

        Vida = Mathf.Clamp(Vida, 0, 100);
        Energía = Mathf.Clamp(Energía, 0, 100);

        BarraVida.fillAmount = Vida / 100;
        BarraEnergía.fillAmount = Energía / 100;




        if (Vida == 0) 
        {
            RegresoCheckpoint.CaidaAcido = true;
        }

        // Mecanica de recuperación de vida por energia
        // Como el ciclo for no permite variabkes flotantes, todo se resume en el orden de lectura de las filas del script y de condicionantes

        if (Input.GetKeyDown(KeyCode.E))
        {
            VariableINT = 100 - Vida;
            if (VariableINT >= Energía)
            {
                Vida = Vida + Energía;
                Energía = 0;
            }
            else
            {
                Energía = Energía - VariableINT;
                Vida = Vida + VariableINT;
            }
        }
        if (Input.GetKeyUp(KeyCode.E)) // Limitamos el movimiento y la ejecución de otras mecanicas mientras esta es ejecutada
        {
            Inmovilizado = false;
        }


        #endregion

        #region Movimiento

        // Mecanicas de movimiento como salto o movimiento a la izquierda y o derecha
        // Todo condicionado. Lo mejor de las buleanas

        if (Inmovilizado == false)
        {
            if (CheckGrounded.isGrounded == true)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    Amper.AddForce(Vector2.up * FuerzaSalto, ForceMode2D.Impulse);
                    
                }

              
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                if (CubriendoseFront == true)
                {
                    Amper.velocity = new Vector2(-FuerzaMovimiento, Amper.velocity.y);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Amper.AddForce(Vector2.left * FuerzaPropulsor, ForceMode2D.Impulse);
                    }  
                }
                
                if (CubriendoseFront == false)
                {
                    Amper.velocity = new Vector2(-FuerzaMovimiento, Amper.velocity.y);
                    VisualizaciónAmper.flipX = true;
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Amper.AddForce(Vector2.left * FuerzaPropulsor, ForceMode2D.Impulse);
                    }
                }
                
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (CubriendoseFrontFlipX == true)
                {
                    Amper.velocity = new Vector2(FuerzaMovimiento, Amper.velocity.y);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Amper.AddForce(Vector2.right * FuerzaPropulsor, ForceMode2D.Impulse);
                    }
                }

                if (CubriendoseFrontFlipX == false)
                {
                    Amper.velocity = new Vector2(FuerzaMovimiento, Amper.velocity.y);
                    VisualizaciónAmper.flipX = false;
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Amper.AddForce(Vector2.right * FuerzaPropulsor, ForceMode2D.Impulse);
                    }
                }
            }
        }

        
        #endregion

        #region Escudo Front
        
        // Con estas lineas complementamos con otros scripts para hecer que los escudos aparezcan con una instrucción y delimitantes.
        // Aquí alteramos el spriteRenderer y triggers albergados en otros scripts.


        if (VisualizaciónAmper.flipX == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                EscudoScript.VisibilidadEscudo.enabled = true;
                EscudoScript.ProtecciónEscudo.enabled = true;
                FuerzaMovimiento = FuerzaMovimiento / 2;
                FuerzaPropulsor = FuerzaPropulsor / 2;
                FuerzaSalto = FuerzaSalto / 2;

                CubriendoseFront = true;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                CubriendoseFront = false;

                EscudoScript.VisibilidadEscudo.enabled = false;
                EscudoScript.ProtecciónEscudo.enabled = false;
                FuerzaMovimiento = FuerzaMovimiento * 2;
                FuerzaPropulsor = FuerzaPropulsor * 2;
                FuerzaSalto = FuerzaSalto * 2;

                RelampagosScript.ApariciónRelampagos.enabled = false;
                RelampagosScript.TriggerRelampagos.enabled = false;

                LaserScript.ApariciónLaser.enabled = false;
                LaserScript.TriggerLaser.enabled = false;

                Inmovilizado = false;
            }
        }
        if (VisualizaciónAmper.flipX == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                EscudoFrontFlipXScript.VisibilidadEscudo.enabled = true;
                EscudoFrontFlipXScript.ProtecciónEscudo.enabled = true;
                FuerzaMovimiento = FuerzaMovimiento / 2;
                FuerzaPropulsor = FuerzaPropulsor / 2;
                FuerzaSalto = FuerzaSalto / 2;

                CubriendoseFrontFlipX = true;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                CubriendoseFrontFlipX = false;

                EscudoFrontFlipXScript.VisibilidadEscudo.enabled = false;
                EscudoFrontFlipXScript.ProtecciónEscudo.enabled = false;
                FuerzaMovimiento = FuerzaMovimiento * 2;
                FuerzaPropulsor = FuerzaPropulsor * 2;
                FuerzaSalto = FuerzaSalto * 2;

                //RelampagosScript.ApariciónRelampagos.enabled = false;
                //RelampagosScript.TriggerRelampagos.enabled = false;

                //LaserScript.ApariciónLaser.enabled = false;
                //LaserScript.TriggerLaser.enabled = false;

                Inmovilizado = false;
            }
        }
        #endregion

        #region Golpe

        // Mismo proceso de aparición del escudo con el golpe 

        if (Inmovilizado == false)
        {
            if (VisualizaciónAmper.flipX == false)
            {
                if (CubriendoseFront == false)
                {
                    if (Input.GetKey(KeyCode.LeftAlt))
                    {
                        GolpeScript.VisibilidadGolpe.enabled = true;
                        GolpeScript.TriggerGolpe.enabled = true;
                    }
                    if (Input.GetKeyUp(KeyCode.LeftAlt))
                    {
                        GolpeScript.VisibilidadGolpe.enabled = false;
                        GolpeScript.TriggerGolpe.enabled = false;
                    }
                }
            }

            if (VisualizaciónAmper.flipX == true)
            {
                if (CubriendoseFrontFlipX == false)
                {
                    if (Input.GetKey(KeyCode.LeftAlt))
                    {
                        GolpeFlipXScript.VisibilidadGolpe.enabled = true;
                        GolpeFlipXScript.TriggerGolpe.enabled = true;
                        
                    }
                    if (Input.GetKeyUp(KeyCode.LeftAlt))    
                    {
                        GolpeFlipXScript.VisibilidadGolpe.enabled = false;
                        GolpeFlipXScript.TriggerGolpe.enabled = false;
                    }
                }
            }
        }
        #endregion
        
        #region Ataque Relampagos
        if (CubriendoseFront == true)
        {
            if (Energía>=15)
            {
                
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Inmovilizado = true;
                    RelampagosScript.ApariciónRelampagos.enabled = true;
                    RelampagosScript.TriggerRelampagos.enabled = true;
                    Energía = Energía - 15;
                }

                if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    RelampagosScript.ApariciónRelampagos.enabled = false;
                    RelampagosScript.TriggerRelampagos.enabled = false;
                    Inmovilizado = false;
                }
            }
        }

        
        if (CubriendoseFrontFlipX == true)
        {
            if (Energía >= 15)
            {

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Inmovilizado = true;
                    RelampagosFlipXScript.ApariciónRelampagos.enabled = true;
                    RelampagosFlipXScript.TriggerRelampagos.enabled = true;
                    Energía = Energía - 15;
                }

                if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    RelampagosFlipXScript.ApariciónRelampagos.enabled = false;
                    RelampagosFlipXScript.TriggerRelampagos.enabled = false;
                    Inmovilizado = false;
                }
            }
        }
        #endregion
        
        #region Ataque Laser

        if (CubriendoseFront == true)
        {
            if (Energía >= 50)
            {
                if (Input.GetKeyDown(KeyCode.Keypad0))
                {
                    Inmovilizado = true;
                    LaserScript.ApariciónLaser.enabled = true;
                    LaserScript.TriggerLaser.enabled = true;
                    
                }

                if (Input.GetKeyUp(KeyCode.Keypad0))
                {
                    LaserScript.ApariciónLaser.enabled = false;
                    LaserScript.TriggerLaser.enabled = false;
                    Energía = Energía - 50;
                    Inmovilizado = false;
                }
            }
        }

        if (CubriendoseFrontFlipX == true)
        {
            if (Energía >= 50)
            {
                if (Input.GetKeyDown(KeyCode.Keypad0))
                {
                    Inmovilizado = true;
                    LaserFlipXScript.ApariciónLaser.enabled = true;
                    LaserFlipXScript.TriggerLaser.enabled = true;

                }

                if (Input.GetKeyUp(KeyCode.Keypad0))
                {
                    LaserFlipXScript.ApariciónLaser.enabled = false;
                    LaserFlipXScript.TriggerLaser.enabled = false;
                    Energía = Energía - 50;
                    Inmovilizado = false;
                }
            }
        }
        #endregion
        
        #region Escudo Disparos

        // Aquí hacemos que el jugador dispare con precionar un boton mientras cumpla con las variables
        // Otros scripts complementan esta mecanica.

        if (CubriendoseFront == true)
        {
            if (Energía>=2)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Inmovilizado = true;
                    GatilloEscudoScript.Gatillo = true;
                    
                }
                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    Inmovilizado = false;
                    GatilloEscudoScript.Gatillo = false;
                    
                }
            }
        }

        if (CubriendoseFrontFlipX == true)
        {
            if (Energía >= 2)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Inmovilizado = true;
                    GatilloEscudoFlipXScript.GatilloFlipX = true;
                }
                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    Inmovilizado = false;
                    GatilloEscudoFlipXScript.GatilloFlipX = false;
                }
            }
        }
        #endregion

        #region Pruebas
        
        #endregion
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Intento de una mecanica inconclusa en el demo

        if (Vida==0)
        {
            if (CheckPoint_Lobby == true)
            {
                Vida = 50;
                Energía = 25;
                //Transporte a la posada.
            }
            else
            {
                Vida = 25;
                Energía = 0;
                //Transporte posada.
            }
        }

        #region Lut

        // Ante la colision de colliders que no son trigger con un tag especifico para identificarlos, se generan acciones como incrementar vida, energía o recolectar monedas y herramientas para otras mecanicas inconclusas 

        if (collision.gameObject.tag == "VidaLut")
        {
            Vida = Vida + 20;
        }

        if (collision.gameObject.tag == "EnergiaLut")
        {
            Energía = Energía + 5;
        }

        if (collision.gameObject.tag == "Herramientas")
        {
            HerramientasGuardadas = HerramientasGuardadas + 1;
            Debug.Log("Una herramienta añadida");
        }

        if (collision.gameObject.tag == "Moneda")
        {
            MonedasGuardadas = MonedasGuardadas + 1;
            Debug.Log("Una moneda añadida");
        }

        #endregion

        #region Jefe 01 Balas

        // Establecemos el daño que hacen los ataques del jefe

        if (collision.gameObject.tag == "BalaPequeñaJefe01")
        {
            if (CubriendoseFront == true || CubriendoseFrontFlipX == true)
            {
                Debug.Log("Daño Bloqueado");
            }
            else
            {
                Vida = Vida - 3;
            }
        }

        if (collision.gameObject.tag == "BalaGrandeJefe01")
        {
            if (CubriendoseFront == true || CubriendoseFrontFlipX == true)
            {
                Vida = Vida - 5;
            }
            else
            {
                Vida = Vida - 15;
            }
        }

        #endregion
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region Trigger Enemigos Comunes

        // Nivel 1
        
        // Esto hace los enemigos comunes disparen cuando el PLAYER colisiona con triggers relacionados con los enemigos
        // Para evitar que los enemigos comunes disparen por siempre en caso de no ser eliminados, todas las buleanas son manipuladas en cada caso

        if (collision.gameObject.tag == "TriggerEC1")
        {
            EC01_L01.EnemigoComun_1 = true; //**
            EC02_L01.EnemigoComun_2 = false;
            EC03_L01.EnemigoComun_3 = false;
            EC04_L01.EnemigoComun_4 = false;
            EC05_L01.EnemigoComun_5 = false;
            EC06_L01.EnemigoComun_6 = false;
        }
        

        if (collision.gameObject.tag == "TriggerEC2")
        {
            EC01_L01.EnemigoComun_1 = false;
            EC02_L01.EnemigoComun_2 = true; //**
            EC03_L01.EnemigoComun_3 = false;
            EC04_L01.EnemigoComun_4 = false;
            EC05_L01.EnemigoComun_5 = false;
            EC06_L01.EnemigoComun_6 = false;
        }

        if (collision.gameObject.tag == "TriggerEC3")
        {
            EC01_L01.EnemigoComun_1 = false;
            EC02_L01.EnemigoComun_2 = false;
            EC03_L01.EnemigoComun_3 = true; //**
            EC04_L01.EnemigoComun_4 = true; //**
            EC05_L01.EnemigoComun_5 = false;
            EC06_L01.EnemigoComun_6 = false;
        }

        if (collision.gameObject.tag == "TriggerEC4")
        {
            EC01_L01.EnemigoComun_1 = false;
            EC02_L01.EnemigoComun_2 = false; 
            EC03_L01.EnemigoComun_3 = true; //**
            EC04_L01.EnemigoComun_4 = true; //**
            EC05_L01.EnemigoComun_5 = false;
            EC06_L01.EnemigoComun_6 = false;
        }

        if (collision.gameObject.tag == "TriggerEC5")
        {
            EC01_L01.EnemigoComun_1 = false;
            EC02_L01.EnemigoComun_2 = false; 
            EC03_L01.EnemigoComun_3 = false;
            EC04_L01.EnemigoComun_4 = false;
            EC05_L01.EnemigoComun_5 = true; //**
            EC06_L01.EnemigoComun_6 = false;
        }

        if (collision.gameObject.tag == "TriggerEC6")
        {
            EC01_L01.EnemigoComun_1 = false;
            EC02_L01.EnemigoComun_2 = false; 
            EC03_L01.EnemigoComun_3 = false;
            EC04_L01.EnemigoComun_4 = false;
            EC05_L01.EnemigoComun_5 = false;
            EC06_L01.EnemigoComun_6 = true; //**
        }

        // Nivel 2

        if (collision.gameObject.name == "EC1_L02")
        {
            EC01_L02.EnemigoComun_1_2 = true; //**
            EC02_L02.EnemigoComun_2_2 = false;
            EC03_L02.EnemigoComun_3_2 = false;
            
        }

        if (collision.gameObject.name == "EC2_L02")
        {
            EC01_L02.EnemigoComun_1_2 = false;
            EC02_L02.EnemigoComun_2_2 = true; //**
            EC03_L02.EnemigoComun_3_2 = true; //**
        }

        if (collision.gameObject.name == "EC3_L02")
        {
            EC01_L02.EnemigoComun_1_2 = false;
            EC02_L02.EnemigoComun_2_2 = true; //**
            EC03_L02.EnemigoComun_3_2 = true; //**
        }
        #endregion

        #region Trigger Enemigos Asesinos

        // Los asesinos disparan cuando el jugador toque su respectivo trigger hijo

        if (collision.gameObject.name == "EA_T1")
        {
            EA_L02_01.EnemigoAsesino_1 = true;     
        }

        if (collision.gameObject.name == "EA_T2")
        {
            EA_L02_01.EnemigoAsesino_1 = false;
            EA_L02_02.EnemigoAsesino_2 = true;
        }

        if (collision.gameObject.name == "EA_T3")
        {
            EA_L02_01.EnemigoAsesino_1 = false;
            EA_L02_03.EnemigoAsesino_3 = true;
        }

        if (collision.gameObject.name == "EA_T4")
        {
            EA_L02_04.EnemigoAsesino_4 = true;
        }

        if (collision.gameObject.name == "EA_T5")
        {
            EA_L02_05.EnemigoAsesino_5 = true;
        }

        if (collision.gameObject.name == "EA_T6")
        {
            EA_L02_06.EnemigoAsesino_6 = true;
        }

        if (collision.gameObject.name == "EA_T7")
        {
            EA_L02_07.EnemigoAsesino_7 = true;
        }

        if (collision.gameObject.name == "EA_T8")
        {
            EA_L02_08.EnemigoAsesino_8 = true;
        }

        if (collision.gameObject.name == "EA_T9")
        {
            EA_L02_09.EnemigoAsesino_9 = true;
        }

        if (collision.gameObject.name == "EA_T10")
        {
            EA_L02_10.EnemigoAsesino_10 = true;
        }

        #endregion

        #region Trigger Tanques

        // Lo mismo pasa con los tanques y sus triggers hijos

        if (collision.gameObject.name == "T01_Trigger01")
        {
            T01_L03.Tanque0102 = true;
            T01_L03.Tanque01 = false;
            T01_L03.Tanque0103 = false;
            T01_L03.Tanque0104 = false;
            T01_L03.Tanque0105 = false;
        }

        if (collision.gameObject.name == "T01_Trigger02")
        {
            T01_L03.Tanque01 = true;
            T01_L03.Tanque0102 = false;
            T01_L03.Tanque0103 = false;
            T01_L03.Tanque0104 = false;
            T01_L03.Tanque0105 = false;
        }

        if (collision.gameObject.name == "T01_Trigger03")
        {
            T01_L03.Tanque01 = false;
            T01_L03.Tanque0102 = false;
            T01_L03.Tanque0103 = true;
            T01_L03.Tanque0104 = false;
            T01_L03.Tanque0105 = false;
        }

        if (collision.gameObject.name == "T01_Trigger04")
        {
            T01_L03.Tanque01 = false;
            T01_L03.Tanque0102 = false;
            T01_L03.Tanque0103 = false;
            T01_L03.Tanque0104 = true;
            T01_L03.Tanque0105 = false;
        }

        if (collision.gameObject.name == "T01_Trigger05")
        {
            T01_L03.Tanque01 = false;
            T01_L03.Tanque0102 = false;
            T01_L03.Tanque0103 = false;
            T01_L03.Tanque0104 = false;
            T01_L03.Tanque0105 = true;
        }

        if (collision.gameObject.name == "T02_Trigger")
        {
            T02_L03.Tanque02 = true;
        }

        if (collision.gameObject.name == "T03_Trigger")
        {
            T03_L03.Tanque03 = true;
            T02_L03.Tanque02 = false;
        }

        if (collision.gameObject.name == "T04_Trigger01")
        {
            T04_L03.Tanque04 = true;
            T04_L03.Tanque0402 = false;
            T04_L03.Tanque0403 = false;
        }

        if (collision.gameObject.name == "T04_Trigger02")
        {
            T04_L03.Tanque04 = false;
            T04_L03.Tanque0402 = true;
            T04_L03.Tanque0403 = false;
        }

        if (collision.gameObject.name == "T04_Trigger03")
        {
            T04_L03.Tanque04 = false;
            T04_L03.Tanque0402 = false;
            T04_L03.Tanque0403 = true;
        }

        #endregion

        #region Daño Enemigo

        // Aqui solucionamos el daño recibido por cada enemigo, ya sea el PLAYER estando cubierto o no

        // Enemigos Comunes

        if (collision.gameObject.tag == "BalaEnemigoComun")
        {
            if (CubriendoseFront == true || CubriendoseFrontFlipX == true)
            {
                Debug.Log("Daño Bloqueado");
            }
            else
            {
                Vida = Vida - 10;
            }
        }
        

        // Enemigos Asesinos

        if (collision.gameObject.tag == "BalaAsesino")
        {
            if (CubriendoseFront == true || CubriendoseFrontFlipX == true)
            {
                Debug.Log("Daño Bloqueado");
            }
            else
            {
                Vida = Vida - 1;
            }
        }
        

        // Tanques

        if (collision.gameObject.tag == "BalaTanque")
        {
            if (CubriendoseFront == true || CubriendoseFrontFlipX == true)
            {
                Vida = Vida - 5;
            }
            else
            {
                Vida = Vida - 15;
            }
        }

        #endregion

        #region Jefe 1

        // Ayudamos al script del Jefe para poder disparar con activar buleanas cuando toquen sus triggers hijos
        // Esto ayuda a alterar la velocidad de disparo y hacer al jefe más competente

        if (collision.gameObject.tag == "OnSite")
        {
            IAJefe1.PlayerOnSiteJefe1 = true;
        }
        if (collision.gameObject.tag == "SitioJefe1")
        {
            IAJefe1.Zona1 = true;
            IAJefe1.Zona2 = false;
            IAJefe1.Zona3 = false;
        }
        if (collision.gameObject.tag == "SitioJefe2")
        {
            IAJefe1.Zona1 = false;
            IAJefe1.Zona2 = true;
            IAJefe1.Zona3 = false;
        }
        if (collision.gameObject.tag == "SitioJefe3")
        {
            IAJefe1.Zona1 = false;
            IAJefe1.Zona2 = false;
            IAJefe1.Zona3 = true;
        }

        #endregion

        #region Acido

        if (collision.gameObject.tag == "Acido")
        {
            RegresoCheckpoint.CaidaAcido = true;
            Vida = Vida - 15;
        }

        #endregion


        if (collision.gameObject.tag == "Final")
        {
            Final = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // En caso de caer en Acido, activamos una buleana en un script que con ayuda de otros dos, la escena respectiva al checkpoint se reinicia

        if (collision.gameObject.tag == "Acido")
        {
            RegresoCheckpoint.CaidaAcido = false;
        }
    }

}
