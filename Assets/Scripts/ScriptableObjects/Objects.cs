using UnityEngine;

[CreateAssetMenu(fileName = "Objects", menuName = "Scriptable Objects/Objects")]
public class Objects : ScriptableObject
{
    new public string name = "NewObject";
    public Sprite icon = null;
    public Sprite disabledIcon = null;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
