using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class IconController : MonoBehaviour
{

    [SerializeField] Image missionImage;
    [SerializeField] Image card;
    [SerializeField] GameObject receta;
    [SerializeField] Sprite misionCardNonCollected;
    [SerializeField] Sprite misionCardCollected;
    private Objects currentMission;

    private void Start()
    {
        MissionSet.MissionInstance.OnMissionChangedCallBack += SetMissionImage;
        card.gameObject.SetActive(false);
    }

    public void SetMissionImage(Objects mision)
    {
        card.gameObject.SetActive(true);
        card.sprite = misionCardNonCollected;
        currentMission = mision;
        missionImage.sprite = currentMission.disabledIcon;
    }

    public void AddItem()
    {
        Debug.Log("a�adiendo el ITem");
        card.sprite = misionCardCollected;
        missionImage.sprite = currentMission.icon;

    }


}
