
using UnityEngine;

public class PanelMenuConstruccion : MonoBehaviour
{

    MenuConstrucion menuConstrucion;

    private void Start()
    {
        menuConstrucion = MenuConstrucion.instance;
    }

    public void ElegirArquero()
    {
        menuConstrucion.ElegirTropaAColocar(menuConstrucion.Arquero);
    }

    public void ElegirMago()
    {
        menuConstrucion.ElegirTropaAColocar(menuConstrucion.Mago);
    }

    public void ElegirTorre()
    {
        menuConstrucion.ElegirTorreAColocar(menuConstrucion.Torre);
        Debug.Log("1");
    }

}
