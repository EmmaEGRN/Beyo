using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spriteChangerHearts : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public Sprite[] versiones;

    public Image imagen;

    void Start()
    {

    }

    public void ChangeSpecificSprite(int currentSprites)
    {
        imagen.sprite = versiones[currentSprites];
    }

}
