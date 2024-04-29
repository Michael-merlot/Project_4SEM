using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damagePerTick = 10; // Урон за каждый "тик" стояния в ловушке
    public float damageTickRate = 2f; // Частота нанесения урона (в секундах)
    private float lastDamageTime;

    private void OnTriggerStay2D(Collider2D other)
    {
        // Проверяем, является ли объект игроком
        if (other.CompareTag("Player") && Time.time >= lastDamageTime + damageTickRate)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damagePerTick);
                lastDamageTime = Time.time; // Обновляем время последнего урона
            }
        }
    }
}

