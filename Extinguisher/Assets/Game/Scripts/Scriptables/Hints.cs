using UnityEngine;

[CreateAssetMenu(fileName = "Hints", menuName = "Scriptables/Hints")]
public class Hints : ScriptableObject
{
    [Header("Hints")]
    [TextArea(2, 4)]
    [SerializeField] public string hintLocked;
    [TextArea(2, 4)]
    [SerializeField] public string hintUnlocked;
    [TextArea(2, 4)]
    [SerializeField] public string hintReady;
    [TextArea(2, 4)]
    [SerializeField] public string hintGameComplete;
    [TextArea(2, 4)]
    [SerializeField] public string hintGameOver;
}
