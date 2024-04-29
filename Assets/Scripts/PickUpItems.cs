using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public Item itemDetails;
    public int slotIndex = 0; // ��������� ���� ��� ����� ��������, ����� ���������� �� ��������� Unity

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            QuickInventory inventory = other.gameObject.GetComponent<QuickInventory>();
            if (inventory != null)
            {
                inventory.itemsInSlots[slotIndex] = itemDetails; // ��������� ������ Item � �����
                inventory.AddItemToSlot(itemDetails.itemSprite, slotIndex);
                Destroy(gameObject);
            }
        }
    }
}


