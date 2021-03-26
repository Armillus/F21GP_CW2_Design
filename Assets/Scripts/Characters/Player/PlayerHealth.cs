using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 100;

    private int _currentHealth;

    void Start()
    {
        _currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public bool IsOver()
    {
        return _currentHealth <= 0;
    }

    public bool IsFullLife()
    {
        return _currentHealth == maxHealth;
    }

    public void TakeDamage(int damage)
    {
        healthBar.SetHealth(_currentHealth -= damage);
    }

    public void Heal(float percents)
    {
        if (_currentHealth == maxHealth)
            return;

        if (_currentHealth < 0)
            _currentHealth = 0;
        int extraLife = (int)((maxHealth / 100f) * percents);
        _currentHealth = Mathf.Min(_currentHealth + extraLife, maxHealth);
        healthBar.SetHealth(_currentHealth);
    }
    public void Hurt(float percents)
    {
        if (_currentHealth <= 0)
            return;

        int minusLife = (int)((maxHealth / 100f) * percents);

        _currentHealth = Mathf.Max(_currentHealth - minusLife, 0);
        healthBar.SetHealth(_currentHealth);
    }
}