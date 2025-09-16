using UnityEngine;

public class BAttleTrigger : MonoBehaviour
{
    public BattleManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            manager.StartBattle();
        }
    }
}
