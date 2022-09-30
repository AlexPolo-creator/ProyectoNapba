
using UnityEngine;

public class PanelMenuConstruccion : MonoBehaviour
{
    public ItemsDeCompra arquero;
    public ItemsDeCompra mago;

    public ItemsDeCompra torre;

    MenuConstrucion menuConstrucion;

    private void Start()
    {
        menuConstrucion = MenuConstrucion.instance;
    }

    public void ElegirArquero()
    {
        menuConstrucion.ElegirTropaAColocar(arquero);
    }

    public void ElegirMago()
    {
        menuConstrucion.ElegirTropaAColocar(mago);
    }

    public void ElegirTorre()
    {
        menuConstrucion.ElegirTorreAColocar(torre);
        Debug.Log("1");
    }

}
