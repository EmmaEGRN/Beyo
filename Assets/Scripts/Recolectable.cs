using System;
using UnityEngine;

public class Recolectable : Interactable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        Collect();
    }

    public void Collect()
    {

        FindAnyObjectByType<AudioManager>().Play("Achievement");


        Debug.Log("Picking up " + objeto.name);

        bool isMision = MissionSet.MissionInstance.Check(objeto);

        if (isMision)
        {
            bool wasPickedUp = Inventory.instance.Add(objeto);
            if (wasPickedUp)
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);

            };
        }
        else
        {
            //Decierle al jugador que esto no es lo que está buscando
        }
    }
}
