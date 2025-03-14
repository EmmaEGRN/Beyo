using UnityEngine;

public class WordRecordManagerPreLevel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private WordRecord wordRecord;

    void Start()
    {

        LevelManager.onRightAnswer += AddNewWordToDictionary;

    }
    private void OnDestroy()
    {
        LevelManager.onRightAnswer -= AddNewWordToDictionary;
    }


    private void AddNewWordToDictionary(Vocabulario vocab)
    {
        Debug.Log(CheckIfWordAlreadyInDictionary(vocab));
        if (!CheckIfWordAlreadyInDictionary(vocab))
        {
            wordRecord.palabras.Add(vocab);
        }
    }

    private bool CheckIfWordAlreadyInDictionary(Vocabulario vocab)
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
