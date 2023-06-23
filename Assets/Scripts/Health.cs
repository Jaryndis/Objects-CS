using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private float _currentHealth;
    private float _maxHealth;
    private float _healthRegenerated;

    public Health(float maxHealth)
    {
        _maxHealth = maxHealth;
    }

    public Health()
    {
        
    }

    public Health(float maxHealth, float healthRegenerated, float currentHealth = 100)
    {
        _healthRegenerated = healthRegenerated;
        _maxHealth = maxHealth;
        _currentHealth = currentHealth;
    }

    public void RegenHealth()
    {
        AddHealth(_healthRegenerated * Time.deltaTime);
    }
    public void AddHealth(float value)
    {
        _currentHealth += Mathf.Max(_currentHealth, _currentHealth + value);
    }

    public void DeductHealth(float value)
    {
        _currentHealth -= Mathf.Min(0, _currentHealth - value);
    }
}
