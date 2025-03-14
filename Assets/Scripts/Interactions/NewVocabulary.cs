using UnityEngine;

public class NewVocabulary : Interactable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //[SerializeField] private NewWordCardManager WordCardManager;

    [SerializeField] Vocabulario nuevoVocabulario;

    public delegate void OnNewWordAcquired(Vocabulario nuevoVocab);
    public static event OnNewWordAcquired onNewWordAcquired;

    private void Awake()
    {
        onNewWordAcquired = null;
    }

    private void OnDestroy()
    {
        onNewWordAcquired = null;
    }
    void Start()
    {

    }

    void Update()
    {
        
    }

    public override void Interact()
    {
        onNewWordAcquired?.Invoke(nuevoVocabulario);
    }

}
