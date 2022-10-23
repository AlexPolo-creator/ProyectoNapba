using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoTropa : MonoBehaviour
{
    MenuConstrucion menuConstrucion;

    public Color hoverColor;

    [Header("Opcional")]
    public GameObject tropa = null;

    private SpriteRenderer sprite;
    private Color colorInicial;

    private void Start()
    {       
        sprite = GetComponent<SpriteRenderer>();
        colorInicial = sprite.color;

        menuConstrucion = MenuConstrucion.instance;
    }

    public Vector3 ObtenerPosicionColocacionTropa()
    {
        return transform.position;
    }

    void OnMouseDown()
    {
        if (!menuConstrucion.puedeColocarTropa) return;

        if (tropa != null)
        {
            return;
        }

        menuConstrucion.ColocarTropaEn(this);

        
    }

    void OnMouseEnter()
    {
        if (!menuConstrucion.puedeColocarTropa) return;

        sprite.color = hoverColor;
    }
    void OnMouseExit()
    {
        if (tropa != null)
        {
            //desactiva el objeto
            gameObject.SetActive(false);
        }
        sprite.color = colorInicial;
    }

}        
    
