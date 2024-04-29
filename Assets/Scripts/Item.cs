using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite; // Изображение предмета
    public enum ItemType { HealthPotion, Food, SacrificePotion }
    public ItemType itemType;
    public int healthEffect; // Может быть положительным или отрицательным в зависимости от предмета

    public void Use(PlayerHealth playerHealth)
    {
        Debug.Log($"Item used: {itemName}, Health effect: {healthEffect}");

        // Обработка логики использования предмета
        switch (itemType)
        {
            case ItemType.HealthPotion:
            case ItemType.Food:
                Debug.Log("Healing with: " + healthEffect);
                playerHealth.Heal(healthEffect);
                break;
            case ItemType.SacrificePotion:
                Debug.Log("Sacrificing health: " + healthEffect);
                playerHealth.TakeDamage(-healthEffect); // Наносит урон
                // Увеличение урона в 2 раза должно быть реализовано в PlayerHealth
                break;
        }
    }
}


