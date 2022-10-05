using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcelerarMenu : MonoBehaviour
{   
    void Start()
    {
        Time.timeScale = 1f; 
    }

    public void X1()
    {
        Time.timeScale = 1f;
    }
    public void X2()
    {
        Time.timeScale = 2f;
    }
    public void X3()
    {
        Time.timeScale = 3f;
    }
    public void X5()
    {
        Time.timeScale = 5f;
    }
}
