using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite; // ����������� ��������
    public enum ItemType { HealthPotion, Food, SacrificePotion }
    public ItemType itemType;
    public int healthEffect; // ����� ���� ������������� ��� ������������� � ����������� �� ��������

    public void Use(PlayerHealth playerHealth)
    {
        Debug.Log($"Item used: {itemName}, Health effect: {healthEffect}");

        // ��������� ������ ������������� ��������
        switch (itemType)
        {
            case ItemType.HealthPotion:
            case ItemType.Food:
                Debug.Log("Healing with: " + healthEffect);
                playerHealth.Heal(healthEffect);
                break;
            case ItemType.SacrificePotion:
                Debug.Log("Sacrificing health: " + healthEffect);
                playerHealth.TakeDamage(-healthEffect); // ������� ����
                // ���������� ����� � 2 ���� ������ ���� ����������� � PlayerHealth
                break;
        }
    }
}


