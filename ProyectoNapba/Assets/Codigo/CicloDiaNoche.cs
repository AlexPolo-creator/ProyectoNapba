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
    float tick; //los ticks indica cuantos segundos del juego pasan por cada segundo real 
    float segundos;
    int minutos;
    public int horas = 10;
    int dias = 1;

    float rate = 0.18f;

    public bool activarLuces; 
    public GameObject[] luces; 

    
    void Start()
    {
        sol = GetComponent<Light>();
        tick = 24 * 60 / minutosPorDia;
        rate = rate * 1 / minutosPorDia;
        
    }

    
    void Update() 
    {
        CalculoTiempo();
        MostrarTiempo();
        
    }

    public void CalculoTiempo() // Pasa los segundos a minutos, los minutos a horas, y las horas a dias
    {
        segundos += Time.deltaTime * tick; //transforma los segundo reales a segundos del juego

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
        CambiaIntensidad(); //cambia la intensidad del sol en funcion de la hora
    }

    public void CambiaIntensidad() // used to adjust the post processing slider.
    {

        //ppv.weight = 0;
        if (horas>=20 && horas<22) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
        {
            sol.intensity -= rate * Time.deltaTime; // since dusk is 1 hr, we just divide the mins by 60 which will slowly increase from 0 - 1
            Debug.Log("funciona");
        }

        if (horas == 21 && minutos == 30) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
        {
            
            if (activarLuces == false) // if lights havent been turned on
            {
                for (int i = 0; i < luces.Length; i++)
                {
                    luces[i].SetActive(true);
                }
                activarLuces = true;

            }
        }

        if (horas == 22) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
        {
            sol.intensity = 0.08f; // since dusk is 1 hr, we just divide the mins by 60 which will slowly increase from 0 - 1
            
        }

        if (horas>=6 && horas<8) // Dawn at 6:00 / 6am    -   until 7:00 / 7am
        {
            sol.intensity += rate * Time.deltaTime;
        }

        if (horas == 7) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
        {
            
            if (activarLuces == true) // if lights havent been turned on
            {
                for (int i = 0; i < luces.Length; i++)
                {
                    luces[i].SetActive(false);
                }
                activarLuces = false;

            }
        }

        if (horas == 8) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
        {
            sol.intensity = 1; // since dusk is 1 hr, we just divide the mins by 60 which will slowly increase from 0 - 1
            
        }

    }

    public void MostrarTiempo() // Shows time and day in ui
    {

        horaDisplay.text = string.Format("{0:00}:{1:00}", horas, minutos); // The formatting ensures that there will always be 0's in empty spaces
        diaDisplay.text = "Day: " + dias; // display day counter
    }
}
