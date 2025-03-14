using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCLayout", menuName = "Scriptable Objects/NPCLayout")]
public class NPCLayout : ScriptableObject
{

    new public string name;
    public string characterName;
    public Vocabulario roll;
    public Sprite icon = null;
    public Objects mision;
    public Boolean hasMission = true;


}
