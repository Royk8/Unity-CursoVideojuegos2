using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public int x = 5;
    public float y = 3.33f;
    public string s = "Hola mundo";
    public bool b = false;
    private int m = 6;

    public void Start()
    {
        Debug.Log(s);
        Debug.Log(y);

        if (b == false) {
            ImprimeVerdadero();
            ImprimeVerdadero();
        }
        Debug.Log("Despues del metodo");
    }


    void ImprimeVerdadero()
    {
        Debug.Log("La condicion es verdadera");
    }
}
