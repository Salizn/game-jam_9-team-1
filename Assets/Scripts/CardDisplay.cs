using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    [Header("Card Data")]
    public CardSO cardData;

    [Header("UI References")]
    public Image artworkImage;
    public TextMeshProUGUI cardNameText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;

    private void Start()
    {
        LoadCard(cardData);
    }

    public void LoadCard(CardSO newCard)
    {
        cardData = newCard;

        if (cardNameText) cardNameText.text = cardData.cardName;
        if (artworkImage) artworkImage.sprite = cardData.artwork;
        if (attackText) attackText.text = cardData.attack.ToString();
        if (defenseText) defenseText.text = cardData.defense.ToString();
    }
}
