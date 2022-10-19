using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCiudad : MonoBehaviour
{
    public GameObject minaEdificio;
    public GameObject cultivoEdificio;


    public void AumentarComidaEnMina()
    {
        if (Stats.comidaLibre > 0)
        {
            Stats.comidaEnMina += 1;
        }
        if (Mina.comidaMinaCero)
        {
            Mina.comidaMinaCero = false;
            Mina mina = minaEdificio.GetComponent<Mina>();
            mina.SumarOro();
        }        
    }

    public void DisminuirComidaEnMina()
    {
        if (Stats.comidaEnMina > 0)
        {
            Stats.comidaEnMina -= 1;
        }
        if (Stats.comidaEnMina == 1)
        {
            Mina.comidaMinaCero = true;
        }
        else
        {
            Mina.comidaMinaCero = false;
        }
    }
    public void AumentarComidaEnCultivo()
    {
        if (Stats.comidaLibre > 0)
        {
            Stats.comidaEnCultivo += 1;
        }
        if (Cultivos.comidaCultivoCero)
        {
            Cultivos.comidaCultivoCero = false;
            Cultivos cultivos = cultivoEdificio.GetComponent<Cultivos>();
            cultivos.SumarComida();
        }
    }

    public void DisminuirComidaEnCultivo()
    {
        if (Stats.comidaEnCultivo > 0)
        {
            Stats.comidaEnCultivo -= 1;
        }

        //esto cheackea si la poblacion va a ser 0, y si lo es no dejamos que la coroutina empice ya que al estar dividido por 0 empezar�a una coroutina al infinito
        if (Stats.comidaEnCultivo == 1)
        {
            Cultivos.comidaCultivoCero = true;
        }
        else
        {
            Cultivos.comidaCultivoCero = false;
        }
    }
}
