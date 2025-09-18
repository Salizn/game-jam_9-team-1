using UnityEngine;

[CreateAssetMenu(fileName = "CardPool", menuName = "Scriptable Objects/Card Pool")]
public class CardPool : ScriptableObject
{
    public CardSO[] pool;
}
