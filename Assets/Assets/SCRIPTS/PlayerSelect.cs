using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    

    public PlayerSkinSO[] playerSkins;

    public Transform playerSkinPosition;

    public PlayerIndexSO selectedPlayerindex;
    public int currentPlayerIndex;

    public TextMeshProUGUI purchaseText;

    public GameObject purchaseButtonUI;

    public GameObject selectButtonUI;

    private List<GameObject> skins;

    public GameObject lockedIcon;

    public PlayerDataSO coin;
   

    private void Awake()
    {
       
        
        // if (PlayerPrefs.HasKey("SkinPurchased"))

        // Debug.Log("load purchased skin");
        // playerSkins[currentPlayerIndex].isunlocked = true;



        foreach (var skinprice in playerSkins)
            if(skinprice.skinPrice > 0 )
            {
                purchaseButtonUI.SetActive(false);
                lockedIcon.SetActive(false);
            }


        // UpdateLockedIcon();
        // UpdatePurchaseButtonUI();

       currentPlayerIndex = PlayerPrefs.GetInt("selectedPlayer", currentPlayerIndex);
        //currentPlayerIndex = selectedPlayerindex.indexValue;
        skins = new List<GameObject>();

        foreach(var PlayerSkinSo in playerSkins)
        {
            GameObject go = Instantiate(PlayerSkinSo.skinImage, playerSkinPosition.position, Quaternion.identity);
            go.SetActive(false);
            go.transform.SetParent(playerSkinPosition);
            skins.Add(go);
        }




       

        //  if (PlayerPrefs.HasKey("selectedPlayerIndex"))
        // Instantiate(playerSkins[currentPlayerIndex].skinImage, playerSkinPosition.position, Quaternion.identity);
        //  else
        {
       //     Instantiate(playerSkins[0].skinImage, playerSkinPosition.position, Quaternion.identity);
        }
       // UpdatePurchaseButtonUI();
    }
    private void Update()
    {

        // SaveSkin();
        SpawnSkin();


    }
    public void NextSelection()
    {
        skins[currentPlayerIndex].SetActive(false);

       
        if (currentPlayerIndex < skins.Count - 1)
        {
            currentPlayerIndex++;
        }
        else
            currentPlayerIndex = 0;

    
        UpdateLockedIcon();
        UpdatePurchaseButtonUI();
        SelectableSkinUI();
        ShowPurchaseText();
        PlayerPrefs.SetInt("selectedPlayer", currentPlayerIndex);

    }
    public void PreviousSelection()
    {
       
        skins[currentPlayerIndex].SetActive(false);
        currentPlayerIndex--;
        if (currentPlayerIndex == -1)
            currentPlayerIndex = skins.Count - 1;
        UpdateLockedIcon();
        UpdatePurchaseButtonUI();
        SelectableSkinUI();


        SpawnSkin();
        ShowPurchaseText();
        PlayerPrefs.SetInt("selectedPlayer", currentPlayerIndex);
    }
           

    public void SpawnSkin()
    {
     //if(playerSkins[currentPlayerIndex].isunlocked)
        skins[currentPlayerIndex].SetActive(true);
        // else
       
          
       
 
    }

    public void SaveSkin()
    {
          currentPlayerIndex = PlayerPrefs.GetInt("selectedPlayer", currentPlayerIndex);
    }


   public void PurchaseSKin()
    {
        int skinCost = playerSkins[currentPlayerIndex].skinPrice;
        
            coin.currentCoin = coin.currentCoin - skinCost;
      
        playerSkins[currentPlayerIndex].isunlocked = true;

       // PlayerPrefs.SetInt("SkinPurchased", playerSkins[currentPlayerIndex].isunlocked ? 0 : 1);
        UpdatePurchaseButtonUI();


        UpdateLockedIcon();
        SelectableSkinUI();
        

    }

    public void UpdateLockedIcon()
    {
        if (playerSkins[currentPlayerIndex].isunlocked == true)
            lockedIcon.SetActive(false);
        else
            lockedIcon.SetActive(true);

    }

    public void UpdatePurchaseButtonUI()
    {
        if (playerSkins[currentPlayerIndex].isunlocked)
        {
            purchaseButtonUI.SetActive(false);

        }


        else
        {
            purchaseButtonUI.SetActive(true);

        }
    }

    public void SelectableSkinUI()
    {
        if (playerSkins[currentPlayerIndex].isunlocked)
            selectButtonUI.SetActive(true);
        else
            selectButtonUI.SetActive(false);
    }

    public void SelectSkinforGameplay()
    {
        PlayerPrefs.SetInt("selectedPlayer", currentPlayerIndex);
        
    }

    public void ShowPurchaseText()
    {
        purchaseText.text = "$ " + playerSkins[currentPlayerIndex].skinPrice;
    }

}
