using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public Button[] stageButton;

    public GameObject[] panelStage;

    public int currentBtnIndex;
    public int currentPanelIndex;

    public int levelReached;

    public LevelHandler levelHandler;

    public Button nextButton;
    public Button backButton;

    private void Awake()
    {
        instance = this;
        
      
        stageButton[currentBtnIndex].interactable = true;

        foreach (var panel in panelStage)
        {
            panel.SetActive(false);

        }
        panelStage[currentPanelIndex].SetActive(true);

    }

    private void Start()
    {
        levelReached = PlayerPrefs.GetInt("NextStage");
        for (int i = 0; i < stageButton.Length; i++)
        {


            if (i + 1 > levelReached)
            {
                stageButton[i].interactable = false;
            }


        }
    }

    private void Update()
    {
      
        StageOpen();
      
    }

    public void NextStage()
    {
        panelStage[currentPanelIndex].SetActive(false);

        if (currentPanelIndex < panelStage.Length - 1)
        {
            currentPanelIndex++;
            
        }
      
    }
    public void BackStage()
    {
        panelStage[currentPanelIndex].SetActive(false);

       
        
            currentPanelIndex--;
            if (currentPanelIndex == -1)
                currentPanelIndex = panelStage.Length - 1;

        

    }

    public void StageOpen()
    {
        panelStage[currentPanelIndex].SetActive(true);
    }

    

   
}


