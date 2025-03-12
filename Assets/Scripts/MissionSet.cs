using System.Collections.Generic;
using UnityEngine;

public class MissionSet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    #region Singleton

    public static MissionSet MissionInstance;

    private void Awake()
    {
        if (MissionInstance != null)
        {
            Debug.LogWarning("More than one Instance of MissionSet found!");
            return;

        }
        MissionInstance = this;
    }

    #endregion

    public delegate void OnMissionChanged(Objects mision);
    public OnMissionChanged OnMissionChangedCallBack;
    public delegate void OnMissionAccomplished();
    public OnMissionAccomplished OnMissionAccomplishedCallBack;
    public List<Objects> misiones = new List<Objects>();

    public void Add(Objects mision)
    {
        misiones.Add(mision);
        if (OnMissionChangedCallBack != null)
        {
            OnMissionChangedCallBack.Invoke(mision);
        }


    }
    public void Remove(Objects mision)
    {

        misiones.Remove(mision);
        if (OnMissionAccomplishedCallBack != null)
        {
            OnMissionAccomplishedCallBack.Invoke();
        }

        if (OnMissionChangedCallBack != null)
        {
            OnMissionChangedCallBack.Invoke(mision);
        }

    }

    public bool Check (Objects mision)
    {
        if (!misiones.Contains(mision)) { return false; }
        else
        {
            return true;
        }


    }

}
