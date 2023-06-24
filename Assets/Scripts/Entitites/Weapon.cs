using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    private string _name;
    private float _damage;
    private float _bulletSpeed;


    public Weapon(string name, float damage, float bulletSpeed)
    {
        _name = name;
        _damage = damage;
        _bulletSpeed = bulletSpeed;
    }
    
    public void Shoot(Bullets bullet, PlayableObjects player, string targetTag, float timeToDie = 5)
    {
        // var transform = player.transform;
        Bullets tempBullet = GameObject.Instantiate(bullet, player.transform.position, player.transform.rotation);
        tempBullet.SetBullet(_damage, targetTag, _bulletSpeed);
        
        GameObject.Destroy(tempBullet.gameObject, timeToDie);
    }

    public float GetDamage()
    {
        return _damage;
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
