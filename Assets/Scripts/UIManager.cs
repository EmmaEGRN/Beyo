using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Image icon;
    public Objects item;
    Inventory inventory;
    MissionSet missionSet;
    public GameObject missionPanel;
    public GameObject endScreen;
    public DialogueManager dialogueManager;


    private void Start()
    {
        dialogueManager = DialogueManager.DialogueManagerinstance;
        endScreen.SetActive(false);
        missionPanel.SetActive(false);
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
        missionPanel.SetActive(true);
        item = newItem;
        icon.sprite = item.disabledIcon;
        //missionPanel

    }

    public void AddItem(Objects newItem)
    {
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
        if (inventory.objetos.Contains(item))
        {
            AddItem(item);
        }
        else
        {
            ClearSlot();
            dialogueManager.onDialogueFinishedcallback += endScreenShow;
        }
    }
}
