using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStats : MonoBehaviour
{
   // HUD
    public TextMeshProUGUI vidaJugadorTexto;

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
    public TextMeshProUGUI arquerosBotonTexto;


    private void Start()
    {
        InvokeRepeating("refrescarUI", 0, 0.1f);
    }


    private int oroEnMiles;
    private int oroEnMilesResto;
    private int favorEnMiles;
    private int favorEnMilesResto;
    void refrescarUI()
    {
        vidaJugadorTexto.text = " " + Stats.vidaJugador.ToString();

        if (!Stats.oroMil)
        {
            oroTexto.text = " " + Stats.oro.ToString();
            oroBarraconesTexto.text = " " + Stats.oro.ToString();
        }
        else if (Stats.oroMil)
        {
            oroEnMiles = (Stats.oro / 1000);
            oroEnMilesResto = ((Stats.oro - (1000 * oroEnMiles)) / 100);
            oroTexto.text = " " + oroEnMiles.ToString() + "," + oroEnMilesResto.ToString() + "K";
            oroBarraconesTexto.text = " " + oroEnMiles.ToString() + "," + oroEnMilesResto.ToString() + "K";
        }

        if (!Stats.favorDeDiosesMil)
        {
            favorTexto.text = " " + Stats.favorDeDioses.ToString();
            favorTemploTexto.text = " " + Stats.favorDeDioses.ToString();
            favorColegioTexto.text = " " + Stats.favorDeDioses.ToString();
        }
        else if (Stats.favorDeDiosesMil)
        {
            favorEnMiles = (Stats.favorDeDioses / 1000);
            favorEnMilesResto = ((Stats.favorDeDioses - (1000 * favorEnMiles)) / 100);
            favorTexto.text = " " + favorEnMiles.ToString() + "," + favorEnMilesResto.ToString() + "K";
            favorTemploTexto.text = " " + favorEnMiles.ToString() + "," + favorEnMilesResto.ToString() + "K";
            favorColegioTexto.text = " " + favorEnMiles.ToString() + "," + favorEnMilesResto.ToString() + "K";
        }

        hechicerosBotonTexto.text = Stats.hechiceros.ToString();
        verdugosBotonTexto.text = Stats.verdugos.ToString();
        arquerosBotonTexto.text = Stats.arqueros.ToString();

        poblacionTexto.text = " " + Stats.comida.ToString() + " (" + Stats.comidaLibre.ToString() + ")";
        

        poblacionMinaTexto.text = Stats.comidaEnMina.ToString() + " mineros";
        poblacionCultivoTexto.text = Stats.comidaEnCultivo.ToString() + " granjeros";
    }
}
