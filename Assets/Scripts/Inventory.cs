using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Instance of Inventory found!");
            return;

        }
        instance = this;
    }

    #endregion

    public Image icon;

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;



    public int space = 1;

    public List<Objects> objetos = new List<Objects>();

    private void Start()
    {
    }
    public bool Add(Objects objeto)
    {

        if (objetos.Count >= space)
        {
            Debug.Log("Not enough room");
            return false;
        }
        objetos.Add(objeto);

        if (OnItemChangedCallBack != null)
        {
            OnItemChangedCallBack.Invoke();
        }
        return true;


    }
    public void Remove(Objects objeto)
    {

        objetos.Remove(objeto);

        if (OnItemChangedCallBack != null)
        {
            OnItemChangedCallBack.Invoke();
        }
    }

}
