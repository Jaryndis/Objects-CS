using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup, IDamageable
{
    [SerializeField] private float healthMin;
    [SerializeField] private float healthMax;
    

    // ReSharper disable Unity.PerformanceAnalysis
    public void GetDamage(float damage)
    {
        OnPicked();
    }
    
    public override void OnPicked()
    {
        base.OnPicked();

        float health = Random.Range(healthMin, healthMax);

        var player = GameManager.GetInstance().GetPlayer();
        player.Health.AddHealth(health);
        
        Debug.Log($"Added {health} health to the player");
    }
}
