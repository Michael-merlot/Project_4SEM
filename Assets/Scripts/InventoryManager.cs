using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel; // ������ ���������
    public List<Item> inventoryItems = new List<Item>(); // ������ ��������� � ���������

    void Update()
    {
        // �������� ������� ������� 'I'
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    // ������� ��� ������������ ��������� ������ ���������
    public void ToggleInventory()   
    {
        bool isActive = inventoryPanel.activeSelf;
        inventoryPanel.SetActive(!isActive);

        if (isActive)
        {
            // TODO: �������� UI ���������, ����� ��������� ����� ������
        }
        else
        {
            UpdateInventoryUI();
        }
    }

    // ������� ��� ���������� �������� � ���������
    public void AddItem(Item item)
    {

    }

    // ������� ��� ���������� UI ���������
    private void UpdateInventoryUI()
    {
        // TODO: ���������� ���������� UI ���������
        // ������:
        // �������� �� ���� ������ ��������� � ��������� �������� ��������� � ���
        // ���� � ��� ���� ������ ��� ���������� ������� ���������, �������� ��� �����
    }

            
}

