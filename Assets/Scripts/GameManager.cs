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

    public int dinerito=5;

    public int experience=0;

    public void SaveState()
    {
        string s = " ";
        s += "0" + "|";
        s += dinerito.ToString()+"|";
        s += experience.ToString()+"|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(UnityEngine.SceneManagement.Scene s, LoadSceneMode mode)
    {
        if (PlayerPrefs.HasKey("SaveState"))
            return;
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //dinerito = int.Parse(data[1]);
        //experience = int.Parse(data[2]);


        Debug.Log("LoadState");
    }
}
