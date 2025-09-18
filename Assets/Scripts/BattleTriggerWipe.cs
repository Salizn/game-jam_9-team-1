using UnityEngine;

public class BattleTriggerWipe : MonoBehaviour
{
    public BattleManagerWipe manager;

    public CardPool heroPool;
    public CardPool villainPool;

    public CardDisplay[] heroCards;
    public CardDisplay[] villainCards;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RandomizeCards();
            manager.StartBattle();
        }


    }

    private void RandomizeCards()
    {
        foreach (CardDisplay display in heroCards)
        {
            CardSO randomCard = heroPool.pool[Random.Range(0, heroPool.pool.Length)];
            display.LoadCard(randomCard);
        }

        foreach (CardDisplay display in villainCards)
        {
            CardSO randomCard = villainPool.pool[Random.Range(0, villainPool.pool.Length)];
            display.LoadCard(randomCard);
        }
    }
}
