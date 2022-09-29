using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; //permite usar TextMeshPro para el reloj


public class CicloDiaNoche : MonoBehaviour
{
    public TextMeshProUGUI horaDisplay; //poner la hora
    public TextMeshProUGUI diaDisplay; //poner el dia
    public Light sol;

    public float minutosPorDia;
    float tick; // Increasing the tick, increases second rate
    float segundos;
    int minutos;
    int horas = 10;
    int dias = 1;

    public bool activarLuces; // checks if lights are on
    public GameObject[] luces; // all the lights we want on when its dark

    // Start is called before the first frame update
    void Start()
    {
        sol = GetComponent<Light>();
        tick = 24 * 60 / minutosPorDia;
    }

    // Update is called once per frame
    void FixedUpdate() // we used fixed update, since update is frame dependant. 
    {
        CalculoTiempo();
        MostrarTiempo();
        
    }

    public void CalculoTiempo() // Used to calculate sec, min and hours
    {
        segundos += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick

        if (segundos >= 60) // 60 sec = 1 min
        {
            segundos = 0;
            minutos += 1;
        }

        if (minutos >= 60) //60 min = 1 hr
        {
            minutos = 0;
            horas += 1;
        }

        if (horas >= 24) //24 hr = 1 day
        {
            horas = 0;
            dias += 1;
        }
        CambiaIntensidad(); // changes post processing volume after calculation
    }

    public void CambiaIntensidad() // used to adjust the post processing slider.
    {

        //ppv.weight = 0;
        if (horas>=21 && horas<22) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
        {
            sol.intensity = 1 - (float)minutos / 60; // since dusk is 1 hr, we just divide the mins by 60 which will slowly increase from 0 - 1          
        }


        if (horas>=6 && horas<7) // Dawn at 6:00 / 6am    -   until 7:00 / 7am
        {
            sol.intensity = (float)minutos / 60; // we minus 1 because we want it to go from 1 - 0
            
         
        }

    }

    public void MostrarTiempo() // Shows time and day in ui
    {

        horaDisplay.text = string.Format("{0:00}:{1:00}", horas, minutos); // The formatting ensures that there will always be 0's in empty spaces
        diaDisplay.text = "Day: " + dias; // display day counter
    }
}
