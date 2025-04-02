using UnityEngine;

public class WordRecordManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private WordRecord wordRecord;

    void Start()
    {

        NewVocabulary.onNewWordAcquired += AddNewWordToDictionary;
        NewWordCardManager.addThisWord += AddNewWordToDictionary;


    }
    private void OnDestroy()
    {
        NewVocabulary.onNewWordAcquired -= AddNewWordToDictionary;
        NewWordCardManager.addThisWord -= AddNewWordToDictionary;
    }


    public void AddNewWordToDictionary(Vocabulario vocab)
    {
        if (vocab == null) return;
        Debug.Log(CheckIfWordAlreadyInDictionary(vocab));
        if (!CheckIfWordAlreadyInDictionary(vocab))
        {
            wordRecord.palabras.Add(vocab);
        }
    }

    public bool CheckIfWordAlreadyInDictionary(Vocabulario vocab)
    {
        if (wordRecord.palabras.Contains(vocab))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
