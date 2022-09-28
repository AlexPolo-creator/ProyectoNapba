using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoIA : MonoBehaviour
{
    public float velocidad = 0.5f;

    //esta variable especifica el lugar donde el enemigo aparece y en consecuencia el camino que debe tomar. Al ser static puede ser modificado desde otro script. Al ser public puede modificarse en el inspector.
    public int puntoSpawn;

    //esta variable de posicion indica el siguiente waypoint al que el enemigo debe ir
    private Transform objetivo;

    //esta variable indica la posicion en el array en la que esta actualmente el objetivo
    private int waypointIndice = 0;

    //esta funcion se ejecuta al iniciar la escena
    private void Start()
    {

        //asigna un camino al enemigo en funcion de su punto de spawn
        if (puntoSpawn == 1)
        {
            objetivo = WaypointsRama1.puntosRama1[0];
        }
        else if (puntoSpawn == 2)
        {
            objetivo = WaypointsRama2.puntosRama2[0];
        }
    }


   //esta funcion se ejecuta 1 vez por fotograma
    void Update()
    {
        //Esta variable almacena el vector dirección del enemigo en funcion de su posición y el proximo waypoint
        Vector2 dir = objetivo.position - transform.position;

        //mueve al enemigo hacia el proximo waypoint en funcion de la velocidad y la dirección. Al ser .normalized no depende del modulo del vector direccion y al estar multiplicado por Time.deltaTime no depende de los fps del cliente.
        transform.Translate(dir.normalized * velocidad * Time.deltaTime, Space.World);

        //ejecuta la funcion sigueinteWaypoint cuando el enemigo llega a un waypoint para cambiar de objetivo al siguiente waypoint
        if (Vector2.Distance(transform.position, objetivo.position) <= 0.05f)
        {
            siguienteWaypoint();
        }

        //esta funcion aumenta en 1 la posicion en el array para coger la posicion del siguiente waypoint y lo establece como objetivo (en funcion del punto de spwan cogera el array de la rama correspondiente).
        void siguienteWaypoint()
        {
            waypointIndice++;

            if (puntoSpawn == 1)
            {
                objetivo = WaypointsRama1.puntosRama1[waypointIndice];
            }
            else if (puntoSpawn == 2)
            {
                objetivo = WaypointsRama2.puntosRama2[waypointIndice];
            }
            
        }

    }
}
