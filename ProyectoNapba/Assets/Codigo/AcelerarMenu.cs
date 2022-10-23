using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcelerarMenu : MonoBehaviour
{
    //no pienso comentar esta clase, si no lo entiendes eres subnormal
    public static float velocidad = 1f;
    void Start()
    {
        Time.timeScale = 1f;
        velocidad = Time.timeScale;
    }

    public void X1()
    {
        Time.timeScale = 1f;
        velocidad = Time.timeScale;
    }
    public void X2()
    {
        Time.timeScale = 2f;
        velocidad = Time.timeScale;
    }
    public void X3()
    {
        Time.timeScale = 3f;
        velocidad = Time.timeScale;
    }
    public void X5()
    {
        Time.timeScale = 5f;
        velocidad = Time.timeScale;
    }
}
