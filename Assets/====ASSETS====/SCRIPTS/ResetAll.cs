using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAll : MonoBehaviour
{
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
       
    }
}
