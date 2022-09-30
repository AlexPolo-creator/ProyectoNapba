
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

   

    private GameObject tropaAColocar;
    private GameObject torreAColocar;

    public GameObject ObtenerTropaAColocar ()
    {
        return tropaAColocar;
    }

    public void ElegirTropaAColocar (GameObject torre)
    {
        tropaAColocar = torre;
    }

    public GameObject ObtenerTorreAColocar()
    {
        return torreAColocar;
    }

    public void ElegirTorreAColocar(GameObject torre)
    {
        torreAColocar = torre;
        Debug.Log("2");
    }

}
