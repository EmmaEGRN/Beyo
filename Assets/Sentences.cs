using UnityEngine;

[CreateAssetMenu(fileName = "Sentences", menuName = "Scriptable Objects/Sentences")]
public class Sentences : ScriptableObject
{
    public Vocabulario[] palabras;

    public string traducción;


}
