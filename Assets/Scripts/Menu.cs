using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text levelText, hitpointText, dineroText, upgradeText, xpText;

    private int currentCharacter = 0;
    public Image characterSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    public void OnArrowClick(bool right)
    {
        if(right)
        {
            currentCharacter++;
            if (currentCharacter == GameManager.instance.playerSprites.Count)
            {
                currentCharacter = 0;
            }
            OnSelectionChanged();
        }
        else
        {
            currentCharacter--;
            if (currentCharacter <0)
            {
                currentCharacter = GameManager.instance.playerSprites.Count-1;
            }
            OnSelectionChanged();
        }
    }

    private void OnSelectionChanged()
    {
        characterSprite.sprite = GameManager.instance.playerSprites[currentCharacter];
        GameManager.instance.player.CambiarAvatar(currentCharacter);
    }

    public void OnUpgradeClick()
    {
        if (GameManager.instance.TryUpgradeWeapon())
        {
            UpdateMenu();
        }
    }

    public void UpdateMenu()
    {
        weaponSprite.sprite = GameManager.instance.weaponSprites[0];
        upgradeText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();

        hitpointText.text= GameManager.instance.player.hitpoint.ToString();
        dineroText.text=GameManager.instance.dinerito.ToString();
        levelText.text = GameManager.instance.GetCurrentLev().ToString();
        int currentLev=GameManager.instance.GetCurrentLev();
        if(GameManager.instance.GetCurrentLev()==GameManager.instance.xpTables.Count)
        {
            xpText.text=GameManager.instance.experience.ToString()+"xp";
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int prevLevelXp = GameManager.instance.GetXpToLevel(currentLev-1);
            int currLevelXp = GameManager.instance.GetXpToLevel(currentLev );
            int dif=currLevelXp-prevLevelXp;
            int currXpIntoLevel = GameManager.instance.experience - prevLevelXp;
            float comp=(float) currXpIntoLevel/(float) dif;
            xpBar.localScale = new Vector3(comp, 0, 0);
            xpText.text = currXpIntoLevel.ToString()+" / "+dif;
        }

        
    }
}
