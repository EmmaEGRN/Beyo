using UnityEngine;

[CreateAssetMenu(fileName = "InfoNivel", menuName = "Scriptable Objects/InfoNivel")]
public class InfoNivel : ScriptableObject
{
    public int numeroDeVidas;
    public int numeroDefault;

    public int numeroDeNivel;
    public string nombreDeNivel;

    public enum State {disabled, enabled, cleared};
    public State state;

    public int startScene;

    public Sprite enabled;
    public Sprite disabled;
    public Sprite cleared;

}
