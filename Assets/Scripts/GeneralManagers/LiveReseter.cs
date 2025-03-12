using UnityEngine;

public class LiveReseter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] InfoNivel infoNivel;


    void Start()
    {
        infoNivel.numeroDeVidas = infoNivel.numeroDefault;
        LiveManager.instance.SetAllInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
