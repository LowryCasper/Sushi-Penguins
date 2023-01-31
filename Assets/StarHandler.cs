using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    public GameObject[] starImage;
    public int levelStarIndex;
    
    public int starGet;
    // Start is called before the first frame update

    private void Awake()
    {
      


    }
    void Start()
    {
        starGet = SaveManager.instance.saveData.completedStars[levelStarIndex];
        switch (starGet)
        {
            case 1:
                starImage[0].SetActive(true);
                break;
            case 2:
                starImage[0].SetActive(true);
                starImage[1].SetActive(true);
                break;
            case 3:
                starImage[0].SetActive(true);
                starImage[1].SetActive(true);
                starImage[2].SetActive(true);
                break;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
