using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    public int numSpawn;

    public GameObject[] enemigos;

    public float esperaInicialEnemigosTipo1 = 5; //segundos antes de el primer spawn y espera base para el resto de la partida
    public float esperaInicialEnemigosTipo2 = 30;
    
    private float tiempo;
    float esperaEnemigosTipo1; //segundos entre cada spawn
    float esperaEnemigosTipo2;
    float dificultad = 5;


    void Start()
    {

        esperaEnemigosTipo1 = esperaInicialEnemigosTipo1;
        esperaEnemigosTipo2 = esperaInicialEnemigosTipo2;


        StartCoroutine(SpawnEnemigosTipo1());
        StartCoroutine(SpawnEnemigosTipo2());
        
    }
    IEnumerator SpawnEnemigosTipo1()
            {

                yield return new WaitForSeconds(esperaEnemigosTipo1);

                Vector3 spawnPosition1 = new Vector3(0, 0, 0);
                spawnPosition1 = new Vector3(transform.position.x, transform.position.y, 0);
                EnemigoIA spawn = enemigos[0].GetComponent<EnemigoIA>();
                spawn.puntoSpawn = numSpawn;
                GameObject enemigo1 = Instantiate(enemigos[0], spawnPosition1, gameObject.transform.rotation);
                StartCoroutine(SpawnEnemigosTipo1());
                
            }

            IEnumerator SpawnEnemigosTipo2()
            {
                yield return new WaitForSeconds(esperaEnemigosTipo2);
                Vector3 spawnPosition1 = new Vector3(0, 0, 0);
                spawnPosition1 = new Vector3(transform.position.x, transform.position.y, 0);
                EnemigoIA spawn = enemigos[1].GetComponent<EnemigoIA>();
                spawn.puntoSpawn = numSpawn;
                GameObject enemigo2 = Instantiate(enemigos[1], spawnPosition1, gameObject.transform.rotation);
                StartCoroutine(SpawnEnemigosTipo2());
                
            }
    void Update(){
        tiempo += Time.deltaTime;
        if (esperaEnemigosTipo1 >= 0.9 ){
            if (tiempo >= dificultad){
                esperaEnemigosTipo1--;
            }
        }else{
                esperaEnemigosTipo1=1;
            }
        if (esperaEnemigosTipo2 >= 0.9){
            if (tiempo >= dificultad){
                esperaEnemigosTipo2-=5;
                dificultad +=5;
            }
        }else{
                esperaEnemigosTipo2=5;
        }  
    }

    

    
}
