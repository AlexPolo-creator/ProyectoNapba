using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoTorre : MonoBehaviour
{
    MenuConstrucion menuConstrucion;

    public Color hoverColor;
    public Color noTieneDineroColor;

    [Header("Opcional")]
    public GameObject torre = null;

    private SpriteRenderer sprite;
    private Color colorInicial;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        colorInicial = sprite.color;

        menuConstrucion = MenuConstrucion.instance;
    }

    public Vector3 ObtenerPosicionColocacionTorre ()
    {
        return transform.position;
    }

    void OnMouseDown()
    {
        if (!menuConstrucion.puedeColocarTorre) return;

        if (torre != null)
        {
            Debug.Log("No se puede construir ahí pendejo!");
            return;
        }
        menuConstrucion.ColocarTorreEn(this);
        
        
    }



    void OnMouseEnter()
    {
        if (torre != null)
        {
            gameObject.SetActive(false);
        }
        if (!menuConstrucion.puedeColocarTorre) return;
        if (menuConstrucion.tieneDineroParaTorre)
        {
            sprite.color = hoverColor;
        }else
        {
            sprite.color = noTieneDineroColor;
        }
        
    }
    void OnMouseExit()
    {
        sprite.color = colorInicial;
    }

}
