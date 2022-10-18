
using UnityEngine;

public class PanelMenuConstruccion : MonoBehaviour
{
    public ItemsDeCompra hechicero;
    public ItemsDeCompra verdugo;

    public ItemsDeCompra arquero;

    public ItemsDeCompra torre;

    MenuConstrucion menuConstrucion;

    private void Start()
    {
        menuConstrucion = MenuConstrucion.instance;
    }

    public void ElegirHechicero()
    {
        menuConstrucion.ElegirTropaAColocar(hechicero);
    }

    public void ElegirVerdugo()
    {
        menuConstrucion.ElegirTropaAColocar(verdugo);
    }



    public void ElegirArquero()
    {
        menuConstrucion.ElegirTropaAColocar(arquero);
    }


    public void ElegirTorre()
    {
        menuConstrucion.ElegirTorreAColocar(torre);
    }

}
