using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    public float reduccionTiempo;

    public int numSpawn;

    public GameObject[] enemigos;
    /*
    public GameObject[] enemigosDobles;
    public GameObject[] enemigosTriples;
    public GameObject[] enemigosCuadruples;
    */

    int cantidadEnemigos1;
    int cantidadEnemigos2;
    int cantidadEnemigos3;
    int cantidadEnemigos4;
    int cantidadEnemigos5;

    public float esperaInicialEnemigosTipo1; //segundos antes de el primer spawn y espera base para el resto de la partida
    public float esperaInicialEnemigosTipo2;
    public float esperaInicialEnemigosTipo3; 
    public float esperaInicialEnemigosTipo4;
    public float esperaInicialEnemigosTipo5; 

    float esperaEnemigosTipo1; //segundos entre cada spawn
    float esperaEnemigosTipo2;
    float esperaEnemigosTipo3;
    float esperaEnemigosTipo4;
    float esperaEnemigosTipo5;


    void Start()
    {

        esperaEnemigosTipo1 = esperaInicialEnemigosTipo1;
        esperaEnemigosTipo2 = esperaInicialEnemigosTipo2;
        esperaEnemigosTipo3 = esperaInicialEnemigosTipo3;
        esperaEnemigosTipo4 = esperaInicialEnemigosTipo4;
        esperaEnemigosTipo5 = esperaInicialEnemigosTipo5;

        cantidadEnemigos1 = 1;
        cantidadEnemigos2 = 1;
        cantidadEnemigos3 = 1;
        cantidadEnemigos4 = 1;
        cantidadEnemigos5 = 1;

        StartCoroutine(SpawnEnemigosTipo1());
        StartCoroutine(SpawnEnemigosTipo2());      
    }
    IEnumerator SpawnEnemigosTipo1()
    {
        yield return new WaitForSeconds(esperaEnemigosTipo1);
        Vector3 spawnPosition1 = new Vector3(0, 0, 0);
        spawnPosition1 = new Vector3(transform.position.x, transform.position.y, 0);

        if (cantidadEnemigos1 == 1)
        {
            EnemigoIA spawn = enemigos[0].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[0], spawnPosition1, gameObject.transform.rotation);
        }
        else if (cantidadEnemigos1 == 2)
        {
            EnemigoIA spawn = enemigos[0].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[0], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[0], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
        }
        else if (cantidadEnemigos1 == 3)
        {
            EnemigoIA spawn = enemigos[0].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[0], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[0], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo3 = Instantiate(enemigos[0], spawnPosition1 + new Vector3(-0.3f, -0.3f, 0), gameObject.transform.rotation);
        }
        else if (cantidadEnemigos1 == 4)
        {
            EnemigoIA spawn = enemigos[0].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[0], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[0], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo3 = Instantiate(enemigos[0], spawnPosition1 + new Vector3(-0.3f, -0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo4 = Instantiate(enemigos[0], spawnPosition1 + new Vector3(-0.5f, 0.5f, 0), gameObject.transform.rotation);
        }
        else if (cantidadEnemigos1 == 5)
        {
            EnemigoIA spawn = enemigos[0].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[0], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[0], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo3 = Instantiate(enemigos[0], spawnPosition1 + new Vector3(-0.3f, -0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo4 = Instantiate(enemigos[0], spawnPosition1 + new Vector3(-0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo5 = Instantiate(enemigos[0], spawnPosition1 + new Vector3(0.5f, -0.5f, 0), gameObject.transform.rotation);
        }

        if (esperaEnemigosTipo1 > 5)
        {
            esperaEnemigosTipo1 -= esperaInicialEnemigosTipo1 * reduccionTiempo;
            
        }
        else
        {
            esperaEnemigosTipo1 = esperaInicialEnemigosTipo1;

            if (cantidadEnemigos1 <= 5)
            {
                cantidadEnemigos1++;
            }
            else
            {
                cantidadEnemigos1 = 5;
            }            
        }

        StartCoroutine(SpawnEnemigosTipo1());
    }

    IEnumerator SpawnEnemigosTipo2()
    {
        yield return new WaitForSeconds(esperaEnemigosTipo2);

        Vector3 spawnPosition1 = new Vector3(0, 0, 0);
        spawnPosition1 = new Vector3(transform.position.x, transform.position.y, 0);

        if (cantidadEnemigos2 == 1)
        {
            EnemigoIA spawn = enemigos[1].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[1], spawnPosition1, gameObject.transform.rotation);
        }
        else if (cantidadEnemigos2 == 2)
        {
            EnemigoIA spawn = enemigos[1].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[1], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[1], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
        }
        else if (cantidadEnemigos2 == 3)
        {
            EnemigoIA spawn = enemigos[0].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[1], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[1], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo3 = Instantiate(enemigos[1], spawnPosition1 + new Vector3(-0.3f, -0.3f, 0), gameObject.transform.rotation);
        }
        else if (cantidadEnemigos2 == 4)
        {
            EnemigoIA spawn = enemigos[0].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[1], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[1], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo3 = Instantiate(enemigos[1], spawnPosition1 + new Vector3(-0.3f, -0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo4 = Instantiate(enemigos[1], spawnPosition1 + new Vector3(-0.5f, 0.5f, 0), gameObject.transform.rotation);
        }
        else if (cantidadEnemigos2 == 5)
        {
            EnemigoIA spawn = enemigos[1].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[1], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[1], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo3 = Instantiate(enemigos[1], spawnPosition1 + new Vector3(-0.3f, -0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo4 = Instantiate(enemigos[1], spawnPosition1 + new Vector3(-0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo5 = Instantiate(enemigos[1], spawnPosition1 + new Vector3(0.5f, -0.5f, 0), gameObject.transform.rotation);
        }

        if (esperaEnemigosTipo2 > 5)
        {
            esperaEnemigosTipo2 -= esperaInicialEnemigosTipo2 * reduccionTiempo;
        }
        else
        {
            esperaEnemigosTipo2 = esperaInicialEnemigosTipo2;
            if (cantidadEnemigos2 <= 5)
            {
                cantidadEnemigos2++;
            }
            else
            {
                cantidadEnemigos2 = 5;
            }
        }

        StartCoroutine(SpawnEnemigosTipo2());
    }                    
}
