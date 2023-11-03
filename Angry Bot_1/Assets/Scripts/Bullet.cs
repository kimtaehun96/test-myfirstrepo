using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30.0f;
    public float power = 21.0f;
    public float life = 2.0f;

    void Update()
    {
        life -= Time.deltaTime;
        if(life <= 0.0f)
        {
            Destroy(gameObject);
        }
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        if(collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if(enemy.enemyState != EnemyState.Idle)
            {
                enemy.Hurt(power);
            }
        }
    }
}
