using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WordRecord", menuName = "Scriptable Objects/WordRecord")]
public class WordRecord : ScriptableObject
{
    [SerializeField] public List<Vocabulario> palabras = new List<Vocabulario>();
}
