using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootRay : MonoBehaviour
{
    public float distance;
    public bool impact;
    public LayerMask mask;
    private Camera camera;
    public GameObject selected;
    public GameObject enemy;
    private bool following;
    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            Shoot();


        if (following)
        {
            //SetDestiantion(enemy.transform.position)
        }
    }

    private void Shoot()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, float.MaxValue, mask))
        {
            if (hit.collider.CompareTag("Selectable"))
            {
                selected = hit.collider.gameObject;
            }

            if (hit.collider.CompareTag("Floor"))
            {
                if (selected != null)
                {
                    selected.GetComponent<NavMeshAgent>().SetDestination(
                        new Vector3(hit.point.x, selected.transform.position.y, hit.point.z));
                }
            }
        }
    }
}
