using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : Enemy
{
    [SerializeField] private float attackRange;
    [SerializeField] private float attackTime;

    private float timer = 0;
    
    protected override void Start()
    {
        base.Start();
        health = new Health(1, 0, 1);
    }

    protected override void Update()
    {
        base.Update();

        if (Target == null)
        {
            return;
        }

        if (Vector2.Distance(transform.position, Target.position) < attackRange)
        {
            Attack(attackTime);
        }
    }

    public override void GetDamage(float damage)
    {
        health.DeductHealth(damage);
    }

    public override void Attack(float interval)
    {
        if (timer <= interval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            Target.GetComponent<IDamageable>().GetDamage(0);
        }
    }
}
