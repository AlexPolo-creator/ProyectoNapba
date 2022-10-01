using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoIA : MonoBehaviour
{
    public float velocidad = 0.5f;
    public float vidaEnemigo = 100f;
    public int recompensa = 5;

    public int daño = 1;

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
            objetivo = Waypoints.puntosRama1[0];
        }
        else if (puntoSpawn == 2)
        {
            objetivo = Waypoints.puntosRama2[0];
        }

        InvokeRepeating("eliminarEntidades", 0, 0.1f);

    }

    public void recibirDaño(float cantidad)
    {
        vidaEnemigo -= cantidad;

        if (vidaEnemigo <= 0f)
        {
            Muerte();
        }

    }

    void Muerte ()
    {
        Stats.favorDeDioses += recompensa;
        Destroy(gameObject);
    }

    //elimina los enemigos al llegar al final del recorrido
    void eliminarEntidades()
    {
        if (Vector3.Distance(transform.position, Waypoints.ultimo.position) <= 0.05f)
        {
            Destroy(gameObject);
            Stats.vidaJugador -= daño;
            if(Stats.vidaJugador <= 0)
            {
                Debug.Log("moriste");
                Stats.Derrota();
            }
        }
        return;
    }

    //esta funcion aumenta en 1 la posicion en el array para coger la posicion del siguiente waypoint y lo establece como objetivo (en funcion del punto de spwan cogera el array de la rama correspondiente).
    void siguienteWaypoint()
    {
        waypointIndice++;

        if (puntoSpawn == 1 && waypointIndice < Waypoints.rama1length)
        {
            objetivo = Waypoints.puntosRama1[waypointIndice];
        }
        else if (puntoSpawn == 2  && waypointIndice < Waypoints.rama2length)
        {
            objetivo = Waypoints.puntosRama2[waypointIndice];
        }

    }

    //esta funcion se ejecuta 1 vez por fotograma
    void Update()
    {
        //Esta variable almacena el vector direcci�n del enemigo en funcion de su posici�n y el proximo waypoint
        Vector2 dir = objetivo.position - transform.position;

        //mueve al enemigo hacia el proximo waypoint en funcion de la velocidad y la direcci�n. Al ser .normalized no depende del modulo del vector direccion y al estar multiplicado por Time.deltaTime no depende de los fps del cliente.
        transform.Translate(dir.normalized * velocidad * Time.deltaTime, Space.World);

        //ejecuta la funcion sigueinteWaypoint cuando el enemigo llega a un waypoint para cambiar de objetivo al siguiente waypoint
        if (Vector2.Distance(transform.position, objetivo.position) <= 0.05f)
        {
            siguienteWaypoint();
        }


       
    }
}
