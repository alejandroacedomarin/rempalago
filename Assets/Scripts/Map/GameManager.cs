using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTables;

    public Tom_Controller player;
    public Weapons weapon;
    public FTManager floatingTextManager;

    public int dinerito=5;

    public int experience=0;


    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
    private void Update()
    {
        GetCurrentLev();
    }
    public int GetCurrentLev()
    {
        int r = 0;
        int ad = 0;
        while (experience >= ad)
        {
            ad += xpTables[r];
            r++;
            if (r == xpTables.Count)
            {
                return r;
            }
        }
        return r;
    }
    public int GetXpToLevel(int level)
    {
        int r = 0;
        int xp = 0;
        while (r < level)
        {
            xp += xpTables[r];
            r++;
        }
        return xp;
    }

    public void DarXp(int xp)
    {
        int currLev = GetCurrentLev();
        experience += xp;
        if(currLev < GetCurrentLev())
        {
            //LevelUp();
        }
    }
    public bool TryUpgradeWeapon()
    {
        if(weaponPrices.Count<=weapon.weaponLevel)
        {
            return false;
        }
        if(dinerito <= weaponPrices[weapon.weaponLevel])
        {
            dinerito -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }
        return false;
    }


    public void SaveState()
    {
        string s = " ";
        s += "0" + "|";
        s += dinerito.ToString()+"|";
        s += experience.ToString()+"|";
        s += weapon.weaponLevel.ToString();

        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(UnityEngine.SceneManagement.Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }
            
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        Debug.Log(data[0]+"|"+ data[1] + "|" + data[2] + "|" + data[3]);
        dinerito = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        weapon.SetWeaponLevel(int.Parse(data[3]));

        Debug.Log("LoadState");
    }
}
