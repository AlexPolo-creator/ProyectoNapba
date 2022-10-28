using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpMovement : MonoBehaviour
{
    public float velocidad = 0.25f;
    public float tiempoDesaparicion = 1.5f;
    public float velocidadDesaparicion = 1f;
    float velocidadFrenado = 0.005f;

    private TextMeshPro texto;
    private Color colorTexto;

    public SpriteRenderer sprite;
    private Color colorSprite;

    private void Start()
    {
        velocidad *= 5f;
        texto = GetComponent<TextMeshPro>();
        colorTexto = texto.color;

        colorSprite = sprite.color;
    }

    void Update()
    {
        velocidad -= velocidad * velocidadFrenado;
        transform.Translate(new Vector3(0f, 1f, 0f) * velocidad * Time.deltaTime, Space.World);
        tiempoDesaparicion -= Time.deltaTime;
        if (tiempoDesaparicion <= 0f)
        {
            Desaparicion();
        }
    }

    void Desaparicion()
    {
        velocidad -= velocidad * velocidadFrenado;

        colorTexto.a -= velocidadDesaparicion * Time.deltaTime;
        colorSprite.a -= velocidadDesaparicion * Time.deltaTime;
        texto.color = colorTexto;
        sprite.color = colorSprite;
        if (colorTexto.a <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
