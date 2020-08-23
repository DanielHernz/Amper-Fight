// Desarrollador: Hernández Gutiérrez Daniel
// Estructura de datos
// Profesor; Josue Israel Rivas Diaz

// Script destinado a:Hacer que la camara siga al PLAYER en el nivel 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowLevel1 : MonoBehaviour
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
        transform.position = new Vector3(Mathf.Clamp(target.position.x, 92.7f, 165f), Mathf.Clamp(target.position.y, 0f, 15f), transform.position.z);
    }
}
