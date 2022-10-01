
using UnityEngine;

public class MenuConstrucion : MonoBehaviour
{
    
    public static MenuConstrucion instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("ERROR: Hay mas de un MenuConstruccion en la escena.");
        }

        instance = this;
    }

    [Header("Torres:")]

    public GameObject Torre;

    [Header("Tropas:")]

    public GameObject Arquero;
    public GameObject Mago;

   

    private ItemsDeCompra tropaAColocar;
    private ItemsDeCompra torreAColocar;

    public bool tieneDineroParaTorre { get { return Stats.oro >= torreAColocar.precio; } }
    public bool puedeColocarTorre { get { return torreAColocar != null;  } }
    public bool puedeColocarTropa { get { return tropaAColocar != null; } }

    public void ColocarTorreEn (NodoTorre nodo)
    {
        if (Stats.oro < torreAColocar.precio)
        {
            Debug.Log("No tienes Oro suficiente.");
            return;
        }

        Stats.oro -= torreAColocar.precio;

        GameObject torre = (GameObject)Instantiate(torreAColocar.prefab, nodo.ObtenerPosicionColocacionTorre(), Quaternion.identity);
        nodo.torre = torre;

 
        
    }

    public void ColocarTropaEn(NodoTropa nodo)
    {
        
        if (tropaAColocar.recurso == "oro")
        {            
            if (Stats.oro < tropaAColocar.precio)
            {
                Debug.Log("No tienes Oro suficiente.");
                return;
            }
            Stats.oro -= tropaAColocar.precio;
        }else if (tropaAColocar.recurso == "favor")
        {            
            if (Stats.favorDeDioses < tropaAColocar.precio)
            {
                Debug.Log("No tienes Favor suficiente.");
                return;
            }
            Stats.favorDeDioses -= tropaAColocar.precio;
        }       
        
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
