using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ChallangeInfo", order = 1)]
public class ChallangeInfo : ScriptableObject
{
    public string challangeName;
    public string description;
    public int reward;
    public string id;
    public string idQuest;



}
