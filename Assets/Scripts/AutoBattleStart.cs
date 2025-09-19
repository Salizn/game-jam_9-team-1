using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoBattleStart : MonoBehaviour
{

    public CardDisplay[] heroCardList;
    public CardDisplay[] monsterCardList;
    private int attackvalue;
    private int defencevalue;
    private int attackvalue2;
    private int defencevalue2;
    public Sprite koimage;


    public void BattleButtonPress()
    {
        //determine who goes first Not implimented, hero goes first atm.
        for(int i =0;i<4; i++)
        {

            attackvalue = heroCardList[i].cardData.attack;
            defencevalue = heroCardList[i].cardData.defense;
            attackvalue2 = monsterCardList[i].cardData.attack;
            defencevalue2 = monsterCardList[i].cardData.defense;
            int result1 = defencevalue2 - attackvalue;
            int result2 = defencevalue - attackvalue2;

            if (result1 <= 0)
            { monsterCardList[i].artworkImage.sprite = koimage; }

            if (result2 <= 0)
            { heroCardList[i].artworkImage.sprite= koimage; }


            }
      


    }
}
