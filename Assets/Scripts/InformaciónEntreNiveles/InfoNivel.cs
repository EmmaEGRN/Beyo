using UnityEngine;

[CreateAssetMenu(fileName = "InfoNivel", menuName = "Scriptable Objects/InfoNivel")]
public class InfoNivel : ScriptableObject
{
    public int numeroDeVidas;
    public int numeroDefault;

    public int numeroDeNivel;
    public string nombreDeNivel;
    public bool cleared;

    public enum State {disabled, enabled, cleared};
    public State state;

    public int startScene;

}
