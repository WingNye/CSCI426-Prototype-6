using System.Collections;

using System.Collections.Generic;

using UnityEngine;
public class Bullet : MonoBehaviour 
{
    public HealthManager healthManager;
    public int damage = 10;
    public float speed = 20;

    void Update() 
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(gameObject);
        if(collision.gameObject.tag == "Player1")
        {
            healthManager.playerOneTakeDamage(damage);
        }
        else if(collision.gameObject.tag == "Player2")
        {
            healthManager.playerTwoTakeDamage(damage);
        }
    }
}