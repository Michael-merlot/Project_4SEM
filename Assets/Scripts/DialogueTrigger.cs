using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueScriptableObject dialogue;

    void OnMouseDown() // Это будет срабатывать при нажатии на объект
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueUIManager>().StartDialogue(dialogue);
    }
}
