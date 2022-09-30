
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

    public bool puedeColocarTorre { get { return torreAColocar != null;  } }
    public bool puedeColocarTropa { get { return tropaAColocar != null; } }

    public void ColocarTorreEn (NodoTorre nodo)
    {
        GameObject torre = (GameObject)Instantiate(torreAColocar.prefab, nodo.ObtenerPosicionColocacionTorre(), Quaternion.identity);
        nodo.torre = torre;
    }

    public void ColocarTropaEn(NodoTropa nodo)
    {
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
