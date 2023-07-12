using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThing : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.right);
    }
}
