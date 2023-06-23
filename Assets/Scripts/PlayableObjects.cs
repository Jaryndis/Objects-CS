using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayableObjects : MonoBehaviour, IDamageable
{

    public Health health = new Health();
    public Weapon weapon;
    
    /// <summary>
    /// Move the object/character in a <c>direction</c> towards a <c>target</c>.
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="target"></param>
    public abstract void Move(Vector2 direction, Vector2 target);

    public virtual void Move(Vector2 direction)
    {
        
    }

    public virtual void Move(float speed)
    {
        
    }

    public abstract void Shoot();

    public abstract void Attack(float interval);

    public abstract void Die();

    public abstract void GetDamage(float damage);
}
