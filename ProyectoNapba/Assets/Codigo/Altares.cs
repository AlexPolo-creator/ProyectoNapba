using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altares : MonoBehaviour
{

    // ALTAR A X:
    public GameObject botonX11;
    public GameObject botonX12;
    public GameObject botonX13;
    public GameObject botonX14;
    public GameObject botonX21;
    public GameObject botonX22;
    public GameObject botonX23;
    public GameObject botonX24;

    public int precioX11;
    public int precioX12;
    public int precioX13;
    public int precioX14;
    public int precioX21;
    public int precioX22;
    public int precioX23;
    public int precioX24;

    public void MejoraX11()
    {
        if (Stats.favorDeDioses >= precioX11)
        {
            TropaStats.hechiceroAtaque *= 1.5f;
            TropaStats.hechiceroVelocidadDeDisparo *= 1.5f;
            botonX12.SetActive(true);
            Stats.favorDeDioses -= precioX11;
        }
    }
    public void MejoraX12()
    {
        if (Stats.favorDeDioses >= precioX12)
        {
            TropaStats.hechiceroAtaque *= 2f;
            botonX13.SetActive(true);
            Stats.favorDeDioses -= precioX12;
        }
    }
    public void MejoraX13()
    {
        if (Stats.favorDeDioses >= precioX13)
        {
            TropaStats.hechiceroAtaque *= 2f;
            TropaStats.hechiceroVelocidadDeDisparo *= 2f;
            botonX14.SetActive(true);
            Stats.favorDeDioses -= precioX13;
        }
    }
    public void MejoraX14()
    {
        if (Stats.favorDeDioses >= precioX14)
        {
            TropaStats.hechiceroAtaque *= 3.5f;
            Stats.favorDeDioses -= precioX14;
        }
    }
    public void MejoraX21()
    {
        if (Stats.favorDeDioses >= precioX21)
        {
            Stats.puedeLanzarHielo = true;
            botonX22.SetActive(true);
            Stats.favorDeDioses -= precioX21;
        }
    }
    public void MejoraX22()
    {
        if (Stats.favorDeDioses >= precioX22)
        {
            Stats.cadaCuantosAtaquesLanzarHielo = 2;        
            botonX23.SetActive(true);
            Stats.favorDeDioses -= precioX22;
        }
    }
    public void MejoraX23()
    {
        if (Stats.favorDeDioses >= precioX23)
        {
            TropaStats.hechiceroRalentizacion -= 0.25f;
            botonX24.SetActive(true);
            Stats.favorDeDioses -= precioX23;
        }
    }
    public void MejoraX24()
    {
        if (Stats.favorDeDioses >= precioX24)
        {
            Stats.puedeLanzarHielo2 = true;
            Stats.favorDeDioses -= precioX24;
        }
    }

    // ALTAR A X:
}
