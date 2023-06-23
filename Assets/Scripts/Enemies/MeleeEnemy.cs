using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private float attackRange;
    [SerializeField] private float attackTime = 0;

    private float timer = 0;
    private float setSpeed = 0;


    public void SetMeleeEnemy(float attackRange, float attackTime)
    {
        this.attackRange = attackRange;
        this.attackTime = attackTime;
    }
    protected override void Start()
    {
        base.Start();
        Health = new Health(1, 0, 1);
        setSpeed = speed;
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
            speed = 0;
            Attack(attackTime);
        }
        else
        {
            setSpeed = speed;
        }
    }

    public override void GetDamage(float damage)
    {
        Health.DeductHealth(damage);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public override void Attack(float interval)
    {
        if(timer <= interval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            Target.GetComponent<IDamageable>().GetDamage(Weapon.GetDamage());
        }
    }

}
