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
        upgradeText.text = "No hecho";

        hitpointText.text= GameManager.instance.player.hitpoint.ToString();
        dineroText.text=GameManager.instance.dinerito.ToString();
        levelText.text = "No hecho";

        xpText.text = "No hecho";
        xpBar.localScale = new Vector3(0.5f, 0, 0);
    }
}
