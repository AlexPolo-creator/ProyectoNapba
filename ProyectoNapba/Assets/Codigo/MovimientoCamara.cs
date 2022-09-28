using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{

    //variables especificadas en el inspector con las coordenadas de la pos de la camara para la ciudad y el campo de batalla
    public Transform ciudad;
    public Transform batalla;

    //variable especificadas en el inspector con la desviación en la z necesaria para que la camara funcione
    public Vector3 desviacionCamara;


    //tpea la camara a la posicion de la ciudad
    public void irCiudad() 
    {
        transform.position = ciudad.position + desviacionCamara;
    }

    //tpea la camara a la posicion de la batalla
    public void irBatlla()
    {
        transform.position = batalla.position + desviacionCamara;
    }

   

}
