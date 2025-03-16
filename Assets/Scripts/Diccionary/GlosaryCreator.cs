using UnityEngine;
using UnityEngine.Events;

public class GlosaryCreator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private WordRecord wordRecord;
    [SerializeField] GameObject panel;

    public void updateWordRecord()
    {
        Debug.Log("Empieza el update");
        foreach (Vocabulario palabras in wordRecord.palabras) {
        Debug.Log(palabras.name);
           GameObject palabra;
           palabra = Instantiate(panel, transform);
           palabra.GetComponent<WordPanelSetter>().setWords(palabras);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
