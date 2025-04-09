using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Image icon;
    public Objects item;
    Inventory inventory;
    MissionSet missionSet;
    public Sprite misionCardNonCollected;
    public Sprite misionCardCollected;
    public GameObject missionPanel;
    public Image missionCard;
    public GameObject endScreen;
    public DialogueManager dialogueManager;

    [SerializeField] UnityEvent update;

    private void Start()
    {
        dialogueManager = DialogueManager.DialogueManagerinstance;
        endScreen.SetActive(false);
        //missionPanel.SetActive(false);
        missionSet = MissionSet.MissionInstance;
        missionSet.OnMissionChangedCallBack += SlotAppear;
        inventory = Inventory.instance;
        inventory.OnItemChangedCallBack += UpdateUI;

        
        //missionSet.OnMissionAccomplishedCallBack += endScreenShow;

    }

    public void endScreenShow()
    {
        endScreen.SetActive(true);
        FindAnyObjectByType<AudioManager>().Play("Achievement");
    }


    public void SlotAppear(Objects newItem)
    {
        item = newItem;
    }

    public void AddItem(Objects newItem)
    {
        missionCard.sprite = misionCardCollected;
        icon.sprite = item.icon;

    }

    public void ClearSlot()
    {

        missionPanel.SetActive(false);
        item = null;
        icon.sprite = null;

    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
        update.Invoke();
        if (inventory.objetos.Contains(item))
        {
            Debug.Log("El objeto sí está en el inventario");
        }
        else
        {
            ClearSlot();
            dialogueManager.onDialogueFinishedcallback += endScreenShow;
        }
    }
}
