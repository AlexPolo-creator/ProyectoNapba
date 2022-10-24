using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDificultad : MonoBehaviour
{
    [Header("Ajustar en funcion del playtesting:")]
    //variables internas de desarrollo:
    public float multiplicadorDificultadEnemigos = 1f;
    public float multiplicadorRecompensa = 0.5f; //cuanto aumentan las recompensas que gana el jugador por matar enemigos (se podria usar para otras cosas)

    //variable que no se utiliza en este script pero si en otros de forma static
    public static float aumentoPrecioTropas = 1.25f;

    //variable por si en el futuro queremos que el jugador pueda cambiar la dificultad:
    public static int nivelDificultad = 1;

    //variables internas calculadas con la funcion para modificar los stats, precios, spawn, etc:
    public static float dificultadEnemigos;
    public static float recompensaSegunTiempo;

    public float dificultadEnemigosShow;
    public float segundosTranscurridos;

    private void Update()
    {
        segundosTranscurridos += Time.deltaTime * CicloDiaNoche.tick;
        dificultadEnemigos = 1 + (nivelDificultad * multiplicadorDificultadEnemigos * segundosTranscurridos * CicloDiaNoche.dias * 0.00001f);
        recompensaSegunTiempo = 1 + (multiplicadorRecompensa * segundosTranscurridos * CicloDiaNoche.dias * 0.00001f);

        dificultadEnemigosShow = dificultadEnemigos;
    }

    
}
