using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float speed;


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        throw new NotImplementedException();
    }

    void Move(Transform target)
    {
        transform.Translate(Vector2.right * (speed * Time.deltaTime) );
    }

    void Damage(IDamageable damageable)
    {
        if (damageable != null)
        {
            damageable.GetDamage(damage);
            Debug.Log("Damaged something");
            LevelLoader.Score++;
            Destroy(gameObject);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Other object's name =" + collision.gameObject.name);

            IDamageable damageable = collision.GetComponent<IDamageable>();
            Damage(damageable);
        }
    }
}
