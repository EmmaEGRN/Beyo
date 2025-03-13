using UnityEngine;

public class NewVocabulary : Interactable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] private GameObject CartaDePalabra;
    //[SerializeField] private NewWordCardManager WordCardManager;
    
    void Start()
    {
        CartaDePalabra.SetActive(false);
        //WordCardManager = CartaDePalabra.GetComponentInChildren<NewWordCardManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        CartaDePalabra.SetActive(true);
        //WordCardManager.sound();
        CartaDePalabra.GetComponentInChildren<NewWordCardManager>().sound();
    }

}
