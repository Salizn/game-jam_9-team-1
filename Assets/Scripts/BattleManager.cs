using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    public GameObject player;
    public GameObject battleUI;
    public Image transitionImage;
    public float transitionSpeed = 1f;

    private bool inBattle = false;

    private StarterAssets.FirstPersonController controller;

    void Start()
    {
        battleUI.SetActive(false);
        controller = player.GetComponent<StarterAssets.FirstPersonController>();
    }

    public void StartBattle()
    {
        if (inBattle) return;
        StartCoroutine(BattleTransition());
    }

    private IEnumerator BattleTransition()
    {
        inBattle = true;

        controller.enabled = false;

        yield return StartCoroutine(FadeScreen(1));

        battleUI.SetActive(true);

        yield return StartCoroutine(FadeScreen(0));
    }

    public void EndBattle()
    {
        StartCoroutine(EndBattleRoutine());
    }

    private IEnumerator EndBattleRoutine()
    {
        yield return StartCoroutine(FadeScreen(1));

        battleUI.SetActive(false);

        yield return StartCoroutine(FadeScreen(0));

        controller.enabled = true;

        inBattle = false;
    }

    private IEnumerator FadeScreen(float targetAlpha)
    {
        Color c = transitionImage.color;
        float startAlpha = c.a;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * transitionSpeed;
            c.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            transitionImage.color = c;
            yield return null;
        }
    }
}
