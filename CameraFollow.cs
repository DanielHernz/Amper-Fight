// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a:Hacer que la camara siga al PLAYER en el Lobby

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 PuntoInicial;

    // Start is called before the first frame update
    void Start()
    {
        PuntoInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, 32f, 92f), transform.position.y, transform.position.z);
    }
}
