using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropaIA : MonoBehaviour
{

    Transform objetivo;

    [Header("Atributos:")]

    //TODO: Pasar todos los atributos al GameMaster y hacerlos static.

    public float rango = 1.5f;
    public float velocidadDisparo = 1f;
    public float velocidadRotacion = 1f;

    [Header("Unity Set up:")]

    public float rotacionDiff = 90;
    public Transform puntoDeDisparo;
    float siguienteDisparo = 0f;
    public string enemigoTag = "Enemigo";
    public GameObject ataque;


    void Start()
    {
        InvokeRepeating("BuscarObjetivo", 0f, 0.5f);
    }

    void Update()
    {
        siguienteDisparo -= Time.deltaTime;

        if (objetivo == null) return;

        Vector3 vectorToTarget = objetivo.position - puntoDeDisparo.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotacionDiff;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        puntoDeDisparo.rotation = Quaternion.Slerp(puntoDeDisparo.rotation, q, Time.deltaTime * velocidadRotacion);

        /*
        Vector2 dir = objetivo.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector2 rotacion = lookRotation.eulerAngles;
        puntoDeDisparo.rotation = Quaternion.Euler(0f, 0f, rotacion.y);
        */

        if (siguienteDisparo <= 0f)
        {
            Disparar();
            siguienteDisparo = 1f / velocidadDisparo;

        }



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
