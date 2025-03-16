using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordPanelSetter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vocabulario palabraDelPanel;
    [SerializeField]Image imagenDeEjemplo;
    [SerializeField] TMP_Text palabra;
    [SerializeField] TMP_Text traduccion;


    void Start()
    {

    }

    public void setWords(Vocabulario word)
    {
        palabraDelPanel = word;

        setContent();
    }

    public void setContent()
    {
        imagenDeEjemplo.sprite = palabraDelPanel.imagen;
        palabra.text = palabraDelPanel.PalabraRaw; ;
        traduccion.text = palabraDelPanel.Traducción;
    }
}
