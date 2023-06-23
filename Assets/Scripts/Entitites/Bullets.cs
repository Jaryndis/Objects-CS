using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float speed;

    private string targetTag;



    public void SetBullet(float _damage, string _targetTag, float _speed = 10)
    {
        this.damage = _damage;
        this.targetTag = _targetTag;
        this.speed = _speed;
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        
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
            GameManager.GetInstance().scoreManager.IncrementScore();
            Destroy(gameObject);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            

            if (!collision.gameObject.CompareTag(targetTag))
            {
                return;
            }
            IDamageable component = collision.GetComponent<IDamageable>();
            Damage(component);
            Debug.Log("Other object's name =" + collision.gameObject.name);
        }
    }
}
