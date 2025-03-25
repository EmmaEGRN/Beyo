using UnityEngine;

public class OrganizadorGlosario : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] WordRecord wordRecord;
    [SerializeField] int pag;
    [SerializeField] GameObject panel;

    int num;
    int over;
    void Start()
    {
        //updateGlosary();
    }

    private void OnEnable()
    {
        if(transform.childCount != 4) updateGlosary();


    }

    public void updateGlosary()
    {
        Debug.Log("Hay esta cantidad de vocabulario" + wordRecord.palabras.Count);
        over = (wordRecord.palabras.Count) % 4;
        if (over == 0) over = 4;
        num = (wordRecord.palabras.Count - wordRecord.palabras.Count % 4) / 4;
        if (num > pag)
        {
            num = pag;
            over = 4;
        };

        Debug.Log("el número de página es :" + num);
        Debug.Log("la cantidad de cartas en esta página es: " + over);

        if (checkIfPageAvailable())
        {
            setWords();
        }
    }

    public bool checkIfPageAvailable()
    {
       if (num == pag)
        {
            return true;
        }

       return false;
    }

    // Update is called once per frame


    void setWords()
    {
        for (int i = 0; i < over; i++)
        {
            GameObject palabra;
            palabra = Instantiate(panel, transform);
            palabra.GetComponent<NewWordCardManager>().vocab = wordRecord.palabras[i + num * 4];
            transform.GetChild(i).GetComponent<NewWordCardManager>().setContent();
            Debug.Log(wordRecord.palabras[i + num * 4]);

        }
    }

    void Update()
    {
        
    }
}
