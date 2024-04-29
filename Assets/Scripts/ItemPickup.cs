using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item itemDetails; // ������ �� ������ ��������

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("Player"))
        {
            InventoryManager inventory = other.gameObject.GetComponent<InventoryManager>();
            if (inventory != null)
            {
                inventory.AddItem(itemDetails); // �������� ������� � ���������
                gameObject.SetActive(false); // ��������� ������� �� ����� ��� ���������� ���
            }
        }
    }
}


