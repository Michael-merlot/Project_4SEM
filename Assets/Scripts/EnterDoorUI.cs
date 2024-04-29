using UnityEngine;

public class EnterDoorUI : MonoBehaviour
{
    public static EnterDoorUI instance;
    public GameObject enterButton; // ��������� �� ������ ������ ����� � ����� UI

    private void Start()
    {
        // �������� ������ ��� ������
        Hide();
    }

    public static void Show()
    {
        // �������� �� ������� ����������
        if (instance.enterButton != null)
            instance.enterButton.SetActive(true); // ���������� ������ �����
    }

    public static void Hide()
    {
        // �������� �� ������� ����������
        if (instance.enterButton != null)
            instance.enterButton.SetActive(false); // �������� ������ �����
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}

