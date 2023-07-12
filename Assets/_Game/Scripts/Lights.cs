using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public bool IsOn;
    public List<GameObject> bombillas;

    private IEnumerator cambioDeLuces;

    private void Start()
    {
        cambioDeLuces = CambioDeLucesCoroutine();
        StartCoroutine(cambioDeLuces);
    }

    private void MetodoCualquiera()
    {
        StopCoroutine(cambioDeLuces);
        StopAllCoroutines();
    }

    void Update()
    {
        /*foreach(GameObject bombilla in bombillas)
        {
            if (IsOn)
            {
                bombilla.GetComponent<Renderer>().material.color = Color.yellow;
            }
            else
            {
                bombilla.GetComponent<Renderer>().material.color = Color.gray;
            }
        }*/
    }

    IEnumerator CambioDeLucesCoroutine()
    {
        int i = 0;
        while (IsOn)
        {
            bombillas[i].GetComponent<Renderer>().material.color = Color.red;
            if(i != 0)
            {
                bombillas[i - 1].GetComponent<Renderer>().material.color = Color.yellow;
            }
            else
            {
                bombillas[bombillas.Count - 1].GetComponent<Renderer>().material.color = Color.yellow;
            }

            i++;
            if (i >= bombillas.Count)
                i = 0;
            yield return new WaitForSeconds(1);
        }
    }
}
