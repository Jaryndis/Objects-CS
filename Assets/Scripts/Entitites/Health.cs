using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private float _currentHealth;
    private float _maxHealth;
    private float _healthRegenerated;

    public Action<float> OnHealthUpdate;
    
    public Health(float maxHealth)
    {
        _maxHealth = maxHealth;
    }


    public float GetHealth()
    {
        return _currentHealth;
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
        _currentHealth = Mathf.Min(_maxHealth, _currentHealth + value);
        OnHealthUpdate?.Invoke(_currentHealth);
    }

    public void DeductHealth(float value)
    {
        _currentHealth -= Mathf.Min(0, _currentHealth - value);
        OnHealthUpdate?.Invoke(_currentHealth);
    }


    
    public void SetHealth(float value)
    {
        if(value > _maxHealth || value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Valid range for health is between 0 and {_maxHealth}");
        }
        _currentHealth = value;
    }
}
