using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TMP_Text))]
public class InteractiveTMP : MonoBehaviour, IPointerClickHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TMP_Text _tmpTextBox;
    [SerializeField] private Canvas _canvasToCheck;
    [SerializeField] private Camera _cameraToUse;

    public delegate void ClickOnLinkEvent(string keyword);
    public static event ClickOnLinkEvent OnClickOnLinkEvent;


    public string original;

    DialogueManager manager;
    public void OnPointerClick(PointerEventData eventData)
    {

        Vector3 mousePosition = new Vector3(eventData.position.x, eventData.position.y, z: 0);
        var linkTaggedText = TMP_TextUtilities.FindIntersectingLink(_tmpTextBox, mousePosition, _cameraToUse);

        if(original != null)_tmpTextBox.text = original;


        original = _tmpTextBox.text;


        string temporary = _tmpTextBox.text;
        // int numberOfSpaces = 0;

        string[] div = temporary.Split("> ");
        for (int i = 0; i < div.Length-1; i++)
        {
            div[i] = div[i] + ">";
        }

        string[] newDiv = new string[div.Length];

        int indicedeDiv = TMP_TextUtilities.FindIntersectingLink(_tmpTextBox, mousePosition, _cameraToUse);
        

        if (indicedeDiv != -1)
        {
            Debug.Log("El índice que usamos es: " + indicedeDiv);

            Debug.Log("La palabr es de " + div[indicedeDiv].Length + "caracteres");
            newDiv[indicedeDiv] = div[indicedeDiv].Insert(0, "<b><color=#E0E300>");

            newDiv[indicedeDiv] += "</color></b>";

            div[indicedeDiv] = newDiv[indicedeDiv];

            Debug.Log("La palabra ahora es de " + div[indicedeDiv].Length + "caracteres");


            temporary = null;
            foreach (string parte in div)
            {
                temporary += parte + " ";
            }

            Debug.Log(temporary);

            _tmpTextBox.text = temporary;

            //manager.SetDialogueUI(temporary);

            Debug.Log(TMP_TextUtilities.FindIntersectingWord(_tmpTextBox, mousePosition, _cameraToUse));
        }

        if (linkTaggedText != -1)
        {

            TMP_LinkInfo linkInfo = _tmpTextBox.textInfo.linkInfo[linkTaggedText];



            OnClickOnLinkEvent?.Invoke(keyword: linkInfo.GetLinkText());
        }




    }
    private void Awake()
    {
        resetOriginal();
        manager = DialogueManager.DialogueManagerinstance;
        _tmpTextBox = GetComponent<TMP_Text>();
        _canvasToCheck = GetComponentInParent<Canvas>();
        if (_canvasToCheck.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            _cameraToUse = null;
        }
        else
        {
            _cameraToUse = Camera.main;
        }

    }

    public void resetOriginal()
    {

        original = null;

    }

    public void deselectWord()
    {
        if(original != null)_tmpTextBox.text = original;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
