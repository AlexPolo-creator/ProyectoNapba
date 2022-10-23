using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Herreria : MonoBehaviour
{
    public GameObject[] restoBotones;
    public GameObject esteBoton;

    public Color hoverColor; //color cuando poner el cursor por encima   
    private SpriteRenderer sprite; //creamos la variable sprite para poder cambiarle el color al SpriteRenderer de la mina   
    public Color colorInicial; //creamos la variable colorInicial para poder reestablecer inical el color al SpriteRenderer de la mina cuando quitemos el cursor de encima

    public static bool menuActivado = false;

    public GameObject getMenuHerreria;
    public static GameObject menuHerreria;


    // Start is called before the first frame update
    void Start()
    {
        menuHerreria = getMenuHerreria;
        
        numBotonesMejoraActivos = 0;

        precioOrgullo = precioInicialOrgullo;
        precioMetalurgiaAvanzada = precioInicialMetalurgiaAvanzada;
        precioLentesSagaces = precioInicialLentesSagaces;
        precioPuntasReforzadas = precioInicialPuntasReforzadas;
        precioDestreza = precioInicialDestreza;


        botonOrgulloActivado = false;
        botonMetalurgiaAvanzadaActivado = false;
        botonPuntasReforzadasActivado = false;
        botonDestrezaActivado = false;
        botonLentesSagacesActivado = false;

        numOrgullo = 0;
        numMetalurgiaAvanzada = 0;
        numPuntasReforzadas = 0;
        numDestreza = 0;
        numLentesSagaces = 0;

        mejoraOrgullo = false;
        mejoraMetalurgiaAvanzada = false;
        mejoraPuntasReforzadas = false;
        mejoraDestreza = false;
        mejoraLentesSagaces = false;
        
        //obtemos el componente SpriteRenderer de la mina
        sprite = GetComponent<SpriteRenderer>();

        //establecemos el color inicial al color de la mina al comienzo
        sprite.color = colorInicial;
    }

    public void desactivarMenu()
    {
        menuActivado = false;

        foreach(GameObject boton in restoBotones)
            {
                boton.SetActive(true);

            }
            //esteBoton.SetActive(true);
    }

    //esta funcion se ejecuta al pulsar el nodo
    void OnMouseDown()
    {
        if (!menuActivado)
        {
            foreach(GameObject boton in restoBotones)
            {
                boton.SetActive(false);

            }
            //esteBoton.SetActive(true);
            Colegio.menuColegio.SetActive(false);
            Templo.menuTemplo.SetActive(false);
            Barracones.menuBarracones.SetActive(false);
            Colegio.menuActivado = false;
            Barracones.menuActivado = false;
            Templo.menuActivado = false;

            menuHerreria.SetActive(true);
            menuActivado = true;
            sprite.color = colorInicial;
        }
    }

    //esta funcion se ejecuta al colocar el cursor sobre el nodo
    void OnMouseEnter()
    {
        if (!menuActivado)
        {
            sprite.color = hoverColor;
        }
    }

    //esta funcion se ejecuta al quitar el cursor de encima del nodo
    void OnMouseExit()
    {
        sprite.color = colorInicial;
    }

    private int numBotonesMejoraActivos = 0;

    //Mejoras globales (Mejoras):
    public static bool mejoraMetalurgiaAvanzada;
    public bool botonMetalurgiaAvanzadaActivado = false;
    public TextMeshProUGUI textoMetalurgiaAvanzadaPrecio;
    public static int numMetalurgiaAvanzada;
    int precioMetalurgiaAvanzada;
    public int precioInicialMetalurgiaAvanzada = 75;
    public GameObject botonMetalurgiaAvanzada;

    public void ActivarMetalurgiaAvanzada()
    {
        if (Stats.oro >= precioMetalurgiaAvanzada)
        {
            botonMetalurgiaAvanzada.SetActive(false);
            botonMetalurgiaAvanzadaActivado = false;
            numBotonesMejoraActivos--;
            numMetalurgiaAvanzada++;
            mejoraMetalurgiaAvanzada = true;
            TropaStats.arqueroAtaque = TropaStats.arqueroAtaque * 1.1f;
            TropaStats.lanzadorHachasAtaque = TropaStats.lanzadorHachasAtaque * 1.1f;
            TropaStats.lanceroAtaque = TropaStats.lanceroAtaque * 1.1f;
            Stats.oro -= precioMetalurgiaAvanzada;
            precioMetalurgiaAvanzada = 2 * precioMetalurgiaAvanzada;
        }
    }

    public static bool mejoraDestreza;
    public bool botonDestrezaActivado = false;
    public static int numDestreza;
    public TextMeshProUGUI textoDestrezaPrecio;
    int precioDestreza;
    public int precioInicialDestreza;
    public GameObject botonDestreza;
    public void ActivarDestreza()
    {
        if (Stats.oro >= precioDestreza)
        {
            botonDestreza.SetActive(false);
            botonDestrezaActivado = false;
            numBotonesMejoraActivos--;
            numDestreza++;
            mejoraDestreza = true;
            TropaStats.arqueroVelocidadDeDisparo = TropaStats.arqueroVelocidadDeDisparo * (1 + (0.15f * numDestreza)); // + porque la velocidad de ataque de las tropas es ataques/segundo y no al reves
            TropaStats.lanzadorHachasVelocidadDeDisparo = TropaStats.lanzadorHachasVelocidadDeDisparo * (1 + (0.15f * numDestreza));
            TropaStats.lanceroVelocidadDeDisparo = TropaStats.lanceroVelocidadDeDisparo * (1 + (0.15f * numDestreza));
            Stats.oro -= precioDestreza;
            precioDestreza = 2 * precioDestreza;
        }
    }

    public static bool mejoraOrgullo;
    public bool botonOrgulloActivado = false;
    public static int numOrgullo;
    public TextMeshProUGUI textoOrgulloPrecio;
    int precioOrgullo;
    public int precioInicialOrgullo;
    public GameObject botonOrgullo;

    public void ActivarOrgullo()
    {
        if (Stats.oro >= precioOrgullo)
        {
            botonOrgullo.SetActive(false);
            botonOrgulloActivado = false;
            numBotonesMejoraActivos--;
            numOrgullo++;
            mejoraOrgullo = true;
            Stats.oro -= precioOrgullo;
            precioOrgullo = 2 * precioOrgullo;
        }
    }

    public static bool mejoraPuntasReforzadas;
    public bool botonPuntasReforzadasActivado = false;
    public static int numPuntasReforzadas;
    public TextMeshProUGUI textoPuntasReforzadasPrecio;
    int precioPuntasReforzadas;
    public int precioInicialPuntasReforzadas;
    public GameObject botonPuntasReforzadas;

    public void ActivarPuntasReforzadas()
    {
        if (Stats.oro >= precioPuntasReforzadas)
        {
            botonPuntasReforzadas.SetActive(false);
            botonPuntasReforzadasActivado = false;
            numBotonesMejoraActivos--;
            numPuntasReforzadas++;
            mejoraPuntasReforzadas = true;
            TropaStats.arqueroCriticoPorcentaje += 5f;
            TropaStats.lanzadorHachasCriticoPorcentaje += 5f;
            TropaStats.lanceroCriticoPorcentaje += 5f;
            Stats.oro -= precioPuntasReforzadas;
            precioPuntasReforzadas = 2 * precioPuntasReforzadas;
        }
    }

    public static bool mejoraLentesSagaces;
    public bool botonLentesSagacesActivado = false;
    public static int numLentesSagaces;
    public TextMeshProUGUI textoLentesSagacesPrecio;
    int precioLentesSagaces;
    public int precioInicialLentesSagaces;
    public GameObject botonLentesSagaces;

    public void ActivarLentesSagaces()
    {
        if (Stats.oro >= precioLentesSagaces)
        {
            botonLentesSagaces.SetActive(false);
            botonLentesSagacesActivado = false;
            numBotonesMejoraActivos--;
            numLentesSagaces++;
            mejoraLentesSagaces = true;
            TropaStats.arqueroRango += TropaStats.arqueroRango * 0.1f;
            TropaStats.lanzadorHachasRango += TropaStats.lanzadorHachasRango * 0.1f;
            TropaStats.lanceroRango += TropaStats.lanceroRango * 0.1f;
            Stats.oro -= precioLentesSagaces;
            precioLentesSagaces = 2 * precioLentesSagaces;
        }
    }

    int numActualArqueros = 0;
    int numActualLanzadoresHachas = 0;
    int numActualLanceros = 0;

    private void Update()
    {
        if (mejoraOrgullo && numActualArqueros < Stats.numArqueros)
        {
            TropaStats.arqueroAtaque = TropaStats.arqueroAtaque * (1 + (0.05f * Stats.numArqueros));
            numActualArqueros = Stats.numArqueros;
        }
        if (mejoraOrgullo && numActualLanzadoresHachas < Stats.numLanzadoresHacha)
        {
            TropaStats.lanzadorHachasAtaque = TropaStats.lanzadorHachasAtaque * (1 + (0.05f * Stats.numLanzadoresHacha));
            numActualLanzadoresHachas = Stats.numLanzadoresHacha;
        }
        if (mejoraOrgullo && numActualLanceros < Stats.numLanceros)
        {
            TropaStats.lanceroAtaque = TropaStats.lanceroAtaque * (1 + (0.05f * Stats.numLanceros));
            numActualLanceros = Stats.numLanceros;
        }

        if (numBotonesMejoraActivos < 3)
        {
            RandomMejoraGlobal();
            return;
        }
        
    }

    private int numRandom;
    public void RandomMejoraGlobal()
    {
        numRandom = Random.Range(0, 5); //el 5 no est� incluido (por el culo te la hinco)

        if (numRandom == 0)
        {
            if (!botonMetalurgiaAvanzadaActivado)
            {
                textoMetalurgiaAvanzadaPrecio.text = precioMetalurgiaAvanzada.ToString() + " de Oro";
                botonMetalurgiaAvanzada.SetActive(true);
                botonMetalurgiaAvanzadaActivado = true;
                numBotonesMejoraActivos++;
            }
        }
        else if (numRandom == 1)
        {
            if (!botonOrgulloActivado)
            {
                textoOrgulloPrecio.text = precioOrgullo.ToString() + " de Oro";
                botonOrgullo.SetActive(true);
                botonOrgulloActivado = true;
                numBotonesMejoraActivos++;
            }
        }
        else if (numRandom == 2)
        {
            if (numPuntasReforzadas < 10 && !botonPuntasReforzadasActivado)
            {
                textoPuntasReforzadasPrecio.text = precioPuntasReforzadas.ToString() + " de Oro";
                botonPuntasReforzadas.SetActive(true);
                botonPuntasReforzadasActivado = true;
                numBotonesMejoraActivos++;
            }
        }
        else if (numRandom == 3)
        {
            if (numDestreza < 5 && !botonDestrezaActivado)
            {
                textoDestrezaPrecio.text = precioDestreza.ToString() + " de Oro";
                botonDestreza.SetActive(true);
                botonDestrezaActivado = true;
                numBotonesMejoraActivos++;
            }
        }
        else if (numRandom == 4)
        {
            if (numLentesSagaces < 5 && !botonLentesSagacesActivado)
            {
                textoLentesSagacesPrecio.text = precioLentesSagaces.ToString() + " de Oro";
                botonLentesSagaces.SetActive(true);
                botonLentesSagacesActivado = true;
                numBotonesMejoraActivos++;
            }
        }
        return;
    }
}
