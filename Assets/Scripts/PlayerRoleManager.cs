using UnityEngine;
using System;

public enum PlayerRole
{
    Hero,
    Villain
}

public class PlayerRoleManager : MonoBehaviour
{
    public static PlayerRoleManager Instance;

    public PlayerRole CurrentRole { get; private set; } = PlayerRole.Hero;

    public event Action<PlayerRole> OnRoleChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SetRole(PlayerRole newRole)
    {
        if (CurrentRole == newRole) return;

        CurrentRole = newRole;
        OnRoleChanged?.Invoke(CurrentRole);
        Debug.Log("Player role switched to: " + CurrentRole);
    }

    public bool IsHero => CurrentRole == PlayerRole.Hero;
    public bool IsVillain => CurrentRole == PlayerRole.Villain;
}
