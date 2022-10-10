using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    //variables especificadas en el inspector con las coordenadas de la pos de la camara para la ciudad y el campo de batalla
    public Transform ciudad;
    public Transform batalla;

    public bool enCiudad;

    public SpriteRenderer rangoCamara;
    public SpriteRenderer rangoCamaraSecundario;

    Camera camara;

    Vector3 camaraObjetivo;

    Vector3 puntoOrigen;

    float maxX;
    float minX;
    float maxY;
    float minY;

    float maxXSec;
    float minXSec;
    float maxYSec;
    float minYSec;

    float camaraZoom = 5;
    public float velocidadZoom;
    public float minZoom;
    public float maxZoom;
    public float cantidadZoom;

    public float deslizamientoCamara;
    
    public float velocidadSeguimientoCamara = 1f;

    //variable especificadas en el inspector con la desviación en la z necesaria para que la camara funcione
    public Vector3 desviacionCamaraZ;

    private void Start()
    {
        camara = gameObject.GetComponent<Camera>();
        camaraZoom = 5;

        minX = rangoCamara.transform.position.x - rangoCamara.bounds.size.x / 2f;
        maxX = rangoCamara.transform.position.x + rangoCamara.bounds.size.x / 2f;
        minY = rangoCamara.transform.position.y - rangoCamara.bounds.size.y / 2f;
        maxY = rangoCamara.transform.position.y + rangoCamara.bounds.size.y / 2f;

        minXSec = rangoCamaraSecundario.transform.position.x - rangoCamaraSecundario.bounds.size.x / 2f;
        maxXSec = rangoCamaraSecundario.transform.position.x + rangoCamaraSecundario.bounds.size.x / 2f;
        minYSec = rangoCamaraSecundario.transform.position.y - rangoCamaraSecundario.bounds.size.y / 2f;
        maxYSec = rangoCamaraSecundario.transform.position.y + rangoCamaraSecundario.bounds.size.y / 2f;
    }

    private void Update()
    {

        if (batalla.position == transform.position)
        {

            enCiudad = false;
        }

        if (!enCiudad)
        {
            if (Input.GetMouseButtonDown(0))
            {

                puntoOrigen = camara.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {

                Vector3 diferencia = puntoOrigen - camara.ScreenToWorldPoint(Input.mousePosition);
                transform.position += diferencia * deslizamientoCamara;
                camaraObjetivo += diferencia;

            }
            if (Input.mouseScrollDelta.y > 0)
            {
                camaraZoom -= cantidadZoom * Time.unscaledDeltaTime;
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                camaraZoom += cantidadZoom * Time.unscaledDeltaTime;
            }
            camaraZoom = Mathf.Clamp(camaraZoom, maxZoom, minZoom);
        }
        
       
        SeguimientoCamara();
    }

    void SeguimientoCamara()
    {
        if (!enCiudad)
        {
            camaraObjetivo = ClampCamara(camaraObjetivo);
            transform.position = ClampCamaraSecundario(transform.position);
        }
        
        Vector2 dir = camaraObjetivo - transform.position;
        transform.Translate(dir * velocidadSeguimientoCamara * Time.unscaledDeltaTime, Space.World);

        float camaraZoomDiff = camaraZoom - camara.orthographicSize;
        camara.orthographicSize += camaraZoomDiff * velocidadZoom * Time.unscaledDeltaTime;

        
    }

    Vector3 ClampCamara(Vector3 objetivoPos)
    {
        float camAltura = camara.orthographicSize;
        float camAnchura = camara.orthographicSize * camara.aspect;

        float minCamX = minX + camAnchura;
        float maxCamX = maxX - camAnchura;
        float minCamY = minY + camAltura;
        float maxCamy = maxY - camAltura;

        float X = Mathf.Clamp(objetivoPos.x, minCamX, maxCamX);
        float Y = Mathf.Clamp(objetivoPos.y, minCamY, maxCamy);

        return new Vector3(X, Y, objetivoPos.z);
    }
    Vector3 ClampCamaraSecundario(Vector3 objetivoPos)
    {
        float camAltura = camara.orthographicSize;
        float camAnchura = camara.orthographicSize * camara.aspect;

        float minCamX = minXSec + camAnchura;
        float maxCamX = maxXSec - camAnchura;
        float minCamY = minYSec + camAltura;
        float maxCamy = maxYSec - camAltura;

        float X = Mathf.Clamp(objetivoPos.x, minCamX, maxCamX);
        float Y = Mathf.Clamp(objetivoPos.y, minCamY, maxCamy);

        return new Vector3(X, Y, objetivoPos.z);
    }

    //tpea la camara a la posicion de la ciudad
    public void irCiudad()
    {
        camaraObjetivo = ciudad.position;
        enCiudad = true;
        camaraZoom = 5;
    }

    //tpea la camara a la posicion de la batalla
    public void irBatlla()
    {
        camaraObjetivo = batalla.position;
        
    }
}
