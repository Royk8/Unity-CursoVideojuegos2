using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject ballPrefab;
    private GameObject ballR;
    private GameObject ballL;
    public GameObject spawnPointR;
    public GameObject spawnPointL;
    public float force;
    public float rotationSpeed;    
    private Rigidbody ballRbR;
    private Rigidbody ballRbL;

    void Start()
    {
        SpawnBall();
    }

    void Update()
    {
        Rotate();
        Launch();
    }

    public void Rotate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.Rotate(new Vector3(vertical, horizontal, 0) *(rotationSpeed * Time.deltaTime));
    }

    public void Launch()
    {        
        if (Input.GetButtonDown("Jump"))
        {
            if(ballR != null)
            {
                ballR.transform.parent = null;
                ballRbR.isKinematic = false;
                ballRbR.AddForce(transform.forward * force, ForceMode.Impulse);
                ballR = null;
                ballRbR = null;                
                
                ballL.transform.parent = null;
                ballRbL.isKinematic = false;
                ballRbL.AddForce(transform.forward * force, ForceMode.Impulse);
                ballL = null;
                ballRbL = null;

                StartCoroutine(RespawnBallCoroutine());
            }
        }
    }

    [ContextMenu("SpawnBall")]
    public void SpawnBall()
    {
        ballR = Instantiate(ballPrefab, spawnPointR.transform.position, spawnPointR.transform.rotation);
        ballR.transform.parent = transform;
        ballRbR = ballR.GetComponent<Rigidbody>();
        ballL = Instantiate(ballPrefab, spawnPointL.transform.position, spawnPointL.transform.rotation);
        ballL.transform.parent = transform;
        ballRbL = ballL.GetComponent<Rigidbody>();
    }

    IEnumerator RespawnBallCoroutine()
    {
        yield return new WaitForSeconds(1);
        SpawnBall();
    }
}
