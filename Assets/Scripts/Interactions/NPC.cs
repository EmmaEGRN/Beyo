using UnityEngine;

public class NPC : Interactable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public NPCLayout info;
    public Dialogue dialogue1;
    public Dialogue dialogue2;
    public Dialogue dialogue3;
    public Collider trigger;
    public GameObject exclamacion;

    DialogueManager dialogueManager;

    Inventory inventory;


    void Start()
    {
        exclamacion.SetActive(true);
        dialogueManager = DialogueManager.DialogueManagerinstance ;
        info.hasMission = true;
        trigger.enabled = true;
        inventory = Inventory.instance;
        //inventory.OnItemChangedCallBack += EnableCollider;

        for (int i = 0; i < dialogue1.sentences.Length; i++)
        {
            dialogue1.Messages[i].sentence = null;
        }

        for (int i = 0; i < dialogue1.sentences.Length; i++)
        {
            Sentences theSentence = dialogue1.sentences[i];
            for (int j = 0; j < theSentence.palabras.Length; j++)
            {
                dialogue1.Messages[i].sentence = dialogue1.Messages[i].sentence + theSentence.palabras[j].Parlabra + " ";
            }

                //
        }

        for (int i = 0; i < dialogue2.sentences.Length; i++)
        {
            Sentences theSentence = dialogue2.sentences[i];
            for (int j = 0; j < theSentence.palabras.Length; j++)
            {
                dialogue2.Messages[i].sentence = dialogue2.Messages[i].sentence + theSentence.palabras[j].Parlabra + " ";
            }   //
        }
        for (int i = 0; i < dialogue3.sentences.Length; i++)
        {
            Sentences theSentence = dialogue3.sentences[i];
            for (int j = 0; j < theSentence.palabras.Length; j++)
            {
                dialogue3.Messages[i].sentence = dialogue3.Messages[i].sentence + theSentence.palabras[j].Parlabra + " ";
            }

            //
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    private void OnTriggerEnter (Collider other)
    {

        if (other.gameObject.CompareTag("Player") == true)
        {
            Debug.Log("Entró");
            Interact();
            trigger.enabled = false;

        }
    }


    void EnableCollider()
    {
        trigger.enabled = true;
    }
    */

    public override void Interact()
    {
        Conversar(info.mision);

        //Debug.Log(info.mision.ToString());
    }

    public void sendMision()
    {
        MissionSet.MissionInstance.Add(info.mision);
        dialogueManager.onDialogueFinishedcallback -= sendMision;

    }

    public void Conversar(Objects mision)
    {
        if (info.hasMission == true)
        {
            exclamacion.SetActive(false);
            DialogueManager.DialogueManagerinstance.StartDialogue(dialogue1);
            Debug.Log("in k'áat ja'");
            info.hasMission = false;
            dialogueManager.onDialogueFinishedcallback += sendMision;

        }

        else
        {
            if (Inventory.instance.objetos.Contains(mision))
            {
                DialogueManager.DialogueManagerinstance.StartDialogue(dialogue3);

                Debug.Log("Níib Oolal");
                Inventory.instance.Remove(mision);

            }
            else
            {
                DialogueManager.DialogueManagerinstance.StartDialogue(dialogue2);
                Debug.Log("Ma");
            }

        }
        //El
    }


}
