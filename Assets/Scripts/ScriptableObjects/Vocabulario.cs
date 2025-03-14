using UnityEngine;

[CreateAssetMenu(fileName = "Vocabulario", menuName = "Scriptable Objects/Vocabulario")]
public class Vocabulario : ScriptableObject
{
    public int ID;
    public string Parlabra;
    public string PalabraRaw;
    public string Traducción;
    public Sprite imagen;

}
