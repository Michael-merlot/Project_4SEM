using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel; // Панель инвентаря
    public List<Item> inventoryItems = new List<Item>(); // Список предметов в инвентаре

    void Update()
    {
        // Проверка нажатия клавиши 'I'
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    // Функция для переключения видимости панели инвентаря
    public void ToggleInventory()   
    {
        bool isActive = inventoryPanel.activeSelf;
        inventoryPanel.SetActive(!isActive);

        if (isActive)
        {
            // TODO: обновить UI инвентаря, когда инвентарь будет закрыт
        }
        else
        {
            UpdateInventoryUI();
        }
    }

    // Функция для добавления предмета в инвентарь
    public void AddItem(Item item)
    {

    }

    // Функция для обновления UI инвентаря
    private void UpdateInventoryUI()
    {
        // TODO: Реализуйте обновление UI инвентаря
        // Пример:
        // Итерация по всем слотам инвентаря и установка спрайтов предметов в них
        // Если у вас есть скрипт для управления слотами инвентаря, вызовите его здесь
    }

            
}

