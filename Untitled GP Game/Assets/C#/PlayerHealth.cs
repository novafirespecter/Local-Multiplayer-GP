using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    // Reference to the slider UI element
    public Slider healthSlider;

    // Name of the death scene
    public string deathSceneName;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        // Check if health has reached zero or below
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Load the death scene
        SceneManager.LoadScene(deathSceneName);
    }

    void UpdateHealthUI()
    {
        // Update the slider value to reflect current health
        if (healthSlider != null)
        {
            // Ensure currentHealth is within the range [0, maxHealth]
            float normalizedHealth = Mathf.Clamp01(currentHealth / maxHealth);
            healthSlider.value = normalizedHealth;
        }
    }
}

