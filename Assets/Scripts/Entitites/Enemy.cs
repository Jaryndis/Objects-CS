using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System;

public class Enemy : PlayableObjects
{
    [SerializeField] protected float speed;
    protected Transform Target;

    protected virtual void Start()
    {
        try
        {
            Target = GameObject.FindWithTag("Player").transform;
        }
        catch (NullReferenceException e)
        {
            Debug.Log("There is no player in scene, Self-destruction executing");
            Destroy(gameObject);
        }
    }

    protected virtual void Update()
    {
        if (Target != null)
        {
            Move(Target.position);
        }
        else
        {
            Move(speed);
        }
    }
    private EnemyType _enemyType;
    
    private TestEnum _testEnum;

    enum TestEnum
    {
        Option1,
        Option2,
        Option3
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        Debug.Log("Enemy moving towards direction");
    }


    public override void Move(float speed)
    {
        transform.Translate(Vector2.right * (speed * Time.deltaTime));
    }
    public override void Move(Vector2 direction)
    {
        // var position = transform.position;
        direction.x -= transform.position.x;
        direction.y -= transform.position.y;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0,angle);

        transform.Translate(Vector2.right * (speed * Time.deltaTime));
    }

    public override void Shoot()
    {
        Debug.Log("Shooting bullet towards direction");
    }

    public override void Die()
    {
        Debug.Log("Enemy died");
        GameManager.GetInstance().NotifyDeath(this);
        Destroy(gameObject);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public override void GetDamage(float damage)
    {
        Debug.Log("Enemy damaged!");
        Health.DeductHealth(damage);
        if(Health.GetHealth() <= 0)
        {
            Die();
        }
    }

    public override void Attack(float interval)
    {
        Debug.Log("Enemy attacking...");
    }

    public void SetEnemyType(EnemyType enemyType)
    {
        this._enemyType = enemyType;
    }
}