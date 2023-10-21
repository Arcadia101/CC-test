using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float h;
    float v;

    Vector3 moveDirection;

    public float speed = 3; //[SerializeField] permite editarlo desde unity.
    [SerializeField] int health = 1;
    [SerializeField] Transform aim;
    [SerializeField] Camera camera;

    Vector2 facingDirection;

    [SerializeField] Transform proyectilePrefab;

    [SerializeField]float skillSpeed = 1;

    [SerializeField] bool powerShootEnabled;
    [SerializeField] bool invulnerable;
    [SerializeField] int invulnerableTime = 3;


    bool skill = true;


    void Update()
    {
        h= Input.GetAxis("Horizontal");
        v= Input.GetAxis("Vertical");
        moveDirection.x = h;
        moveDirection.y = v;

        transform.position += moveDirection * Time.deltaTime * speed;

        //AIM Controls

        facingDirection = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aim.position = transform.position + (Vector3)facingDirection; //(Vector3)facingDirection arregla incompatibilidad por ser Vector2.

        
     

        if (Input.GetMouseButton(0) && skill)
        {

            skill = false;

            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Transform bulletClone = Instantiate(proyectilePrefab, transform.position, targetRotation);
            if(powerShootEnabled)
            {
                bulletClone.GetComponent<Proyectile>().powershoot = true;
            }
            StartCoroutine(Cooldown());
        }

        IEnumerator Cooldown() 
        {

            yield return new WaitForSeconds(1/skillSpeed);
            skill = true;
            
        }
            
        

    }

    public void TakeDamage() 
    {
        if(invulnerable)
            return;


        health --;
        invulnerable = true;
        StartCoroutine(MakeVulnerableAgain());
        if(health <= 0)
        {
            //gameover
        }
    }

    IEnumerator MakeVulnerableAgain()
    {
        yield return new WaitForSeconds(invulnerableTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.CompareTag("PowerUp"))
      {
        switch (collision.GetComponent<PowerUp>().powerUpType)
        {
            case PowerUp.PowerUpType.FireRateIncrease:
                    skillSpeed++;
                    break;
            case PowerUp.PowerUpType.PowerShoot:
                    powerShootEnabled = true;
                    break;
            case PowerUp.PowerUpType.Invulnerable:
                    //inmortal.
                    break;
        }
      } 
    }
    
}
