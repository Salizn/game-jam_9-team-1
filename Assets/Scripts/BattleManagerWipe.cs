using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleManagerWipe : MonoBehaviour
{
    public GameObject player;
    public GameObject battleUI;
    public Material radialMaterial;
    public float transitionSpeed = 2f;
    public float minRadius = 0f;
    public float maxRadius = 1f;

    private bool inBattle = false;
    private StarterAssets.FirstPersonController controller;
    private float currentRadius;

    void Start()
    {
        battleUI.SetActive(false);
        controller = player.GetComponent<StarterAssets.FirstPersonController>();
        radialMaterial.SetFloat("_Radius", maxRadius);
        currentRadius = maxRadius;
    }

    public void StartBattle()
    {
        if (inBattle) return;
        StartCoroutine(BattleTransition());
    }

    private void SetCursorState(bool locked)
    {
        if (locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private IEnumerator BattleTransition()
    {
        inBattle = true;
        controller.enabled = false;

        // Animate closing
        yield return StartCoroutine(AnimateRadius(minRadius));

        battleUI.SetActive(true);
        SetCursorState(false);

        // Animate opening
        yield return StartCoroutine(AnimateRadius(maxRadius));
    }

    public void EndBattle()
    {
        StartCoroutine(EndBattleRoutine());
    }

    private IEnumerator EndBattleRoutine()
    {
        yield return StartCoroutine(AnimateRadius(minRadius));

        battleUI.SetActive(false);
        SetCursorState(true);

        yield return StartCoroutine(AnimateRadius(maxRadius));

        controller.enabled = true;
        inBattle = false;
    }

    private IEnumerator AnimateRadius(float target)
    {
        float start = currentRadius;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * transitionSpeed;
            currentRadius = Mathf.Lerp(start, target, t);
            radialMaterial.SetFloat("_Radius", currentRadius);
            yield return null;
        }
    }
}
