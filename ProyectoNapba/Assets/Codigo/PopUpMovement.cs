using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpMovement : MonoBehaviour
{
    public float velocidad = 0.25f;
    public float tiempoDesaparicion = 1.5f;
    public float velocidadDesaparicion = 1f;

    private TextMeshPro texto;
    private Color colorTexto;

    private void Start()
    {
        texto = GetComponent<TextMeshPro>();
        colorTexto = texto.color;
    }

    void Update()
    {
        transform.Translate(new Vector3(0f, 1f, 0f) * velocidad * Time.deltaTime, Space.World);
        tiempoDesaparicion -= Time.deltaTime;
        if (tiempoDesaparicion <= 0f)
        {
            Desaparicion();
        }
    }

    void Desaparicion()
    {
        colorTexto.a -= velocidadDesaparicion * Time.deltaTime;
        texto.color = colorTexto;
        if (colorTexto.a <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
