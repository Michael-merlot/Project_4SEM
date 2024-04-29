using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public PlayerHealth playerHealth;

    void Update()
    {
        // �� ������ ������������ ���� ���, ����� �� �������������� ����, ��� �� ���������� ��������� ������.
        // ����� ��������������, ��� playerHealth.maxHealth - ��� ������������ ��������, � playerHealth.currentHealth - ������� ��������.
        float healthPercent = (float)playerHealth.currentHealth / playerHealth.maxHealth;
        healthBarImage.fillAmount = healthPercent;

        if (playerHealth.currentHealth <= 0)
        {
            // �������� ��� ������, ��������, ����������� ��������� � ������.
            // ���������, ��� � ��� ���� ��������, ������� ����� ������� ������ ������ � ���������� ���� ��� ������������� �������.
        }
    }
}

