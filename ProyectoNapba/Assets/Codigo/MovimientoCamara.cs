using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{   
    public Transform ciudad, batalla;//variables especificadas en el inspector con las coordenadas de la pos de la camara para la ciudad y el campo de batalla

    public bool enCiudad;//se utiliza para restringir el movimientod de la camara al campo de batalla
    public bool yendoCiudad;//se utiliza para saber cuando se esta yendo a la ciudad(motivos de bugfixing)

    public SpriteRenderer rangoCamara; //se establece en el inspector el raango del sprite del campo de batalla para poder especificar el rango del OBJETIVO de la camara
    public SpriteRenderer rangoCamaraSecundario; //se establece en el inspector para poder especificar el rango de la posicion a la que se puede mover la camara

    Camera camara; //se establece mediante GetComponent el componente Camera de la camara

    Vector3 camaraObjetivo; //este sera el onjetivo al cual se movera la camara en funcion del tiempo

    Vector3 puntoOrigen; //el punto en el que el jugador hace click para arrastrear a la camara, se usara para calcular la distancia a la que hay que mover el objetivo

    float maxX, minX, maxY, minY;//maximas y minimas posiciones en los ejes a las que el OBJETIVO de la camara se puede mover 

    float maxXSec, minXSec, maxYSec, minYSec;//maximas y minimas posiciones en los ejes a las que la camara se puede mover  

    public float camaraZoomInicial;
    float camaraZoom; //tamaño ortografico de la camara
    public float velocidadZoom; //velocidad a la que el tamaño ortografico se aproxima al tamaño ortografico objetivo
    public float minZoom, maxZoom; //maximo y minimo tamaño ortografico de la camara
    public float cantidadZoom; //cantidad que crece el tamaño ortografico del objetivo

    public float deslizamientoCamara; //multiplicador de deslizamiento de la camara al moverla con el raton (sin deslizamiento es = 1f)
    
    public float velocidadSeguimientoCamara = 1f; //velocidad a la que la posicion de la camara se aproxima a la del objetivo
  
    public Vector3 desviacionCamaraZ;//variable especificadas en el inspector con la desviación en la z necesaria para que la camara funcione

    private void Start()
    {
        camara = gameObject.GetComponent<Camera>(); //asignamos a la variable de tipo Camera llamada "camara" el componente de este gameObject (la mainCamera) de tipo Camera
        camaraZoom = camaraZoomInicial; //establecemos el zoom al zoom inicial (debe ser 5)

        minX = rangoCamara.transform.position.x - rangoCamara.bounds.size.x / 2f; //establecemos la minima X a la que puede moverse el objetivo de la camara en funcion del tamaño del sprite que asignamos como rango
        maxX = rangoCamara.transform.position.x + rangoCamara.bounds.size.x / 2f; //establecemos la maxima X a la que puede moverse el objetivo de la camara en funcion del tamaño del sprite que asignamos como rango
        minY = rangoCamara.transform.position.y - rangoCamara.bounds.size.y / 2f; //establecemos la minima Y a la que puede moverse el objetivo de la camara en funcion del tamaño del sprite que asignamos como rango
        maxY = rangoCamara.transform.position.y + rangoCamara.bounds.size.y / 2f; //establecemos la maxima Y a la que puede moverse el objetivo de la camara en funcion del tamaño del sprite que asignamos como rango

        minXSec = rangoCamaraSecundario.transform.position.x - rangoCamaraSecundario.bounds.size.x / 2f; //establecemos la minima X a la que puede moverse la camara en funcion del tamaño del sprite que asignamos como rango
        maxXSec = rangoCamaraSecundario.transform.position.x + rangoCamaraSecundario.bounds.size.x / 2f; //establecemos la maxima X a la que puede moverse la camara en funcion del tamaño del sprite que asignamos como rango
        minYSec = rangoCamaraSecundario.transform.position.y - rangoCamaraSecundario.bounds.size.y / 2f; //establecemos la minima Y a la que puede moverse la camara en funcion del tamaño del sprite que asignamos como rango
        maxYSec = rangoCamaraSecundario.transform.position.y + rangoCamaraSecundario.bounds.size.y / 2f; //establecemos la maxima Y a la que puede moverse la camara en funcion del tamaño del sprite que asignamos como rango

    }

    private void Update()
    {

        if ((batalla.position.y + 0.05) >= transform.position.y && !yendoCiudad) //con este if desactivo el boolean de que esta en la ciudad cuando la camara este justo encima del campo de batalla (con un margen de 0.05) y no antes para que no se puedan mover durante la tansicion
        {
            enCiudad = false;
        }

        if (!enCiudad)
        {
            if (Input.GetMouseButtonDown(0)) //registra cuando el jugador pulsa el boton y establece el punto de origen para mas tarde calcular la cantidad de movimiento que se debe aplicar
            {
                puntoOrigen = camara.ScreenToWorldPoint(Input.mousePosition); //establece el puntoOrigen el la posicion del mundo equivalente a la posicion de la camara en la que esta l cursor en el momento de pulsar
            }
            if (Input.GetMouseButton(0)) //registra cuando el boton esta siendo pulsado de forma continua para calcular la distancia (diferencia) entre el puntoOrigen y el punto actual del raton para mover el objetivo y la camara lo que sea necesario
            {
                Vector3 diferencia = puntoOrigen - camara.ScreenToWorldPoint(Input.mousePosition); //calcula la diferencia entre el puntoOrigen y el punto actual del raton
                transform.position += diferencia * deslizamientoCamara; //mueve la camara la diferencia multiplicado por el deslizamientoCamara(<1) para que la camara se deslice un poco ya que tendra que igualarse a la posicion de camaraObjetivo, la cual la movemos la diferencia entera
                camaraObjetivo += diferencia; //movemos el objetivo de la camara la diferencia 
            }
            if (Input.mouseScrollDelta.y > 0) //registra cuando se mueve la rueda del raton hacia arriba/delante
            {
                camaraZoom -= cantidadZoom * Time.unscaledDeltaTime; //disminuimos el tamaño ortografico de la camara, es decir hacemos zoom-in
            }
            if (Input.mouseScrollDelta.y < 0) //registra cuando se mueve la rueda del raton hacia abajo/atras
            {
                camaraZoom += cantidadZoom * Time.unscaledDeltaTime; //aumentamos el tamaño ortografico de la camara, es decir hacemos zoom-out
            }
            camaraZoom = Mathf.Clamp(camaraZoom, maxZoom, minZoom);//hacemos que los valores del tamaño ortografico de la camra se mantengan entre un minimo y un maximo
        }
        SeguimientoCamara(); //funcion que realiza el seguimiento de la camara, es decir, mover la camara hacia su objetivo en funcion del tiempo y la distancia, y lo mismo con el zoom
    }

    void SeguimientoCamara()
    {
        if (!enCiudad)
        {
            camaraObjetivo = AcotarCamara(camaraObjetivo); //acotamos la posicion del objetivo de la camra en funcion del tamaño de la camara (es decir, del zoom) y del tamaño del sprite del rango
            transform.position = AcotarCamaraSecundario(transform.position); //acotamos la posicion de la camra en funcion del tamaño de la camara (es decir, del zoom) y del tamaño del sprite del rango
        }
        
        Vector2 dir = camaraObjetivo - transform.position; //calculamos el vecotor direccion entre la pos de la camara y la pos del objetivo
        transform.Translate(dir * velocidadSeguimientoCamara * Time.unscaledDeltaTime, Space.World); //trasladamos la pos de la camara hacia la del objetivo, y al no estar el vector dir normalizado este movimiento sera mas rapido cuanto mas lejos este la camara de su objetivo

        float camaraZoomDiff = camaraZoom - camara.orthographicSize; //calculamos la diferencia entre la pos de la camara y la pos del objetivo
        camara.orthographicSize += camaraZoomDiff * velocidadZoom * Time.unscaledDeltaTime; //modificamos el tamaño de la camara hacia el del objetivo, este modificacion sera mas rapidá cuanto mas lejos este la camara de su objetivo ya que esta siendo multiplicada por la diferencia   
    }

    Vector3 AcotarCamara(Vector3 objetivoPos)//acotamos la posicion del objetivo de la camra en funcion del tamaño de la camara (es decir, del zoom) y del tamaño del sprite del rango
    {
        float camAltura = camara.orthographicSize; //obtenemos la altura de la camara en tamaño de Space.World (o tamaño real del juego), esta es igual a su tamaño ortografico
        float camAnchura = camara.orthographicSize * camara.aspect; //obtenemos la anchura al multiplicarlo por su aspect ratio, nosotros usamos un 16:9, es decir camara.orthographicSize * 16 / 9, pero por si alguien tiene un aspect ratio algo distinto pues asi se ajusta de forma automatica

        float minCamX = minX + camAnchura; //establecemos la minima posicion en X a la que el objetivo de la camara se puede mover en funcion de la anchura real de la camara y de la minX que sacamos del tamaño del sprite del rango
        float maxCamX = maxX - camAnchura; //establecemos la maxima posicion en X a la que el objetivo de la camara se puede mover en funcion de la anchura real de la camara y de la maxX que sacamos del tamaño del sprite del rango
        float minCamY = minY + camAltura; //establecemos la minima posicion en Y a la que el objetivo de la camara se puede mover en funcion de la anchura real de la camara y de la minY que sacamos del tamaño del sprite del rango
        float maxCamy = maxY - camAltura; //establecemos la maxima posicion en Y a la que el objetivo de la camara se puede mover en funcion de la anchura real de la camara y de la maxY que sacamos del tamaño del sprite del rango

        float X = Mathf.Clamp(objetivoPos.x, minCamX, maxCamX); //esto es mas dificil de explicar, a ver si lo consigo: Usando objetivoPos.x, es decir, la posicion actual del objetivo en x y los valores minCamX y maxCamX que hemos calculado, usamos la funcion matemática Clamp (acotar creo que es la traduccion mas correca para este caso) para "retener" o "acotar" el valor de la x del la pos del objetivo entre esos dos valores, la funcion clamp coge un valor y un minimo y maximo y mantiene ese valor entre el minimo y el maximo y no deja que se pase: Mathf.Clamp(valor, min, max). Y esto nos devuelve un nuevo valor que llamamos X y sera la nueva x que le daremos al vector posicion del objetivo.
        float Y = Mathf.Clamp(objetivoPos.y, minCamY, maxCamy); //hacemos lo mismo de antes pero para la Y

        return new Vector3(X, Y, objetivoPos.z); //usando los valores acotados de X e Y devolvemos un nuevo vector para el vector posicion del objetivo.
    }
    Vector3 AcotarCamaraSecundario(Vector3 objetivoPos)//acotamos la posicion de la camra en funcion del tamaño de la camara (es decir, del zoom) y del tamaño del sprite del rango
    {
        float camAltura = camara.orthographicSize; //obtenemos la altura de la camara en tamaño de Space.World (o tamaño real del juego), esta es igual a su tamaño ortografico
        float camAnchura = camara.orthographicSize * camara.aspect; //obtenemos la anchura al multiplicarlo por su aspect ratio, nosotros usamos un 16:9, es decir camara.orthographicSize * 16 / 9, pero por si alguien tiene un aspect ratio algo distinto pues asi se ajusta de forma automatica

        float minCamX = minXSec + camAnchura; //establecemos la minima posicion en X a la que la camara se puede mover en funcion de la anchura real de la camara y de la minX que sacamos del tamaño del sprite del rango
        float maxCamX = maxXSec - camAnchura; //establecemos la maxima posicion en X a la que la camara se puede mover en funcion de la anchura real de la camara y de la maxX que sacamos del tamaño del sprite del rango
        float minCamY = minYSec + camAltura; //establecemos la minima posicion en Y a la que la camara se puede mover en funcion de la anchura real de la camara y de la minY que sacamos del tamaño del sprite del rango
        float maxCamy = maxYSec - camAltura; //establecemos la maxima posicion en Y a la que la camara se puede mover en funcion de la anchura real de la camara y de la maxY que sacamos del tamaño del sprite del rango

        float X = Mathf.Clamp(objetivoPos.x, minCamX, maxCamX); //lo mismo que en la funcion de AcotarCamara()
        float Y = Mathf.Clamp(objetivoPos.y, minCamY, maxCamy); //lo mismo que en la funcion de AcotarCamara()

        return new Vector3(X, Y, objetivoPos.z); //usando los valores acotados de X e Y devolvemos un nuevo vector para el vector posicion del objetivo.
    }

    public void irCiudad()//tpea el objetivo de la camara a la posicion de la ciudad
    {
        camaraObjetivo = ciudad.position;
        enCiudad = true;
        yendoCiudad = true;
        camaraZoom = 5; 
    }

    public void irBatlla() //tpea el objetivo de la camara a la posicion de la batalla
    {
        camaraObjetivo = batalla.position;
        yendoCiudad = false;
    }
}
