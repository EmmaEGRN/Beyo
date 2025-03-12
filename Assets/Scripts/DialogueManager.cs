using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static MissionSet;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    #region Singleton

    public static DialogueManager DialogueManagerinstance;

    private void Awake()
    {
        if (DialogueManagerinstance != null)
        {
            Debug.LogWarning("More than one Instance of Inventory found!");
            return;

        }
        DialogueManagerinstance = this;
    }

    #endregion

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Button next;
    public GameObject Button;
    public GameObject DialoguePanel;
    public Image characterImage;
    
   
    private Queue<message> sentenceInfo;
    private Queue<Sentences> newSentenceInfo;
    private NPCLayout[] currentActors;
    public delegate void OnDialogueFinished();
    public OnDialogueFinished onDialogueFinishedcallback;

    public Boolean conversationGoingOn;
    void Start()
    {
        //ToggleButton();
        DialoguePanel.SetActive(false);

        conversationGoingOn = false;
        //next.interactable = false;
        nameText.text = " ";
        dialogueText.text = " ";
        sentenceInfo = new Queue<message>();
        //newSentenceInfo = new Queue<Sentences>();
       
    }

    public void StartDialogue(Dialogue dialogue)
    {

        DialoguePanel.SetActive(true);
        conversationGoingOn = true;
        sentenceInfo.Clear();

        currentActors = dialogue.actor;

        /*
        foreach (Sentences sentence in dialogue.sentences)
        {
            newSentenceInfo.Enqueue(sentence);
        }*/

        foreach (message message in dialogue.Messages)
        {
            sentenceInfo.Enqueue(message);        
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentenceInfo.Count == 0)
        {
            if(onDialogueFinishedcallback != null)
            {
                onDialogueFinishedcallback.Invoke();
            }
            EndDialogue();
            return;
        }

        message mensaje = sentenceInfo.Dequeue();
        //Sentences elmensaje = newSentenceInfo.Dequeue();

        GameObject current = new GameObject();
        current.AddComponent<TextMeshProUGUI>();

        //TextMeshProUGUI hola = DialoguePanel.AddComponent<TextMeshProUGUI>();
        //hola.text = mensaje.sentence;
        /*
        foreach (Vocabulario vocab in elmensaje.palabras)
        {
            GameObject gameObject = new GameObject("boton");
            gameObject.AddComponent<Button>();
            TextMeshProUGUI hola = gameObject.AddComponent<TextMeshProUGUI>();
            hola.text = "hola";
        }
        */

        FindAnyObjectByType<AudioManager>().Play(mensaje.audio);
        SetDialogueUI(mensaje.sentence);
        nameText.text = currentActors[mensaje.actorId].name;
        characterImage.sprite = currentActors[mensaje.actorId].icon;
    }

    public void SetDialogueUI(string sentence)
    {
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {

        
        conversationGoingOn = false;
        nameText.text = " ";
        dialogueText.text = " ";
        DialoguePanel.SetActive(false);

    }

}
