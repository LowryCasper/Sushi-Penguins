using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkin", menuName = "ScriptableObjects/Skin")]
public class PlayerSkinSO : ScriptableObject
{
    public string skinName;
    public GameObject skinImage;
    public int skinPrice;
    public bool isunlocked;
}
