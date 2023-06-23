using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : PlayableObjects
{

    [SerializeField] private float speed;
    [SerializeField] private Camera cam;

    private Rigidbody2D _playerRb;
    [SerializeField] private float weaponDamage;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private Bullets bulletPrefab;

    public Action<float> OnHealthUpdate;
    private void Awake()
    {
        Health = new Health(100, 0.5f, 100);
        _playerRb = GetComponent<Rigidbody2D>();

        Weapon = new Weapon("Player Weapon", weaponDamage, bulletSpeed);
        
        OnHealthUpdate?.Invoke(Health.GetHealth());
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
        Weapon.Shoot(bulletPrefab, this, "Enemy");
    }

    public override void Die()
    {
        Debug.Log("Player died");
        Destroy(gameObject);
    }

    public override void GetDamage(float damage)
    {
        Debug.Log("Player Damaged");
        Health.DeductHealth(damage);
        
        OnHealthUpdate?.Invoke((Health.GetHealth()));

        if (Health.GetHealth() <= 0)
        {
            Die();
        }
    }

    public override void Attack(float interval)
    {
        Debug.Log("Enemy attacking");
    }
}
