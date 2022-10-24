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
    

    public float esperaInicialEnemigosTipo1; //segundos antes de el primer spawn y espera base para el resto de la partida
    public float esperaInicialEnemigosTipo2;
    public float esperaInicialEnemigosTipo3; 
    public float esperaInicialEnemigosTipo4;
   

    float esperaEnemigosTipo1; //segundos entre cada spawn
    float esperaEnemigosTipo2;
    float esperaEnemigosTipo3;
    float esperaEnemigosTipo4;
    


    void Start()
    {

        esperaEnemigosTipo1 = esperaInicialEnemigosTipo1;
        esperaEnemigosTipo2 = esperaInicialEnemigosTipo2;
        esperaEnemigosTipo3 = esperaInicialEnemigosTipo3;
        esperaEnemigosTipo4 = esperaInicialEnemigosTipo4;
        

        cantidadEnemigos1 = 1;
        cantidadEnemigos2 = 1;
        cantidadEnemigos3 = 1;
        cantidadEnemigos4 = 1;
        

        StartCoroutine(SpawnEnemigosTipo1());
        StartCoroutine(SpawnEnemigosTipo2()); 
        StartCoroutine(SpawnEnemigosTipo3()); 
        StartCoroutine(SpawnEnemigosTipo4()); 
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
            EnemigoIA spawn = enemigos[1].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[1], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[1], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo3 = Instantiate(enemigos[1], spawnPosition1 + new Vector3(-0.3f, -0.3f, 0), gameObject.transform.rotation);
        }
        else if (cantidadEnemigos2 == 4)
        {
            EnemigoIA spawn = enemigos[1].GetComponent<EnemigoIA>();
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

        if (esperaEnemigosTipo2 > 10)
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

    IEnumerator SpawnEnemigosTipo3()
    {
        yield return new WaitForSeconds(esperaEnemigosTipo3);
        Vector3 spawnPosition1 = new Vector3(0, 0, 0);
        spawnPosition1 = new Vector3(transform.position.x, transform.position.y, 0);

        if (cantidadEnemigos3 == 1)
        {
            EnemigoIA spawn = enemigos[2].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[2], spawnPosition1, gameObject.transform.rotation);
        }
        else if (cantidadEnemigos3 == 2)
        {
            EnemigoIA spawn = enemigos[2].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[2], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[2], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
        }
        else if (cantidadEnemigos3 == 3)
        {
            EnemigoIA spawn = enemigos[2].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[2], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[2], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo3 = Instantiate(enemigos[2], spawnPosition1 + new Vector3(-0.3f, -0.3f, 0), gameObject.transform.rotation);
        }
        else if (cantidadEnemigos3 == 4)
        {
            EnemigoIA spawn = enemigos[2].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[2], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[2], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo3 = Instantiate(enemigos[2], spawnPosition1 + new Vector3(-0.3f, -0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo4 = Instantiate(enemigos[2], spawnPosition1 + new Vector3(-0.5f, 0.5f, 0), gameObject.transform.rotation);
        }
        else if (cantidadEnemigos3 == 5)
        {
            EnemigoIA spawn = enemigos[2].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[2], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[2], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo3 = Instantiate(enemigos[2], spawnPosition1 + new Vector3(-0.3f, -0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo4 = Instantiate(enemigos[2], spawnPosition1 + new Vector3(-0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo5 = Instantiate(enemigos[2], spawnPosition1 + new Vector3(0.5f, -0.5f, 0), gameObject.transform.rotation);
        }

        if (esperaEnemigosTipo3 > 20)
        {
            esperaEnemigosTipo3 -= esperaInicialEnemigosTipo3 * reduccionTiempo;

        }
        else
        {
            esperaEnemigosTipo3 = esperaInicialEnemigosTipo3;

            if (cantidadEnemigos3 <= 5)
            {
                cantidadEnemigos3++;
            }
            else
            {
                cantidadEnemigos3 = 5;
            }
        }

        StartCoroutine(SpawnEnemigosTipo3());
    }

    IEnumerator SpawnEnemigosTipo4()
    {
        yield return new WaitForSeconds(esperaEnemigosTipo4);
        Vector3 spawnPosition1 = new Vector3(0, 0, 0);
        spawnPosition1 = new Vector3(transform.position.x, transform.position.y, 0);

        if (cantidadEnemigos4 == 1)
        {
            EnemigoIA spawn = enemigos[3].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[3], spawnPosition1, gameObject.transform.rotation);
        }
        else if (cantidadEnemigos4 == 2)
        {
            EnemigoIA spawn = enemigos[3].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[3], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[3], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
        }
        else if (cantidadEnemigos4 == 3)
        {
            EnemigoIA spawn = enemigos[3].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[3], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[3], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo3 = Instantiate(enemigos[3], spawnPosition1 + new Vector3(-0.3f, -0.3f, 0), gameObject.transform.rotation);
        }
        else if (cantidadEnemigos4 == 4)
        {
            EnemigoIA spawn = enemigos[3].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[3], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[3], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo3 = Instantiate(enemigos[3], spawnPosition1 + new Vector3(-0.3f, -0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo4 = Instantiate(enemigos[3], spawnPosition1 + new Vector3(-0.5f, 0.5f, 0), gameObject.transform.rotation);
        }
        else if (cantidadEnemigos4 == 5)
        {
            EnemigoIA spawn = enemigos[3].GetComponent<EnemigoIA>();
            spawn.puntoSpawn = numSpawn;
            GameObject enemigo1 = Instantiate(enemigos[3], spawnPosition1, gameObject.transform.rotation);
            GameObject enemigo2 = Instantiate(enemigos[3], spawnPosition1 + new Vector3(0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo3 = Instantiate(enemigos[3], spawnPosition1 + new Vector3(-0.3f, -0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo4 = Instantiate(enemigos[3], spawnPosition1 + new Vector3(-0.3f, 0.3f, 0), gameObject.transform.rotation);
            GameObject enemigo5 = Instantiate(enemigos[3], spawnPosition1 + new Vector3(0.5f, -0.5f, 0), gameObject.transform.rotation);
        }

        if (esperaEnemigosTipo4 > 30)
        {
            esperaEnemigosTipo4 -= esperaInicialEnemigosTipo4 * reduccionTiempo;

        }
        else
        {
            esperaEnemigosTipo4 = esperaInicialEnemigosTipo4;

            if (cantidadEnemigos4 <= 5)
            {
                cantidadEnemigos4++;
            }
            else
            {
                cantidadEnemigos4 = 5;
            }
        }

        StartCoroutine(SpawnEnemigosTipo4());
    }
    
}