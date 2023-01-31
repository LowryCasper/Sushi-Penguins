using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Callout : MonoBehaviour
{
    public GameObject[] calloutTextPrefab;
  
    public Vector2 spawnAreaCenter;
    public float spawnAreaRadius;
    public float currentScore;
    public float targetScore;
    public bool isCalled;


    private void Start()
    {
        
    }
    void Update()
    {
        currentScore = (float)GameManager.instance.score;
        targetScore = (float)GameManager.instance.targetScore;

        float percentage = currentScore / targetScore;

      if(percentage>=0.2f&& percentage <=0.5f && !isCalled)
        {

            Vector2 spawnPosition = spawnAreaCenter + Random.insideUnitCircle * spawnAreaRadius;
            Instantiate(calloutTextPrefab[0], spawnPosition, Quaternion.identity);
            isCalled = true;

            StartCoroutine(InstantiateCalloutText());
        }
       if (percentage >= 0.5f && percentage<=1f &&!isCalled)
        {
            Vector2 spawnPosition1 = spawnAreaCenter + Random.insideUnitCircle * spawnAreaRadius;
            Instantiate(calloutTextPrefab[1], spawnPosition1, Quaternion.identity);
            isCalled = true;
            StartCoroutine(InstantiateCalloutText());
        }
      if(percentage <=1f && !isCalled)
        {
            Vector2 spawnPosition2 = spawnAreaCenter + Random.insideUnitCircle * spawnAreaRadius;
            Instantiate(calloutTextPrefab[2], spawnPosition2, Quaternion.identity);
            isCalled = true;
            StartCoroutine(InstantiateCalloutText());
        }

        

           

           
               
        

        IEnumerator InstantiateCalloutText()
        {
           
            yield return new WaitForSeconds(2f);

            calloutTextPrefab[0].SetActive(false);
            calloutTextPrefab[1].SetActive(false);
            Destroy(calloutTextPrefab[2]);

        }
    }
 




    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(spawnAreaCenter, spawnAreaRadius);
    }


}
