// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer invocar a asesinos en el recinto del jefe
// Con cada 3 asesinos invocados en spawns aleatorios, existe un tiempo de descanso para que el jugador pueda matar a los ya invocados

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvocarEnemigosAsesinos : MonoBehaviour
{
    [SerializeField] GameObject Asesinos;
    [SerializeField] Transform[] SpawnEnemigos;

    public static bool AllowSpawn;

    int randomSpawn;

    public int Contador = 0;
    public float Timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        AllowSpawn = true;
        InvokeRepeating("Aparición", 1f, 2f);
    }

    void Aparición()
    {
        if (AllowSpawn == true)
        {
            if (IAJefe1.PlayerOnSiteJefe1 == true)
            {
                randomSpawn = Random.Range(0, 2);
                Instantiate(Asesinos, SpawnEnemigos[randomSpawn].position, Quaternion.identity);

            }
        }
    }

    private void Update()
    {
        if (Contador == 3)
        {
            AllowSpawn = false;
        }
        if (AllowSpawn == false)
        {
            Timer += Time.deltaTime;
        }
        if (Timer >= 6)
        {
            AllowSpawn = true;
        }
    }
}
