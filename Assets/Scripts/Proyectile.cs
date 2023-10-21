using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{

    [SerializeField]float speed = 5;
    [SerializeField]float time = 5;

    [SerializeField]int health = 3;
    public bool powershoot;
    private void Start() {
        Destroy(gameObject, time); 
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage();
            if(!powershoot)
            Destroy(gameObject);

            health--;
            if(health <= 0)
            {
            Destroy(gameObject);
            }
        }
    }
}
