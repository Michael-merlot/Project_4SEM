using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Image characterImage; // Если хотите отображать изображение персонажа

    private Queue<string> sentences;
    private Queue<bool> sentenceRoles; // Очередь для ролей реплик (true - игрок, false - NPC)
    private DialogueScriptableObject currentDialogue;
    private bool isDialogueActive = false;

    void Start()
    {
        sentences = new Queue<string>();
        sentenceRoles = new Queue<bool>();
    }

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(DialogueScriptableObject dialogue)
    {
        Debug.Log("StartDialogue called");

        // Проверка на пустые или неравные массивы
        if (dialogue.sentences.Length == 0 || dialogue.isPlayerSentence.Length == 0)
        {
            Debug.LogError("Dialogue arrays are empty!");
            EndDialogue();
            return;
        }

        if (dialogue.sentences.Length != dialogue.isPlayerSentence.Length)
        {
            Debug.LogError("Dialogue arrays have different lengths!");
            EndDialogue();
            return;
        }

        currentDialogue = dialogue;

        sentences.Clear();
        sentenceRoles.Clear();

        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            sentences.Enqueue(dialogue.sentences[i]);
            sentenceRoles.Enqueue(dialogue.isPlayerSentence[i]);
        }

        isDialogueActive = true;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        bool isPlayer = sentenceRoles.Dequeue();
        Debug.Log("Displaying sentence: " + sentence);

        // Обновляем имя в зависимости от того, кто говорит
        if (isPlayer)
        {
            nameText.text = "Player"; // Имя героя
        }
        else
        {
            nameText.text = currentDialogue.name; // Имя NPC
        }

        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");
        isDialogueActive = false;
        nameText.text = "";
        dialogueText.text = "";
    }
}
