using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class SaveData
{
    public List<bool> completedStages;
   
}
public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public SaveData saveData;
    public int numberOfStages;
    public int stageIndex;
    private string savePath;

   


   
    private void Start()
    {
        instance = this;
        
        savePath = Application.persistentDataPath + "/save.json";
        saveData = new SaveData();
        if (!File.Exists(savePath))
        {
            saveData.completedStages = new List<bool>();
            for (int i = 0; i < numberOfStages; i++)
            {
                saveData.completedStages.Add(false);
            }
            Save();
        }
        else
        {
            Load();
        }
      
    }
    private void Update()
    {
        DeleteSaveData();
    }

    public void CompleteStage(int stageIndex)
    {
        saveData.completedStages[stageIndex] = true;
        Save();
    }

    private void Save()
    {
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(savePath, json);
    }

    private void Load()
    {
        string json = File.ReadAllText(savePath);
        saveData = JsonUtility.FromJson<SaveData>(json);
    }

    public void DeleteSaveData()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            File.Delete(savePath);


            Debug.Log("Reset Saved Data");
        }
      
    }

 

   

    
}
