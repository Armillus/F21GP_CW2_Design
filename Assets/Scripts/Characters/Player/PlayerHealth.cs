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

    public void TakeDamage(int damage)
    {
        healthBar.SetHealth(_currentHealth -= damage);
    }

    public void Heal(float percents)
    {
        _currentHealth += (int)(((float) maxHealth / 100f) * percents);
        healthBar.SetHealth(_currentHealth);
    }
}
