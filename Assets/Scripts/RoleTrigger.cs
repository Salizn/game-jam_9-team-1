using UnityEngine;

public class RoleTrigger : MonoBehaviour
{
    public PlayerRole roleToSet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRoleManager.Instance.SetRole(roleToSet);
        }
    }
}
