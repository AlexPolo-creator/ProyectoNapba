using TMPro;
using UnityEngine;

public class PanelMenuConstruccion : MonoBehaviour
{
    public TextMeshProUGUI contadorPrecio;
    public static int precioTorre;

    private void Start()
    {
        menuConstrucion = MenuConstrucion.instance;
        precioTorre = 2000;
    }
    private void Update()
    {
        contadorPrecio.text = precioTorre.ToString();
    }

    public ItemsDeCompra hechicero;
    public ItemsDeCompra verdugo;
    public ItemsDeCompra druida;
    public ItemsDeCompra inquisidor;

    public ItemsDeCompra arquero;
    public ItemsDeCompra lanzadorHacha;
    public ItemsDeCompra lancero;

    public ItemsDeCompra torre;

    MenuConstrucion menuConstrucion;

    public void ElegirHechicero()
    {
        menuConstrucion.ElegirTropaAColocar(hechicero);
    }

    public void ElegirVerdugo()
    {
        menuConstrucion.ElegirTropaAColocar(verdugo);
    }

    public void ElegirDruida()
    {
        menuConstrucion.ElegirTropaAColocar(druida);
    }
    public void ElegirInquisisor()
    {
        menuConstrucion.ElegirTropaAColocar(inquisidor);
    }


    public void ElegirArquero()
    {
        menuConstrucion.ElegirTropaAColocar(arquero);
    }
    public void ElegirlanzadorHacha()
    {
        menuConstrucion.ElegirTropaAColocar(lanzadorHacha);
    }
    public void ElegirLancero()
    {
        menuConstrucion.ElegirTropaAColocar(lancero);
    }


    public void ElegirTorre()
    {
        menuConstrucion.ElegirTorreAColocar(torre);
    }

}
