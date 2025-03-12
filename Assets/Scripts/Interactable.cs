using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Objects objeto;

    public float radius = 3f;
    public Transform interactionTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objeto = GetComponent<Objects>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Interact()
    {
        Debug.Log("Interactuando con " + objeto);
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

}
