using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropaIA : MonoBehaviour
{
    [Header("Que tropa es?:")]
    public string tipoTropa;
    public string queTropa;

    Transform objetivo;

    [Header("Atributos:")]

    //TODO: Pasar todos los atributos al GameMaster y hacerlos static. HECHO: ahora estos atributos no hay que modificarlos, para editar una tropa id al gamemaster

    float rango = 1.5f;
    float velocidadDisparo = 1f;
    public float velocidadRotacion = 1f;

    [Header("Unity Set up:")]

    public float rotacionDiff = 90;
    public Transform puntoDeDisparo;
    float siguienteDisparo = 0f;
    public string enemigoTag = "Enemigo";
    public GameObject ataque;


    void Start()
    {
        InvokeRepeating("BuscarObjetivo", 0f, 0.25f);
    }

    void BuscarObjetivo()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag(enemigoTag);
        float minimaDistancia = Mathf.Infinity;
        GameObject enemigoMasCercano = null;

        foreach (GameObject enemigo in enemigos)
        {
            float distanciaEnemigo = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distanciaEnemigo < minimaDistancia)
            {
                minimaDistancia = distanciaEnemigo;
                enemigoMasCercano = enemigo;
            }
        }
        if (enemigoMasCercano != null && minimaDistancia <= rango)
        {
            objetivo = enemigoMasCercano.transform;
        }
        else
        {
            objetivo = null;
        }
        //esto no es parte de buscar objetivo pero aprovecha en invoke:
        if (queTropa == "hechicero")
        {
            rango = TropaStats.hechiceroRango;
            velocidadDisparo = TropaStats.hechiceroVelocidadDeDisparo;
        }else if (queTropa == "verdugo")
        {
            rango = TropaStats.verdugoRango;
            velocidadDisparo = TropaStats.verdugoVelocidadDeDisparo;
        }else if (queTropa == "druida")
        {
            rango = TropaStats.druidaRango;
            velocidadDisparo = TropaStats.druidaVelocidadDeDisparo;
        }
        else if (queTropa == "inquisidor")
        {
            rango = TropaStats.inquisidorRango;
            velocidadDisparo = TropaStats.inquisidorVelocidadDeDisparo;
        }
        else if (queTropa == "arquero")
        {
            rango = TropaStats.arqueroRango;
            velocidadDisparo = TropaStats.arqueroVelocidadDeDisparo;
        }
        else if (queTropa == "lanzadorHachas")
        {
            rango = TropaStats.lanzadorHachasRango;
            velocidadDisparo = TropaStats.lanzadorHachasVelocidadDeDisparo;
        }
        else if (queTropa == "lancero")
        {
            rango = TropaStats.lanceroRango;
            velocidadDisparo = TropaStats.lanceroVelocidadDeDisparo;
        }
    }


    void Update()
    {
        siguienteDisparo -= Time.deltaTime;

        if (objetivo == null) return;

        Vector3 vectorToTarget = transform.position - objetivo.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotacionDiff;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * velocidadRotacion);

        if (siguienteDisparo <= 0f)
        {
            Disparar();
            siguienteDisparo = 1f / velocidadDisparo;

        }



    }

    
    void Disparar()
    {
        Instantiate(ataque, puntoDeDisparo.position, puntoDeDisparo.rotation);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rango);
    }


}
