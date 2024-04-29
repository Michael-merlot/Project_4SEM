using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item itemDetails; // Ссылка на детали предмета

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("Player"))
        {
            InventoryManager inventory = other.gameObject.GetComponent<InventoryManager>();
            if (inventory != null)
            {
                inventory.AddItem(itemDetails); // Добавить предмет в инвентарь
                gameObject.SetActive(false); // Отключить предмет на сцене или уничтожить его
            }
        }
    }
}


