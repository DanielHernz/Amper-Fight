// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a: Hacer que la camara siga al PLAYER en el nivel 3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowLevel3 : MonoBehaviour
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
        transform.position = new Vector3(Mathf.Clamp(target.position.x, 202f, 268.5f), Mathf.Clamp(target.position.y, 6.5f, 39f), transform.position.z);
    }
}
