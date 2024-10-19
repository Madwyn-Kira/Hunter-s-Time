using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour, IHealth
{
    [SerializeField] private HPBar healthBar;
    [SerializeField] private float maxHealth = 100f;

    public float CurrentHealth { get; private set; }
    public float MaxHealth { get { return maxHealth; } }

    public event Action<float> OnHealthChanged;
    public event Action OnDeath;

    public void Initialize(Slider hpBar, float _maxHealth)
    {
        maxHealth = _maxHealth;

        if (healthBar.HpBarSlider == null)
            healthBar.HpBarSlider = hpBar;

        healthBar.InitializeHPBar(maxHealth);
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        healthBar.ChangeHPBarValue(-damage);
        OnHealthChanged?.Invoke(CurrentHealth);

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0f, maxHealth);
        OnHealthChanged?.Invoke(CurrentHealth);
        healthBar?.ChangeHPBarValue(amount);
    }

    private void Die()
    {
        OnDeath?.Invoke();
    }
}
