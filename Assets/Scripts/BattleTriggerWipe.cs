using UnityEngine;

public class BattleTriggerWipe : MonoBehaviour
{
    public BattleManagerWipe manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.StartBattle();
        }
    }
}
