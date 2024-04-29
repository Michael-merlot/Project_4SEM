using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public PlayerHealth playerHealth;

    void Update()
    {
        // Вы можете адаптировать этот код, чтобы он соответствовал тому, как вы управляете здоровьем игрока.
        // Здесь предполагается, что playerHealth.maxHealth - это максимальное здоровье, а playerHealth.currentHealth - текущее здоровье.
        float healthPercent = (float)playerHealth.currentHealth / playerHealth.maxHealth;
        healthBarImage.fillAmount = healthPercent;

        if (playerHealth.currentHealth <= 0)
        {
            // Действие при смерти, например, отображение сообщения о смерти.
            // Убедитесь, что у вас есть механизм, который может вызвать смерть игрока и остановить игру или перезапустить уровень.
        }
    }
}

