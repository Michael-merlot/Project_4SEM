using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class DialogueScriptableObject : ScriptableObject
{
    public string name;
    public Sprite characterImage;
    [TextArea(3, 10)]
    public string[] sentences;
    public bool[] isPlayerSentence; // true, если реплика принадлежит игроку
}
