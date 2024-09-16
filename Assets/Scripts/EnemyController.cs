using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 400;
    private Rigidbody enemyRb;    
    public GameObject playerTarget;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        //GameObject playerTarget = GameObject.FindGameObjectWithTag("Player");
        GameObject[] playerTargets = GameObject.FindGameObjectsWithTag("Player");
        playerTarget = playerTargets[0];
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerTarget.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {        
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    
}
