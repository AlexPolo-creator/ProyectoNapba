
using UnityEngine;
using TMPro;

public class AtaqueIA : MonoBehaviour
{   
    Transform objetivoAtaque; //el objetivo del ataque, lo establecemos en Start()

    [Header("Que tropa es la atacante?:")]
    public string tipoTropa; //el tipo general, es decir, es un mago o es infanteria
    public string queTropa; //dentro de su tipo, que tropa es, es decir, si es mago, es un Hechicero?, un verdugo?, etc

    //stats del ataque:
    public float velocidad = 50f; //la velocidad a la que el ataque se mueve (principalmente estético)

    float danoAtaque; //el daño no es modificabel ya que se establece su valor al impactar con el objetivo
    int criticoAtaque = 1; //variable usada para determinar si el ataque será critico, 0 es si, cualquier otra cosa en no  NO TOCAR  
    int maxCritNum; //variable usada para determinar si el ataque será critico, determina el maximo numero para el Random.Range en funcion del porcentaje critico de la tropa

    public string enemigoTag = "Enemigo"; //tag de los objetos a los que puede considerar objetivos NO TOCAR

    float rotacionDiff = 90f;//el offset de rotacion inicial necesario para que salga apuntando al objetivo NO TOCAR

    public float velocidadRotacion = 100f;    //la velocidad a la que rota para mirar al objetivo, tiene que ser muy alta
  

    void BuscarObjetivo()//funcion por la cual establece su objetivo
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag(enemigoTag); //crea un array con todos los gameObjects con el tag que establecemos antes
        float minimaDistancia = Mathf.Infinity; //cramos el float de distancia minima para determinar la ultima distancia mas cercana detectada. Hacemos que el default de esto sea infinito para que cualquier enemigo este mas cerca que el infinito
        GameObject enemigoMasCercano = null; //creamos la variable de tipo GameObject del enemigo mas cercano para almacenar cual es el enemigo mas cercano, Hacemos que el default de esto sea null

        foreach (GameObject enemigo in enemigos) //iteramos esta funcion por y para cada componente del array de enemigos
        {
            float distanciaEnemigo = Vector3.Distance(transform.position, enemigo.transform.position); //calculamos la distancia de la tropa hasta el enemigo que estamos iternado
            if (distanciaEnemigo < minimaDistancia) //si la distancia hasta este enemigo es menor que la ultima distancia mas cercana detectada cambiamos esta distancia mas cercana detectada (minimaDistancia) a la del enemigo sobre el que hemos iterado y establecemos el enemigo mas cercano como el enemigo que tenemos iterado
            {
                minimaDistancia = distanciaEnemigo; //establecemos la distancia mas cercana detectada (minimaDistancia) a la del enemigo sobre el que hemos iterado
                enemigoMasCercano = enemigo; //establecemos el enemigo mas cercano como el enemigo que tenemos iterado
            }
        }

        if (enemigoMasCercano != null)
        {
            objetivoAtaque = enemigoMasCercano.transform; //establecemos el objetivo del ataque como el transform del enemigo mas cercano
        }
        else
        {
            objetivoAtaque = null; //si no hay enemigo mas cercano 
        }


    }

    private bool esCrit = false; //esta varible determina si el atque es critico
    private bool esEjecucion = false; //esta variable determina en caso de que sea un ataque de verdugo si el ataque es una ejecucion
    public Color colorCrit; //el color del texto del popUp en caso de que sea un critico
    public Color colorEjecucion; //esto a futuro lo cambiaremos por una animacion o algo
    void Start()
    {
        if (queTropa == "hechicero")//si el ataque fue lanzado por un hechicero
        {
            if (TropaStats.hechiceroCriticoPorcentaje != 0)
            {
                maxCritNum = Mathf.RoundToInt(1 / TropaStats.hechiceroCriticoPorcentaje * 100); //establecemos en maxCritNum en funcion del porcentaje de critico
                criticoAtaque = Random.Range(0, maxCritNum); //sacamos un numero aleatorio del 0 al maxCritNum, si es 0 el ataque sera critico, si alguien no entiende como funciona este sistema que me he invetao que me escriba por was que me da pereza explicarlo, PERO FUNCIONA         
            }
            else
            {
                criticoAtaque = 1;
            }

            if (criticoAtaque == 0)
            {
                danoAtaque = TropaStats.hechiceroAtaque * Stats.danoCritico; //establecemos el daño en funcion del daño de la tropa multiplicado por el daño crit
                esCrit = true;
            }
            else
            {
                danoAtaque = TropaStats.hechiceroAtaque;
            }
        }
        else if (queTropa == "verdugo")
        {
            if (TropaStats.verdugoCriticoPorcentaje != 0)
            {
                maxCritNum = Mathf.RoundToInt(1 / TropaStats.verdugoCriticoPorcentaje * 100);
                criticoAtaque = Random.Range(0, maxCritNum);

            }
            else
            {
                criticoAtaque = 1;
            }
            if (criticoAtaque == 0)
            {
                danoAtaque = TropaStats.verdugoAtaque * Stats.danoCritico;
                esCrit = true;
            }
            else
            {
                danoAtaque = TropaStats.verdugoAtaque;
            }
        }
        else if (queTropa == "druida")
        {
            if (TropaStats.druidaCriticoPorcentaje != 0)
            {
                maxCritNum = Mathf.RoundToInt(1 / TropaStats.druidaCriticoPorcentaje * 100);
                criticoAtaque = Random.Range(0, maxCritNum);
            }
            else
            {
                criticoAtaque = 1;
            }
            if (criticoAtaque == 0)
            {
                danoAtaque = TropaStats.druidaAtaque * Stats.danoCritico;
                esCrit = true;
            }
            else
            {
                danoAtaque = TropaStats.druidaAtaque;
            }
        }
        else if (queTropa == "inquisidor")
        {
            if (TropaStats.inquisidorCriticoPorcentaje != 0)
            {
                maxCritNum = Mathf.RoundToInt(1 / TropaStats.inquisidorCriticoPorcentaje * 100);
                criticoAtaque = Random.Range(0, maxCritNum);
            }
            else
            {
                criticoAtaque = 1;
            }
            if (criticoAtaque == 0)
            {
                danoAtaque = TropaStats.inquisidorAtaque * Stats.danoCritico;
                esCrit = true;
            }
            else
            {
                danoAtaque = TropaStats.inquisidorAtaque;
            }
        }
        else if (queTropa == "arquero")
        {
            if (TropaStats.arqueroCriticoPorcentaje != 0)
            {
                maxCritNum = Mathf.RoundToInt(1 / TropaStats.arqueroCriticoPorcentaje * 100);
                criticoAtaque = Random.Range(0, maxCritNum);
                
            }
            else
            {
                criticoAtaque = 1;
            }
            if (criticoAtaque == 0)
            {
                danoAtaque = TropaStats.arqueroAtaque * Stats.danoCritico;
                esCrit = true;
            }
            else
            {
                danoAtaque = TropaStats.arqueroAtaque;
            }            
        }
        
        
        
        BuscarObjetivo();//ejecuta la funcion de buscar objetivo, al estar en Start lo hara solo al crearse el objeto por lo que si su objetivo muere se destruye el objeto, si queremos que un ataque al morir su objetivo busque otro se tendria que poner esta funcion en Update mas unos cambios y listo
    }

    // Update is called once per frame
    void Update()
    {
        if (objetivoAtaque == null)  //si su objetivo muere el ataque desaparece
        {
            //destruimos el ataque
            Destroy(gameObject);
            //hago return para asegurarme de que la funcion Destroy() se haya terminado de ejecutar antes de continuar
            return;
            //TODO: particulas cuando desaparece un ataque
        }   
        Vector3 dir = objetivoAtaque.position - transform.position;//calcula el vector direccion hacia el objetivo 
        float distanciaEsteFotograma = velocidad * Time.deltaTime;//calcula la distacia que viajara este fotograma
        
        if (dir.magnitude <= distanciaEsteFotograma)//si la distancia que va a viajar este fotograma es mayor que la magnitud del vector direccion, es decir, esta mas cerca de la distacia que viajara por lo que se pasara de lago, por lo consideramos que ha golpeado al objetivo. Con esto evitamos bugs de que se pase de largo y esas cosas
        {
            DanarObjetivo();            
        }
        
        transform.Translate(dir.normalized * distanciaEsteFotograma, Space.World);//trasladamos el objeto hacia el objetivo

        //codigo que realiza la rotaccion del ataque al objetivo, ni putas de como funciona
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - rotacionDiff;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * velocidadRotacion);       
    }


    //funcion que daña al objetivo en funcion del daño del atque y destryue el ataque
    void DanarObjetivo()
    {        
        EnemigoIA e = objetivoAtaque.GetComponent<EnemigoIA>();//obtenemos el codigo del objetivo

        if (queTropa == "verdugo" && e.vidaEnemigo <= (e.vidaEnemigoInicial * TropaStats.verdugoPuntoEjecucion)) //si el ataque es de un verdugo y el enemigo tiene menos vida que el punto de ejecucion ehecutamos al objetivo
        {
            danoAtaque = e.vidaEnemigo;
            esEjecucion = true;          
        }

        if (queTropa == "druida") //si el ataque es de un druida
        {           
            danoAtaque *= 1 + (e.cargasDruida * e.cargasDruida * TropaStats.druidaMultiplicadorDano);
            e.cargasDruida++;
        }

        if (queTropa == "inquisidor") //si el ataque es de un druida
        {
            GameObject[] enemigos = GameObject.FindGameObjectsWithTag(enemigoTag); //crea un array con todos los gameObjects con el tag que establecemos antes
            
            foreach (GameObject enemigo in enemigos) //iteramos esta funcion por y para cada componente del array de enemigos
            {
                float distanciaEnemigo = Vector3.Distance(transform.position, enemigo.transform.position); //calculamos la distancia de la tropa hasta el enemigo que estamos iternado
                if (distanciaEnemigo <= TropaStats.inquisidorRadioAtaque && enemigo.transform != objetivoAtaque)
                {
                    EnemigoIA e2 = enemigo.GetComponent<EnemigoIA>();

                    e2.recibirDano(danoAtaque * TropaStats.inquisidorMultiplicadorDano);

                    textoPopUp = PopUpDano.GetComponent<TextMeshPro>();
                    if (esCrit)
                    {
                        textoPopUp.color = colorCrit;
                        textoPopUp.fontSize = 12;
                    }
                    else if (!esCrit)
                    {
                        textoPopUp.color = Color.white;
                        textoPopUp.fontSize = 10;
                    }
                    textoPopUp.SetText((Mathf.RoundToInt(danoAtaque * TropaStats.inquisidorMultiplicadorDano)).ToString());
                    Instantiate(PopUpDano, enemigo.transform.position, Quaternion.identity);
                }
            }
        }

        ActivarDanoPopUp(Mathf.RoundToInt(danoAtaque)); //activamos el popup de daño

        if (danoAtaque >= e.vidaEnemigo) //si el daño de este ataque es mayor que la vida restante que tiene
        {
            danoAtaque = e.vidaEnemigo; //con esto evitamos que el da�o registrado sea mayor que la vida restante del objetivo en caso de que el objetivo vaya a morir ya
        }

        e.recibirDano(danoAtaque);//al tener el codigo podemos ejecutar la funcion recibirDano() del objetivo


        if (queTropa == "hechicero") //si es un hechicero
        {
            Stats.danoCausadoHechicero += Mathf.RoundToInt(danoAtaque);
        }
        else if (queTropa == "verdugo") //si es un verdugo
        {
            Stats.danoCausadoVerdugo += Mathf.RoundToInt(danoAtaque);
        }
        else if (queTropa == "druida") //si es un druida
        {
            Stats.danoCausadoDruida += Mathf.RoundToInt(danoAtaque);
        }
        else if (queTropa == "inquisidor") //si es un inquisidor
        {
            Stats.danoCausadoInquisidor += Mathf.RoundToInt(danoAtaque);
        }
        else if (queTropa == "arquero") //si es un arquero
        {
            Stats.danoCausadoArquero += Mathf.RoundToInt(danoAtaque);
        }

        //destruimos el ataque
        Destroy(gameObject);

        //hago return para asegurarme de que la funcion Destroy() se haya terminado de ejecutar antes de continuar
        return;
    }


    public GameObject PopUpDano;
    TextMeshPro textoPopUp;
    void ActivarDanoPopUp(int cantidadDano)
    {       
        textoPopUp = PopUpDano.GetComponent<TextMeshPro>();
        if (esCrit && !esEjecucion)
        {
            textoPopUp.color = colorCrit;
            textoPopUp.fontSize = 12;
        }
        else if (!esCrit && !esEjecucion)
        {
            textoPopUp.color = Color.white;
            textoPopUp.fontSize = 10;
        }else if (esEjecucion)
        {
            textoPopUp.color = colorCrit;
            textoPopUp.SetText("Ejecución");
            Instantiate(PopUpDano, objetivoAtaque.position, Quaternion.identity);
            return;
        }      
        textoPopUp.SetText(cantidadDano.ToString());
        Instantiate(PopUpDano, objetivoAtaque.position, Quaternion.identity);
    }
}
