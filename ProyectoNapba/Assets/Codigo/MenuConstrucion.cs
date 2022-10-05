
using UnityEngine;

public class MenuConstrucion : MonoBehaviour
{
    //no entiendo porque hay que hacer esto pero hay que hacerlo
    public static MenuConstrucion instance;

    //esta funcion se ejecuta justo antes de Start
    void Awake()
    {
        //si ya hay una instancia de MenuConstruccion damos un error en la consola
        if (instance != null)
        {
            Debug.LogError("ERROR: Hay mas de un MenuConstruccion en la escena.");
        }

        //creamos una instancia de este script, de nuevo, no entiendo porque hay que hacer esto pero hay que hacerlo
        instance = this;
    }

    //lista de las torres (prefabs)
    [Header("Torres:")]
    public GameObject Torre;

    //lista de las tropas (prefabs)
    [Header("Magos:")]
    public GameObject Hechicero;
    public GameObject Verdugo;


    [Header("Soldados:")]
    public GameObject Arquero;

    //obtemos la tropa a colocar con las caracteristicas etablecidas en el PanelMenuConstruccion y gracias al script serializado de ItemsDeCompra
    private ItemsDeCompra tropaAColocar;
    private ItemsDeCompra torreAColocar;

    //creamos un boolean que checkea si ha dinero para coloar la torre que se quiere colocar (esto sirve para el script de NodoTorre)
    public bool tieneDineroParaTorre { get { return Stats.oro >= torreAColocar.precio; } }

    //creamos un boolean que checkea si se puede colocar una torre en x nodo dependiendo de si ya hay una tropa colocada (esto sirve para el script de NodoTropa)
    public bool puedeColocarTropa { get { return tropaAColocar != null; } }

    //esta funcion coloca una torre en la posicion del nodo seleccionado si tiene dinero sufiente
    public void ColocarTorreEn (NodoTorre nodo)
    {
        //checkea si hay dinero suficiente para comprar la torre y si no lo hay devolvemos la fucion sin ejecutar el resto del codigo y mandamos un mensaje al jugador de que no hay dinero
        if (Stats.oro < torreAColocar.precio)
        {
            Debug.Log("No tienes Oro suficiente.");//TODO mensaje en pantalla
            return;
        }

        //resta al stat del oro el precio de la torre seleccionada
        Stats.oro -= torreAColocar.precio;

        //instaciamos una torre en la posicion del nodo seleccionado gracias a la fucnion de ObtenerPosicionColocacionTorre del script de NodoTorre.
        GameObject torre = (GameObject)Instantiate(torreAColocar.prefab, nodo.ObtenerPosicionColocacionTorre(), Quaternion.identity);
        nodo.torre = torre;        
    }

    //esta funcion coloca una tropa en la posicion del nodo seleccionado si tiene dinero sufiente
    public void ColocarTropaEn(NodoTropa nodo)
    {
        
        //dependiendo del tipo de recurso necesario para colocar la tropa se ejecutará un codigo u otro
        if (tropaAColocar.recurso == "hechicero")
        {
            //checkea si hay dinero suficiente para comprar la torre y si no lo hay devolvemos la fucion sin ejecutar el resto del codigo y mandamos un mensaje al jugador de que no hay dinero
            if (Stats.hechiceros < 1)
            {
                Debug.Log("No tienes Hechiceros suficientes.");
                return;
            }

            //resta al stat del oro el precio de la tropa seleccionada
            Stats.hechiceros -= 1;
            Stats.numMagos++; 
        }else if (tropaAColocar.recurso == "verdugo")
        {
            //checkea si hay dinero suficiente para comprar la torre y si no lo hay devolvemos la fucion sin ejecutar el resto del codigo y mandamos un mensaje al jugador de que no hay dinero
            if (Stats.verdugos < 1)
            {
                Debug.Log("No tienes Verdugos suficiente.");
                return;
            }

            //resta al stat del oro el precio de la tropa seleccionada
            Stats.verdugos -= 1;
            Stats.numMagos++;
        }
        else if (tropaAColocar.recurso == "arquero")
        {
            //checkea si hay dinero suficiente para comprar la torre y si no lo hay devolvemos la fucion sin ejecutar el resto del codigo y mandamos un mensaje al jugador de que no hay dinero
            if (Stats.arqueros < 1)
            {
                Debug.Log("No tienes Arqueros suficiente.");
                return;
            }

            //resta al stat del oro el precio de la tropa seleccionada
            Stats.arqueros -= 1;
            Stats.numSoldados++;
        }

        //instaciamos una tropa en la posicion del nodo seleccionado gracias a la fucnion de ObtenerPosicionColocacionTropa del script de NodoTropa.
        GameObject tropa = (GameObject)Instantiate(tropaAColocar.prefab, nodo.ObtenerPosicionColocacionTropa(), Quaternion.identity);
        nodo.tropa = tropa;
    }


    public void ElegirTropaAColocar (ItemsDeCompra tropa)
    {
        tropaAColocar = tropa;
        torreAColocar = null;
    }

    public void ElegirTorreAColocar(ItemsDeCompra torre)
    {
        torreAColocar = torre;
        tropaAColocar = null;
    }

}
