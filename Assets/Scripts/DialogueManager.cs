using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Image characterImage; // ���� ������ ���������� ����������� ���������

    private Queue<string> sentences;
    private Queue<bool> sentenceRoles; // ������� ��� ����� ������ (true - �����, false - NPC)
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

        // �������� �� ������ ��� �������� �������
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

        // ��������� ��� � ����������� �� ����, ��� �������
        if (isPlayer)
        {
            nameText.text = "Player"; // ��� �����
        }
        else
        {
            nameText.text = currentDialogue.name; // ��� NPC
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
