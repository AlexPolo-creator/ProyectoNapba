using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    public GameObject[] enemigos;

    public float spawnSpeedInitial = 1;
    public float spawnRepeat = 3;

    

    void Start()
    {
        InvokeRepeating("spawnEnemigos", spawnSpeedInitial, spawnRepeat);
    }


    void Update()
    {

    }

    public void spawnEnemigos()
    {
        Vector3 spawnPosition1 = new Vector3(0, 0, 0);
        spawnPosition1 = new Vector3(transform.position.x, transform.position.y, 0);
        GameObject enemigo1 = Instantiate(enemigos[0], spawnPosition1, gameObject.transform.rotation);
    }
}
