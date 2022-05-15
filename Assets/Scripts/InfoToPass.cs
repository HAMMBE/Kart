using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Scripts/ScriptableObjects")]
public class InfoToPass : ScriptableObject
{
    public int nbPlayers = -1;
    public int carP1 = -1;
    public int carP2 = -1;
}
