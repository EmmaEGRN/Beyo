using UnityEngine;

public class worldFollow : MonoBehaviour
{
    [SerializeField] public Transform LookAt;
    [SerializeField] public Vector3 offset;

    [Header("Logic")]
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
     Vector3 pos = cam.WorldToScreenPoint(LookAt.position + offset);
        
        if (transform.position != pos) transform.position = pos;
    }
}
