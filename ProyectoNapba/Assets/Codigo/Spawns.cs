using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    public GameObject[] enemigos;

    public float esperaInicialEnemigosTipo1 = 5; //segundos antes de el primer spawn
    public float esperaInicialEnemigosTipo2 = 30;
    

    public float esperaEnemigosTipo1 = 5; //segundos entre cada spawn
    public float esperaEnemigosTipo2 = 10;


    void Start()
    {
        InvokeRepeating("spawnEnemigosTipo1", esperaInicialEnemigosTipo1, esperaEnemigosTipo1);
        InvokeRepeating("spawnEnemigosTipo2", esperaInicialEnemigosTipo2, esperaEnemigosTipo2);
    }


    void Update()
    {

    }

    public void spawnEnemigosTipo1()
    {
        Vector3 spawnPosition1 = new Vector3(0, 0, 0);
        spawnPosition1 = new Vector3(transform.position.x, transform.position.y, 0);
        GameObject enemigo1 = Instantiate(enemigos[0], spawnPosition1, gameObject.transform.rotation);
    }

    public void spawnEnemigosTipo2()
    {
        Vector3 spawnPosition1 = new Vector3(0, 0, 0);
        spawnPosition1 = new Vector3(transform.position.x, transform.position.y, 0);
        GameObject enemigo2 = Instantiate(enemigos[1], spawnPosition1, gameObject.transform.rotation);
    }
}
