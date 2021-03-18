using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider lifeSlider;
    public Gradient gradient;
    public Image filler;
    
    public void SetMaxHealth(int maxHealth)
    {
        lifeSlider.maxValue = maxHealth;
        lifeSlider.value    = maxHealth;

        filler.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        lifeSlider.value = health;

        filler.color = gradient.Evaluate(lifeSlider.normalizedValue);
    }
}
