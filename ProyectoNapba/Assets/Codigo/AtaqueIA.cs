
using UnityEngine;
using TMPro;

public class AtaqueIA : MonoBehaviour
{
    //el objetivo del ataque
    Transform objetivoAtaque;


    [Header("Que tropa es la atacante?:")]
    public string tipoTropa;
    public string queTropa;

    //stats del ataque
    public float velocidad = 50f;
    public float dañoAtaque = 25f;
    public int criticoAtaque = 1; //0 es si, cualquier otra cosa en no    
    private int maxCritNum;

    //tag de los objetos a los que puede considerar objetivos
    public string enemigoTag = "Enemigo";

    //el offset de rotacion inicial necesario para que salga apuntando al objetivo
    float rotacionDiff = 90f;

    //la velocidad a la que rota para mirar al objetivo, tiene que ser muy alta
    public float velocidadRotacion = 100f;

    //funcion por la cual establece su objetivo
    void BuscarObjetivo()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag(enemigoTag);
        float minimaDistancia = Mathf.Infinity;
        GameObject enemigoMasCercano = null;

        foreach (GameObject enemigo in enemigos)
        {
            float distanciaEnemigo = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distanciaEnemigo < minimaDistancia)
            {
                minimaDistancia = distanciaEnemigo;
                enemigoMasCercano = enemigo;
            }
        }

        if (enemigoMasCercano != null)
        {
            objetivoAtaque = enemigoMasCercano.transform;
        }
        else
        {
            objetivoAtaque = null;
        }


    }

    private bool esCrit = false;
    public Color colorCrit;
    void Start()
    {
        if (queTropa == "hechicero")
        {
            if (TropaStats.hechiceroCriticoPorcentaje != 0)
            {
                maxCritNum = Mathf.RoundToInt(1 / TropaStats.hechiceroCriticoPorcentaje * 100);
                criticoAtaque = Random.Range(0, maxCritNum);
                
            }
            else
            {
                criticoAtaque = 1;
            }

            if (criticoAtaque == 0)
            {
                dañoAtaque = TropaStats.hechiceroAtaque * Stats.dañoCritico;
                esCrit = true;
            }
            else
            {
                dañoAtaque = TropaStats.hechiceroAtaque;
            }
        }
        else if (queTropa == "verdugo")
        {
            Debug.Log("verdugo");
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
                dañoAtaque = TropaStats.verdugoAtaque * Stats.dañoCritico;
                esCrit = true;
            }
            else
            {
                dañoAtaque = TropaStats.verdugoAtaque;
            }
            Debug.Log("daño:" + dañoAtaque);
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
                dañoAtaque = TropaStats.arqueroAtaque * Stats.dañoCritico;
                esCrit = true;
            }
            else
            {
                dañoAtaque = TropaStats.arqueroAtaque;
            }            
        }
        
        
        //ejecuta la funcion de buscar objetivo, al estar en Start lo hara solo al crearse el objeto por lo que si su objetivo muere se destruye el objeto, si queremos que un ataque al morir su objetivo busque otro se tendria que poner esta funcion en Update mas unos cambios y listo
        BuscarObjetivo();
    }

    // Update is called once per frame
    void Update()
    {
        
        //si su objetivo muere el ataque desaparece
        if (objetivoAtaque == null) 
        {
            //destruimos el ataque
            Destroy(gameObject);

            //hago return para asegurarme de que la funcion Destroy() se haya terminado de ejecutar antes de continuar
            return;

            //TODO: particulas cuando desaparece un ataque

        }

        //calcula el vector direccion hacia el objetivo
        Vector3 dir = objetivoAtaque.position - transform.position;

        //calcula la distacia que viajara este fotograma
        float distanciaEsteFotograma = velocidad * Time.deltaTime;

        //si la distancia que va a viajar este fotograma es major que la magnitud del vector direccion, es decir, esta mas cerca de la distacia que viajará por lo que se pasara de lago, por lo consideramos que ha golpeado al objetivo. Con esto evitamos bugs de que se pase de largo y esas cosas
        if (dir.magnitude <= distanciaEsteFotograma)
        {
            DañarObjetivo();            
        }

        //trasladamos el objeto hacia el objetivo
        transform.Translate(dir.normalized * distanciaEsteFotograma, Space.World);

        //codigo que realiza la rotaccion del ataque al objetivo, ni putas de como funciona
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - rotacionDiff;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * velocidadRotacion);
        
    }


    //funcion que daña al objetivo en funcion del daño del atque y destryue el ataque
    void DañarObjetivo()
    {
        Debug.Log("daño:" + dañoAtaque);
        ActivarDañoPopUp(Mathf.RoundToInt(dañoAtaque));

        //obtenemos el codigo del objetivo
        EnemigoIA e = objetivoAtaque.GetComponent<EnemigoIA>();

        //al tener el codigo podemos ejecutar la funcion recibirDaño() del objetivo
       
        e.recibirDaño(dañoAtaque);

        if (dañoAtaque >= e.vidaEnemigo)
        {

            dañoAtaque = e.vidaEnemigo; //con esto evitamos que el daño registrado sea mayor que la vida restante del objetivo en caso de que el objetivo vaya a morir ya

        }

        if (tipoTropa == "hechicero")
        {
            Stats.dañoCausadoHechicero += Mathf.RoundToInt(dañoAtaque);
        }
        else if (tipoTropa == "verdugo")
        {
            Stats.dañoCausadoVerdugo += Mathf.RoundToInt(dañoAtaque);
        }
        else if (tipoTropa == "arquero")
        {
            Stats.dañoCausadoArquero += Mathf.RoundToInt(dañoAtaque);
        }

        //destruimos el ataque
        Destroy(gameObject);

        //hago return para asegurarme de que la funcion Destroy() se haya terminado de ejecutar antes de continuar
        return;
    }

    public GameObject PopUpDaño;
    TextMeshPro textoPopUp;
    void ActivarDañoPopUp(int cantidadDaño)
    {       
        textoPopUp = PopUpDaño.GetComponent<TextMeshPro>();
        if (esCrit)
        {
            textoPopUp.color = colorCrit;
            textoPopUp.fontSize = 12;
        }
        else
        {
            textoPopUp.color = Color.white;
            textoPopUp.fontSize = 10;
        }      
        textoPopUp.SetText(cantidadDaño.ToString());
        Instantiate(PopUpDaño, objetivoAtaque.position, Quaternion.identity);
    }

}
