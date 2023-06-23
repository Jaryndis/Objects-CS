using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    private string _name;
    private float _damage;

    public void Shoot(Vector3 direction, float speed)
    {
        
    }

    public Weapon(string name, float damage)
    {
        _name = name;
        _damage = damage;
    }

    public Weapon()
    {
        Debug.Log("General weapon");
    }
}
