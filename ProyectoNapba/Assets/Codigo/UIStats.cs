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
        vidaJugadorTexto.text = "Vida: " + Stats.vidaJugador.ToString();

        if (!Stats.oroMil)
        {
            oroTexto.text = "Oro: " + Stats.oro.ToString();
            oroBarraconesTexto.text = "Oro: " + Stats.oro.ToString();
        }
        else if (Stats.oroMil)
        {
            oroEnMiles = (Stats.oro / 1000);
            oroEnMilesResto = ((Stats.oro - (1000 * oroEnMiles)) / 100);
            oroTexto.text = "Oro: " + oroEnMiles.ToString() + "," + oroEnMilesResto.ToString() + "K";
            oroBarraconesTexto.text = "Oro: " + oroEnMiles.ToString() + "," + oroEnMilesResto.ToString() + "K";
        }

        if (!Stats.favorDeDiosesMil)
        {
            favorTexto.text = "Favor de dioses: " + Stats.favorDeDioses.ToString();
            favorTemploTexto.text = "Favor de dioses: " + Stats.favorDeDioses.ToString();
            favorColegioTexto.text = "Favor de dioses: " + Stats.favorDeDioses.ToString();
        }
        else if (Stats.favorDeDiosesMil)
        {
            favorEnMiles = (Stats.favorDeDioses / 1000);
            favorEnMilesResto = ((Stats.favorDeDioses - (1000 * favorEnMiles)) / 100);
            favorTexto.text = "Favor de Dioses: " + favorEnMiles.ToString() + "," + favorEnMilesResto.ToString() + "K";
            favorTemploTexto.text = "Favor de Dioses: " + favorEnMiles.ToString() + "," + favorEnMilesResto.ToString() + "K";
            favorColegioTexto.text = "Favor de Dioses: " + favorEnMiles.ToString() + "," + favorEnMilesResto.ToString() + "K";
        }

        hechicerosBotonTexto.text = Stats.hechiceros.ToString();
        verdugosBotonTexto.text = Stats.verdugos.ToString();
        arquerosBotonTexto.text = Stats.arqueros.ToString();

        poblacionTexto.text = "Poblacion: " + Stats.poblacion.ToString() + " (" + Stats.poblacionLibre.ToString() + ")";
        

        poblacionMinaTexto.text = Stats.poblacionEnMina.ToString() + " mineros";
        poblacionCultivoTexto.text = Stats.poblacionEnCultivo.ToString() + " granjeros";
    }
}
