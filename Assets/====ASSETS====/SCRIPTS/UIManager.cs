using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class UIManager : MonoBehaviour
{
  
    public TextMeshProUGUI coinText;
    public PlayerDataSO coin;

    public PlayerSkinSO[] playerSkins;
    public LevelCompleteSO[] levelCompleteSO;



    private void Awake()
    {
        

        PlayerPrefs.GetInt("currentcoin", coin.currentCoin);
        UpdateCoinUI();
    }

    private void update()
    {
       
    }

    public void BuyCoin()
    {
         coin.currentCoin--;
        UpdateCoinUI();
        PlayerPrefs.SetInt("currentcoin", coin.currentCoin);
    }

    public void UpdateCoinUI()
    {
       coinText.text = " " + coin.currentCoin;
    }




    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
        coin.currentCoin = coin.MaxCoin;

        foreach (var skin in playerSkins)
            skin.isunlocked = false;

       
        SceneManager.LoadScene("Title");

        
    }
}


