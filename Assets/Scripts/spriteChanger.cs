using UnityEngine;
using UnityEngine.UI;

public class spriteChanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Sprite neutral;
    public Sprite good;
    public Sprite bad;
    public Image imagen;
    private void Start()
    {
        imagen = GetComponent<Image>();
    }

    public void SetAsGood()
    {
        imagen.sprite = good;
    }

    public void SetAsFalse()
    {
        imagen.sprite = bad;
    }

}
