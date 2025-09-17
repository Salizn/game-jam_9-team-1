using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Scriptable Objects/Card")]
public class CardSO : ScriptableObject
{
    public string cardName;
    public Sprite artwork;
    public int attack;
    public int defense;
}
