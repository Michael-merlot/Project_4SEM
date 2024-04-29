using UnityEngine;
using UnityEngine.UI;

public class QuickInventory : MonoBehaviour
{
    public Image[] slotImages;
    public Item[] itemsInSlots;
    public InventorySlot[] slots; // Ваши слоты инвентаря

    [System.Serializable]
    public class InventorySlot
    {
        public Image background; // Фон слота, всегда отображается
        public Image itemIcon; // Иконка предмета, отображается когда в слоте есть предмет
        public Item item; // Текущий предмет в слоте
    }

    void Start()
    {
        // Инициализация массива itemsInSlots с тем же размером, что и slotImages
        itemsInSlots = new Item[slotImages.Length];
        for (int i = 0; i < itemsInSlots.Length; i++)
        {
            itemsInSlots[i] = null; // Изначально все слоты пусты
        }
    }

    public void AddItemToSlot(Sprite itemSprite, int slotIndex)
    {
        Debug.Log("Adding item to slot: " + slotIndex);

        if (slotIndex < 0 || slotIndex >= slotImages.Length)
        {
            Debug.LogError("Slot index out of range.");
            return;
        }

        slotImages[slotIndex].sprite = itemSprite;
        slotImages[slotIndex].enabled = true; 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItem(0); 
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseItem(1); 
        }
    }
    public void UseItem(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= slotImages.Length)
        {
            Debug.LogError("Slot index out of range.");
            return;
        }

        if (itemsInSlots[slotIndex] != null)
        {
            Debug.Log("Item found in slot: " + slotIndex);
            PlayerHealth playerHealth = this.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                Debug.Log("PlayerHealth component found: " + playerHealth.currentHealth);
                itemsInSlots[slotIndex].Use(playerHealth);
            }
            else
            {
                Debug.LogError("PlayerHealth component not found on the player.");
            }
            ClearSlot(slotIndex);
        }
        else
        {
            Debug.Log("No item in slot: " + slotIndex);
        }
    }

    public void AddItemToInventory(Item itemToAdd, int slotIndex)
    {
        // Проверяем, свободен ли слот
        if (itemsInSlots[slotIndex] == null)
        {
            // Добавляем предмет в инвентарь
            itemsInSlots[slotIndex] = itemToAdd;
            // Обновляем UI слота инвентаря
            slotImages[slotIndex].sprite = itemToAdd.itemSprite;
            slotImages[slotIndex].enabled = true;
        }
        else
        {
            Debug.Log("Slot " + slotIndex + " is already occupied.");
        }
    }


    public void ClearSlot(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= slotImages.Length)
        {
            Debug.LogError("Slot index out of range.");
            return;
        }

        // Очищаем слот
        slotImages[slotIndex].sprite = null;
        //slotImages[slotIndex].enabled = false; // Выключаем изображение, чтобы оно не отображалось
    }
}

