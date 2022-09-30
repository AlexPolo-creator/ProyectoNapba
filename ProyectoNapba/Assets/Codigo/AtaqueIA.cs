
using UnityEngine;

public class AtaqueIA : MonoBehaviour
{
    Transform objetivoAtaque;

    public float velocidad = 50f;

    public string enemigoTag = "Enemigo";

    public float rotacionDiff = 90f;
    public float velocidadRotacion = 100f;

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
        BuscarObjetivo();
    }

    // Update is called once per frame
    void Update()
    {
        if (objetivoAtaque == null) 
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = objetivoAtaque.position - transform.position;
        float distanciaEsteFotograma = velocidad * Time.deltaTime;

        if (dir.magnitude <= distanciaEsteFotograma)
        {
            dañarObjetivo();
            return;
        }

        transform.Translate(dir.normalized * distanciaEsteFotograma, Space.World);

        
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - rotacionDiff;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * velocidadRotacion);

        void dañarObjetivo() 
        {
            Destroy(objetivoAtaque.gameObject);
            Destroy(gameObject);
        }

        

    }
}
