using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneHandler : MonoBehaviour
{
    public int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotoTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void GotoGameplay()
    {
        SceneManager.LoadScene("Gameplay 1");
    }

   public void GotoStageSelect()
    {
        SceneManager.LoadScene("StageSelect");
        
    }

    public void GotoLevelGameplay()
    {
        SceneManager.LoadScene("Level Gameplay");

    }


    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }


}
