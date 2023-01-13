using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName ="ScriptableObjects/Coin",order = 1)]
public class PlayerDataSO : ScriptableObject
{
    public int currentCoin;
    public int MaxCoin;
}
