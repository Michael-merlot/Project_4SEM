using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject enterButton; // ��������� �� ���� ������.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && enterButton != null)
        {
            enterButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && enterButton != null)
        {
            enterButton.SetActive(false);
        }
    }

}



