using UnityEngine;

public class EnterDoorUI : MonoBehaviour
{
    public static EnterDoorUI instance;
    public GameObject enterButton; // Указатель на объект кнопки входа в вашем UI

    private void Start()
    {
        // Скрываем кнопку при старте
        Hide();
    }

    public static void Show()
    {
        // Проверка на наличие экземпляра
        if (instance.enterButton != null)
            instance.enterButton.SetActive(true); // Показываем кнопку входа
    }

    public static void Hide()
    {
        // Проверка на наличие экземпляра
        if (instance.enterButton != null)
            instance.enterButton.SetActive(false); // Скрываем кнопку входа
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

