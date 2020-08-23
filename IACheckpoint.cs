// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Junto a otros dos scripts, hacer que cuando se reinicie una escena por haber caido en acido o tener la vida en cero, reaparecer en el checkPoint respectivo a la escena

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACheckpoint : MonoBehaviour
{
    private static IACheckpoint instance;
    public Vector2 UltimoCheckpoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
