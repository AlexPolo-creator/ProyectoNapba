
using UnityEngine;

public class AtaqueIA : MonoBehaviour
{
    //el objetivo del ataque
    Transform objetivoAtaque;


    [Header("Que tropa es la atacante?:")]
    public string tipoTropa;

    //stats del ataque
    public float velocidad = 50f;
    public float da�oAtaque = 25f;
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

    void Start()
    {
        if (tipoTropa == "mago")
        {
            if (TropaStats.magoCriticoPorcentaje != 0)
            {
                maxCritNum = Mathf.RoundToInt(1 / TropaStats.magoCriticoPorcentaje * 100);
                criticoAtaque = Random.Range(0, maxCritNum);
                Debug.Log("num:" + criticoAtaque);
            }
            else
            {
                criticoAtaque = 1;
            }
            if (criticoAtaque == 0)
            {
                da�oAtaque = TropaStats.magoAtaque * Stats.da�oCritico;
            }
            else
            {
                da�oAtaque = TropaStats.magoAtaque;
            }
        }
        
        Debug.Log("Ataque:" + da�oAtaque);
        //ejecuta la funcion de buscar objetivo, al estar en Start lo hara solo al crearse el objeto por lo que si su objetivo muere se destruye el objeto, si queremos que un ataque al morir su objetivo busque otro se tendria que poner esta funcion en Update mas unos cambios y listo
        BuscarObjetivo();
    }

    // Update is called once per frame
    void Update()
    {
        da�oAtaque = TropaStats.magoAtaque;
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

        //si la distancia que va a viajar este fotograma es major que la magnitud del vector direccion, es decir, esta mas cerca de la distacia que viajar� por lo que se pasara de lago, por lo consideramos que ha golpeado al objetivo. Con esto evitamos bugs de que se pase de largo y esas cosas
        if (dir.magnitude <= distanciaEsteFotograma)
        {
            da�arObjetivo();            
        }

        //trasladamos el objeto hacia el objetivo
        transform.Translate(dir.normalized * distanciaEsteFotograma, Space.World);

        //codigo que realiza la rotaccion del ataque al objetivo, ni putas de como funciona
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - rotacionDiff;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * velocidadRotacion);

        //funcion que da�a al objetivo en funcion del da�o del atque y destryue el ataque
        void da�arObjetivo() 
        {
            //obtenemos el codigo del objetivo
            EnemigoIA e = objetivoAtaque.GetComponent<EnemigoIA>();

            //al tener el codigo podemos ejecutar la funcion recibirDa�o() del objetivo
            e.recibirDa�o(da�oAtaque);

            //destruimos el ataque
            Destroy(gameObject);

            //hago return para asegurarme de que la funcion Destroy() se haya terminado de ejecutar antes de continuar
            return;
        }       
    }
}
