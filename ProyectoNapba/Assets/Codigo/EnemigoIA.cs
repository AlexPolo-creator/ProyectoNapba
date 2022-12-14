using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemigoIA : MonoBehaviour
{
    public float velocidad = 0.5f;
    public float velocidadInicial = 0.5f;
    public float vidaEnemigo = 100f;
    public float vidaEnemigoInicial = 100f;   
    public int recompensa = 5;
    public int recompensaInicial = 5;

    float rotacionDiff = 90f;
    float velocidadRotacion = 10f;

    public SpriteRenderer sprite;
    public Color congelacionColor;
    public Color inicialColor;
    private Color colorSprite;
    public float velocidadAparicion;

    public int daño = 1;

    public int cargasDruida; //cantidad de veces que ha sido maldecido por algun druida

    //esta variable especifica el lugar donde el enemigo aparece y en consecuencia el camino que debe tomar. Al ser static puede ser modificado desde otro script. Al ser public puede modificarse en el inspector.
    public int puntoSpawn;

    //esta variable de posicion indica el siguiente waypoint al que el enemigo debe ir
    private Transform objetivo;

    //esta variable indica la posicion en el array en la que esta actualmente el objetivo
    private int waypointIndice = 0;

    //esta funcion se ejecuta al iniciar la escena
    private void Start()
    {
        colorSprite = inicialColor;
        colorSprite.a = 0;
        sprite.color = colorSprite;
        FadeIn();
        recompensa = Mathf.RoundToInt(recompensaInicial * SistemaDificultad.recompensaSegunTiempo);
        velocidad = velocidadInicial;
        vidaEnemigo = Mathf.RoundToInt(vidaEnemigoInicial * SistemaDificultad.dificultadEnemigos);
        cargasDruida = 0;

        //asigna un camino al enemigo en funcion de su punto de spawn
        if (puntoSpawn == 1)
        {
            objetivo = Waypoints.puntosRama1[0];
        }
        else if (puntoSpawn == 2)
        {
            objetivo = Waypoints.puntosRama2[0];
        }
        else if (puntoSpawn == 3)
        {
            objetivo = Waypoints.puntosRama3[0];
        }
        else if (puntoSpawn == 4)
        {
            objetivo = Waypoints.puntosRama4[0];
        }
        else if (puntoSpawn == 5)
        {
            objetivo = Waypoints.puntosRama5[0];
        }

        //uso un InvokeRepeating y no Update para no calcular distancias demasidas veces por segundo lo cual puede causar lag.
        InvokeRepeating("eliminarEntidades", 0, 0.2f);

    }

    //esta funcion resta la vida al enemigo correspondiente al daño del ataque recibido extraido del Script de AtaqueIA, de donde se llama a esta funcion.
    public void recibirDano(float cantidad)
    {
        //resta la cantidad equivalente al daño del ataque
        vidaEnemigo -= cantidad;

        //si la vida llega a 0 el enemigo muere
        if (vidaEnemigo <= 0f)
        {
            Muerte();
        }
    }

    //mata al objetivo y otorga una recompensa al jugador
    void Muerte ()
    {
        

        if (Templo.mejoraBotinDivino1)
        {
            Stats.favorDeDioses += Mathf.RoundToInt(recompensa * (1 + (Templo.numBotinDivino1 * 0.05f)));
        }else
        {
            Stats.favorDeDioses += recompensa;
        }

        Destroy(gameObject);
    }

    //elimina los enemigos al llegar al final del recorrido
    void eliminarEntidades()
    {
        //calcula la distancia al punto final para destruirse a si mismo al alcanzarla
        if (Vector3.Distance(transform.position, Waypoints.ultimo.position) <= 0.05f)
        {
            //destruye este objeto
            Destroy(gameObject);

            //resta la vida del jugador en funcion del daño del enemigo
            Stats.vidaJugador -= daño;


            //hago return para asegurarme de que la funcion Destroy() se haya terminado de ejecutar antes de continuar
            return;           
        }
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
        else if (puntoSpawn == 3  && waypointIndice < Waypoints.rama3length)
        {
            objetivo = Waypoints.puntosRama3[waypointIndice];
        }
        else if (puntoSpawn == 4  && waypointIndice < Waypoints.rama4length)
        {
            objetivo = Waypoints.puntosRama4[waypointIndice];
        }
        else if (puntoSpawn == 5  && waypointIndice < Waypoints.rama5length)
        {
            objetivo = Waypoints.puntosRama5[waypointIndice];
        }
    }

    //esta funcion se ejecuta 1 vez por fotograma
    void Update()
    {
        if (colorSprite.a < 1f)
        {
            FadeIn();
        }

        //Esta variable almacena el vector direcci�n del enemigo en funcion de su posici�n y el proximo waypoint
        Vector2 dir = objetivo.position - transform.position;

        //mueve al enemigo hacia el proximo waypoint en funcion de la velocidad y la direcci�n. Al ser .normalized no depende del modulo del vector direccion y al estar multiplicado por Time.deltaTime no depende de los fps del cliente.
        transform.Translate(dir.normalized * velocidad * Time.deltaTime, Space.World);

        Vector3 vectorToTarget = transform.position - objetivo.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotacionDiff;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * velocidadRotacion);

        //ejecuta la funcion sigueinteWaypoint cuando el enemigo llega a un waypoint para cambiar de objetivo al siguiente waypoint
        if (Vector2.Distance(transform.position, objetivo.position) <= 0.05f)
        {
            siguienteWaypoint();
        }

            
    }

    public void Congelar()
    {
        Debug.Log("2");
        if (!waitingForSeconds)
        {
            StartCoroutine(Congelacion());
        }      
    }

    bool waitingForSeconds;
    IEnumerator Congelacion()
    {
        waitingForSeconds = true;
        sprite.color = congelacionColor;
        float velocidadPreCongelacion = velocidad;
        velocidad *= TropaStats.hechiceroRalentizacion; 
        yield return new WaitForSeconds(5);
        sprite.color = Color.white;
        velocidad = velocidadPreCongelacion;
        waitingForSeconds = false;
        Debug.Log("3");
    }

    void FadeIn()
    {        
        colorSprite.a += velocidadAparicion * Time.deltaTime;
        sprite.color = colorSprite;
        
    }

}
