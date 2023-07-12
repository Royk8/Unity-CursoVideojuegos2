using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public List<GameObject> targetParts;
    public int targetScore;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            foreach (GameObject part in targetParts)
            {
                MeshCollider mc = part.GetComponent<MeshCollider>();
                mc.enabled = true;
                Rigidbody rb = part.GetComponent<Rigidbody>();
                rb.isKinematic = false;

                Vector3 randomForce = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(0, 10));
                rb.AddForce(randomForce, ForceMode.Impulse);
            }

            ScoreSingleton.Instance.AddScore(targetScore);


            Debug.Log("Hola gola");
        }
    }
}
