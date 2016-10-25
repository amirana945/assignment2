using UnityEngine;
using System.Collections;

public class Chkpoint : MonoBehaviour
{
    // PRIVATE  VARIABLES
    private Transform _transform;
    public GameObject SpawnPoint;



    void Start()
    {
        this._transform = GetComponent<Transform>();
        this.SpawnPoint = GameObject.FindWithTag("SpawnPoint");
    }
     void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.SpawnPoint.transform.position = this._transform.position;
        }
    }
}