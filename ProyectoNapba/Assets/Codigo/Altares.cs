using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Altares : MonoBehaviour
{

    // ALTAR A X:
    public GameObject[] botonX;

    public GameObject[] bloqueadoX;

    public TextMeshProUGUI[] precioTexto;

    public int[] precioX;

    private void Start()
    {
        int i = 0;
        foreach (int item in precioX)
        {
            precioTexto[i].text = precioX[i].ToString();
            i++;
        }
        int iY = 0;
        foreach (int item in precioY)
        {
            precioYTexto[iY].text = precioY[iY].ToString();
            iY++;
        }
        int iZ = 0;
        foreach (int item in precioZ)
        {
            precioZTexto[iZ].text = precioZ[iZ].ToString();
            iZ++;
        }
        int iA = 0;
        foreach (int item in precioA)
        {
            precioATexto[iA].text = precioA[iA].ToString();
            iA++;
        }
    }

    public void MejoraX11()
    {
        if (Stats.favorDeDioses >= precioX[0])
        {
            TropaStats.hechiceroAtaque *= 1.5f;
            TropaStats.hechiceroVelocidadDeDisparo *= 1.5f;
            Stats.favorDeDioses -= precioX[0];
            Debug.Log("X11");
        }
        else
        {
            StartCoroutine(EsperarX(0));
            

        }
    }
    public void MejoraX12()
    {
        if (Stats.favorDeDioses >= precioX[1])
        {
            TropaStats.hechiceroAtaque *= 2f;
            Stats.favorDeDioses -= precioX[1];
            Debug.Log("X12");
        }
        else
        {
            StartCoroutine(EsperarX(1));
        }
    }
    public void MejoraX13()
    {
        if (Stats.favorDeDioses >= precioX[2])
        {
            TropaStats.hechiceroAtaque *= 1.5f;
            TropaStats.hechiceroVelocidadDeDisparo *= 1.5f;
            Stats.favorDeDioses -= precioX[2];
            Debug.Log("X13");
        }
        else
        {
            StartCoroutine(EsperarX(2));
        }
    }
    public void MejoraX14()
    {
        if (Stats.favorDeDioses >= precioX[3])
        {
            TropaStats.hechiceroAtaque *= 2f;
            Stats.favorDeDioses -= precioX[3];
            Debug.Log("X14");
        }
        else
        {
            StartCoroutine(EsperarX(3));
        }
    }
    public void MejoraX21()
    {
        if (Stats.favorDeDioses >= precioX[4])
        {
            Stats.puedeLanzarHielo = true;
            Stats.favorDeDioses -= precioX[4];
            Debug.Log("X21");
        }
        else
        {
            StartCoroutine(EsperarX(4));
        }
    }
    public void MejoraX22()
    {
        if (Stats.favorDeDioses >= precioX[5])
        {
            Stats.cadaCuantosAtaquesLanzarHielo = 2;        
            Stats.favorDeDioses -= precioX[5];
            Debug.Log("X22");
        }
        else
        {
            StartCoroutine(EsperarX(5));
        }
    }
    public void MejoraX23()
    {
        if (Stats.favorDeDioses >= precioX[6])
        {
            TropaStats.hechiceroRalentizacion -= 0.25f;
            Stats.favorDeDioses -= precioX[6];
            Debug.Log("X23");
        }
        else
        {
            StartCoroutine(EsperarX(6));
        }
    }
    public void MejoraX24()
    {
        if (Stats.favorDeDioses >= precioX[7])
        {
            Stats.puedeLanzarHielo2 = true;
            Stats.favorDeDioses -= precioX[7];
            Debug.Log("X24");
        }
        else
        {
            StartCoroutine(EsperarX(7));
        }
    }



    IEnumerator EsperarX(int arrayPos)
    {
        yield return new WaitForSeconds(0.01f);
        botonX[arrayPos].SetActive(true);
        bloqueadoX[arrayPos].SetActive(false);
        if (arrayPos + 1 != 4 && arrayPos + 1 != 8)
        {
            botonX[arrayPos + 1].SetActive(false);
            bloqueadoX[arrayPos + 1].SetActive(true);
        }
        

    }


    
    // ALTAR A Y:
    public GameObject[] botonY;

    public GameObject[] bloqueadoY;

    public TextMeshProUGUI[] precioYTexto;

    public int[] precioY;


    public void MejoraY11()
    {
        if (Stats.favorDeDioses >= precioY[0])
        {
            TropaStats.verdugoAtaque *= 1.5f;
            TropaStats.verdugoVelocidadDeDisparo *= 1.5f;
            Stats.favorDeDioses -= precioY[0];
            Debug.Log("Y11");
        }
        else
        {
            StartCoroutine(EsperarY(0));


        }
    }
    public void MejoraY12()
    {
        if (Stats.favorDeDioses >= precioY[1])
        {
            TropaStats.verdugoAtaque *= 2f;
            Stats.favorDeDioses -= precioY[1];
            Debug.Log("Y12");
        }
        else
        {
            StartCoroutine(EsperarY(1));
        }
    }
    public void MejoraY13()
    {
        if (Stats.favorDeDioses >= precioY[2])
        {
            TropaStats.verdugoAtaque *= 1.5f;
            TropaStats.verdugoVelocidadDeDisparo *= 1.5f;
            Stats.favorDeDioses -= precioY[2];
            Debug.Log("Y13");
        }
        else
        {
            StartCoroutine(EsperarY(2));
        }
    }
    public void MejoraY14()
    {
        if (Stats.favorDeDioses >= precioY[3])
        {
            TropaStats.verdugoAtaque *= 2f;
            Stats.favorDeDioses -= precioY[3];
            Debug.Log("Y14");
        }
        else
        {
            StartCoroutine(EsperarY(3));
        }
    }
    public void MejoraY21()
    {
        if (Stats.favorDeDioses >= precioY[4])
        {
            Stats.puedeEjecutar = true;
            Stats.favorDeDioses -= precioY[4];
            Debug.Log("Y21");
        }
        else
        {
            StartCoroutine(EsperarY(4));
        }
    }
    public void MejorarY22()
    {
        if (Stats.favorDeDioses >= precioY[5])
        {
            TropaStats.verdugoPuntoEjecucion += 0.05f;
            Stats.favorDeDioses -= precioY[5];
            Debug.Log("Y22");
        }
        else
        {
            StartCoroutine(EsperarY(5));
        }
    }
    public void MejoraY23()
    {
        if (Stats.favorDeDioses >= precioY[6])
        {
            TropaStats.verdugoPuntoEjecucion += 0.05f;
            Stats.favorDeDioses -= precioY[6];
            Debug.Log("Y23");
        }
        else
        {
            StartCoroutine(EsperarY(6));
        }
    }
    public void MejoraY24()
    {
        if (Stats.favorDeDioses >= precioY[7])
        {
            TropaStats.verdugoPuntoEjecucion += 0.10f;
            Stats.favorDeDioses -= precioY[7];
            Debug.Log("Y24");
        }
        else
        {
            StartCoroutine(EsperarY(7));
        }
    }



    IEnumerator EsperarY(int arrayPos)
    {
        yield return new WaitForSeconds(0.01f);
        botonY[arrayPos].SetActive(true);
        bloqueadoY[arrayPos].SetActive(false);
        if (arrayPos + 1 != 4 && arrayPos + 1 != 8)
        {
            botonY[arrayPos + 1].SetActive(false);
            bloqueadoY[arrayPos + 1].SetActive(true);
        }


    }

    // ALTAR A Z:
    public GameObject[] botonZ;

    public GameObject[] bloqueadoZ;

    public TextMeshProUGUI[] precioZTexto;

    public int[] precioZ;


    public void MejoraZ11()
    {
        if (Stats.favorDeDioses >= precioZ[0])
        {
            TropaStats.druidaAtaque *= 1.5f;
            TropaStats.druidaVelocidadDeDisparo *= 1.5f;
            Stats.favorDeDioses -= precioZ[0];
            Debug.Log("Z11");
        }
        else
        {
            StartCoroutine(EsperarZ(0));


        }
    }
    public void MejoraZ12()
    {
        if (Stats.favorDeDioses >= precioZ[1])
        {
            TropaStats.druidaAtaque *= 2f;
            Stats.favorDeDioses -= precioZ[1];
            Debug.Log("Z12");
        }
        else
        {
            StartCoroutine(EsperarZ(1));
        }
    }
    public void MejoraZ13()
    {
        if (Stats.favorDeDioses >= precioZ[2])
        {
            TropaStats.druidaAtaque *= 1.5f;
            TropaStats.druidaVelocidadDeDisparo *= 1.5f;
            Stats.favorDeDioses -= precioZ[2];
            Debug.Log("Z13");
        }
        else
        {
            StartCoroutine(EsperarZ(2));
        }
    }
    public void MejoraZ14()
    {
        if (Stats.favorDeDioses >= precioZ[3])
        {
            TropaStats.druidaAtaque *= 2f;
            Stats.favorDeDioses -= precioZ[3];
            Debug.Log("Z14");
        }
        else
        {
            StartCoroutine(EsperarZ(3));
        }
    }
    public void MejoraZ21()
    {
        if (Stats.favorDeDioses >= precioZ[4])
        {
            Stats.puedeMaldecir = true;
            Stats.favorDeDioses -= precioZ[4];
            Debug.Log("Z21");
        }
        else
        {
            StartCoroutine(EsperarZ(4));
        }
    }
    public void MejorarZ22()
    {
        if (Stats.favorDeDioses >= precioZ[5])
        {
            TropaStats.druidaMultiplicadorDano += 0.05f;
            Stats.favorDeDioses -= precioZ[5];
            Debug.Log("Z22");
        }
        else
        {
            StartCoroutine(EsperarZ(5));
        }
    }
    public void MejoraZ23()
    {
        if (Stats.favorDeDioses >= precioZ[6])
        {
            TropaStats.druidaMultiplicadorDano += 0.05f;
            Stats.favorDeDioses -= precioZ[6];
            Debug.Log("Z23");
        }
        else
        {
            StartCoroutine(EsperarZ(6));
        }
    }
    public void MejoraZ24()
    {
        if (Stats.favorDeDioses >= precioZ[7])
        {
            TropaStats.druidaMultiplicadorDano += 0.05f;
            Stats.favorDeDioses -= precioZ[7];
            Debug.Log("Z24");
        }
        else
        {
            StartCoroutine(EsperarZ(7));
        }
    }



    IEnumerator EsperarZ(int arrayPos)
    {
        yield return new WaitForSeconds(0.01f);
        botonZ[arrayPos].SetActive(true);
        bloqueadoZ[arrayPos].SetActive(false);
        if (arrayPos + 1 != 4 && arrayPos + 1 != 8)
        {
            botonZ[arrayPos + 1].SetActive(false);
            bloqueadoZ[arrayPos + 1].SetActive(true);
        }


    }

    // ALTAR A A:
    public GameObject[] botonA;

    public GameObject[] bloqueadoA;

    public TextMeshProUGUI[] precioATexto;

    public int[] precioA;


    public void MejoraA11()
    {
        if (Stats.favorDeDioses >= precioA[0])
        {
            TropaStats.inquisidorAtaque *= 1.5f;
            TropaStats.inquisidorVelocidadDeDisparo *= 1.5f;
            Stats.favorDeDioses -= precioA[0];
            Debug.Log("A11");
        }
        else
        {
            StartCoroutine(EsperarA(0));


        }
    }
    public void MejoraA12()
    {
        if (Stats.favorDeDioses >= precioA[1])
        {
            TropaStats.inquisidorAtaque *= 2f;
            Stats.favorDeDioses -= precioA[1];
            Debug.Log("A12");
        }
        else
        {
            StartCoroutine(EsperarA(1));
        }
    }
    public void MejoraA13()
    {
        if (Stats.favorDeDioses >= precioA[2])
        {
            TropaStats.inquisidorAtaque *= 1.5f;
            TropaStats.inquisidorVelocidadDeDisparo *= 1.5f;
            Stats.favorDeDioses -= precioA[2];
            Debug.Log("A13");
        }
        else
        {
            StartCoroutine(EsperarA(2));
        }
    }
    public void MejoraA14()
    {
        if (Stats.favorDeDioses >= precioA[3])
        {
            TropaStats.inquisidorAtaque *= 2f;
            Stats.favorDeDioses -= precioA[3];
            Debug.Log("A14");
        }
        else
        {
            StartCoroutine(EsperarA(3));
        }
    }
    public void MejoraA21()
    {
        if (Stats.favorDeDioses >= precioA[4])
        {
            Stats.puedeAtaqueArea = true;
            Stats.favorDeDioses -= precioA[4];
            Debug.Log("A21");
        }
        else
        {
            StartCoroutine(EsperarA(4));
        }
    }
    public void MejorarA22()
    {
        if (Stats.favorDeDioses >= precioA[5])
        {
            TropaStats.inquisidorMultiplicadorDano += 0.1f;
            Stats.favorDeDioses -= precioA[5];
            Debug.Log("A22");
        }
        else
        {
            StartCoroutine(EsperarA(5));
        }
    }
    public void MejoraA23()
    {
        if (Stats.favorDeDioses >= precioA[6])
        {
            TropaStats.inquisidorRadioAtaque *= 2f;
            Stats.favorDeDioses -= precioA[6];
            Debug.Log("A23");
        }
        else
        {
            StartCoroutine(EsperarA(6));
        }
    }
    public void MejoraA24()
    {
        if (Stats.favorDeDioses >= precioA[7])
        {
            TropaStats.inquisidorMultiplicadorDano += 0.1f;
            Stats.favorDeDioses -= precioA[7];
            Debug.Log("A24");
        }
        else
        {
            StartCoroutine(EsperarA(7));
        }
    }



    IEnumerator EsperarA(int arrayPos)
    {
        yield return new WaitForSeconds(0.01f);
        botonA[arrayPos].SetActive(true);
        bloqueadoA[arrayPos].SetActive(false);
        if (arrayPos + 1 != 4 && arrayPos + 1 != 8)
        {
            botonA[arrayPos + 1].SetActive(false);
            bloqueadoA[arrayPos + 1].SetActive(true);
        }


    }
}
