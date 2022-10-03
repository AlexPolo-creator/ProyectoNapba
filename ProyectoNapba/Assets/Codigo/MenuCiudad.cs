using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCiudad : MonoBehaviour
{
    public GameObject minaEdificio;
    public GameObject cultivoEdificio;


    public void AumentarPoblacionEnMina()
    {
        if (Stats.poblacionLibre > 0)
        {
            Stats.poblacionEnMina += 1;
        }
        if (Mina.poblacionMinaCero)
        {
            Mina.poblacionMinaCero = false;
            Mina mina = minaEdificio.GetComponent<Mina>();
            mina.SumarOro();
        }        
    }

    public void DisminuirPoblacionEnMina()
    {
        if (Stats.poblacionEnMina > 0)
        {
            Stats.poblacionEnMina -= 1;
        }
        if (Stats.poblacionEnMina == 1)
        {
            Mina.poblacionMinaCero = true;
        }
        else
        {
            Mina.poblacionMinaCero = false;
        }
    }
    public void AumentarPoblacionEnCultivo()
    {
        if (Stats.poblacionLibre > 0)
        {
            Stats.poblacionEnCultivo += 1;
        }
        if (Cultivos.poblacionCultivoCero)
        {
            Cultivos.poblacionCultivoCero = false;
            Cultivos cultivos = cultivoEdificio.GetComponent<Cultivos>();
            cultivos.SumarPoblacion();
        }
    }

    public void DisminuirPoblacionEnCultivo()
    {
        if (Stats.poblacionEnCultivo > 0)
        {
            Stats.poblacionEnCultivo -= 1;
        }

        //esto cheackea si la poblacion va a ser 0, y si lo es no dejamos que la coroutina empice ya que al estar dividido por 0 empezaría una coroutina al infinito
        if (Stats.poblacionEnCultivo == 1)
        {
            Cultivos.poblacionCultivoCero = true;
        }
        else
        {
            Cultivos.poblacionCultivoCero = false;
        }
    }
}
