using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueScriptableObject dialogue;

    void OnMouseDown() // ��� ����� ����������� ��� ������� �� ������
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueUIManager>().StartDialogue(dialogue);
    }
}
