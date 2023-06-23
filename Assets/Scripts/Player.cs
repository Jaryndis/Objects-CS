using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayableObjects
{

    [SerializeField] private float speed;
    [SerializeField] private Camera cam;

    private Rigidbody2D _playerRb;
    private void Start()
    {
        health = new Health(100, 0.5f, 100);
        _playerRb = GetComponent<Rigidbody2D>();
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        _playerRb.velocity = direction * (speed * Time.deltaTime);

        var playerScreenPos = cam.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPos.x;
        target.y -= playerScreenPos.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

   public override void Shoot()
    {
        Debug.Log("Shooting bullets toward direction");
    }

    public override void Die()
    {
        Debug.Log("Player died");
    }

    public override void GetDamage(float damage)
    {
        
    }

    public override void Attack(float interval)
    {
        Debug.Log("Enemy attacking");
    }
}
