using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStats : MonoBehaviour
{
   // HUD
    public TextMeshProUGUI vidaJugadorTexto;

    public TextMeshProUGUI comidaTexto;

    public TextMeshProUGUI oroTexto;
    public TextMeshProUGUI oroBarraconesTexto;

    public TextMeshProUGUI favorTexto;
    public TextMeshProUGUI favorTemploTexto;
    public TextMeshProUGUI favorColegioTexto;

    public TextMeshProUGUI poblacionTexto;

    public TextMeshProUGUI poblacionCultivoTexto;
    public TextMeshProUGUI poblacionMinaTexto;

    public TextMeshProUGUI hechicerosBotonTexto;
    public TextMeshProUGUI verdugosBotonTexto;
    public TextMeshProUGUI druidasBotonTexto;
    public TextMeshProUGUI inquisidoresBotonTexto;
    public TextMeshProUGUI arquerosBotonTexto;
    public TextMeshProUGUI lancerosBotonTexto;
    public TextMeshProUGUI lanzadoresHachasBotonTexto;


    private void Start()
    {
        InvokeRepeating("refrescarUI", 0, 0.1f);
    }

    private int comidaEnMiles;
    private int comidaEnMilesResto;
    private int oroEnMiles;
    private int oroEnMilesResto;
    private int favorEnMiles;
    private int favorEnMilesResto;
    void refrescarUI()
    {
        vidaJugadorTexto.text = " " + Stats.vidaJugador.ToString();

        if (!Stats.comidaMil)
        {
            comidaTexto.text = " " + Stats.comida.ToString();
 
        }
        else if (Stats.comidaMil)
        {
            comidaEnMiles = (Stats.comida / 1000);
            comidaEnMilesResto = ((Stats.comida - (1000 * comidaEnMiles)) / 100);
            comidaTexto.text = " " + comidaEnMiles.ToString() + "," + comidaEnMilesResto.ToString() + "K";
        }

        if (!Stats.oroMil)
        {
            oroTexto.text = " " + Stats.oro.ToString();

        }
        else if (Stats.oroMil)
        {
            oroEnMiles = (Stats.oro / 1000);
            oroEnMilesResto = ((Stats.oro - (1000 * oroEnMiles)) / 100);
            oroTexto.text = " " + oroEnMiles.ToString() + "," + oroEnMilesResto.ToString() + "K";

        }

        if (!Stats.favorDeDiosesMil)
        {
            favorTexto.text = " " + Stats.favorDeDioses.ToString();
        }
        else if (Stats.favorDeDiosesMil)
        {
            favorEnMiles = (Stats.favorDeDioses / 1000);
            favorEnMilesResto = ((Stats.favorDeDioses - (1000 * favorEnMiles)) / 100);
            favorTexto.text = " " + favorEnMiles.ToString() + "," + favorEnMilesResto.ToString() + "K";
        }

        hechicerosBotonTexto.text = Stats.hechiceros.ToString();
        verdugosBotonTexto.text = Stats.verdugos.ToString();
        druidasBotonTexto.text = Stats.druidas.ToString();
        inquisidoresBotonTexto.text = Stats.inquisidores.ToString();
        arquerosBotonTexto.text = Stats.arqueros.ToString();
        lancerosBotonTexto.text = Stats.lanceros.ToString();
        lanzadoresHachasBotonTexto.text = Stats.lanzadoresHacha.ToString();

        poblacionTexto.text = " " + Stats.poblacion.ToString() + " (" + Stats.poblacionLibre.ToString() + ")";
        

        poblacionMinaTexto.text = Stats.poblacionEnMina.ToString() + " mineros";
        poblacionCultivoTexto.text = Stats.poblacionEnCultivo.ToString() + " granjeros";
    }
}
