using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class cameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    DialogueManager dialogue;
    public Transform player;
    public Vector3 offset;
    public Vector3 regularOffset;

    public Vector3 dialogueCamera;
    public Vector3 originalPosition; 
    public float pitch = 2f;
    public Vector3 originalPitch;
    //public Vector3 newPitch;

    // 0, 10.1, -5.84
    //0, 2.53, 0;
    //5.13, 5.38, 5.84

    void Start()
    {
        //transform.GetComponent<Camera>().orthographic = true;
        dialogue = DialogueManager.DialogueManagerinstance;
        dialogueCamera = new Vector3(-0.64f, 4.82f, -14f);
        regularOffset = offset;
        originalPitch = new Vector3(0f, 0f, 2f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position + offset;
        transform.LookAt(player.position + Vector3.up * originalPitch.z);
        if (dialogue.conversationGoingOn)
        {
            //transform.GetComponent<Camera>().orthographic = false;
            originalPitch = Vector3.Slerp(originalPitch, new Vector3(0f,0f,-1f), 0.05f);
            offset = Vector3.Slerp(offset, dialogueCamera, 0.05f);
        }
        else
        {
            //transform.GetComponent<Camera>().orthographic = true;
            originalPitch = Vector3.Slerp(originalPitch, new Vector3(0f, 0f, 2f), 0.05f); ;
            offset = Vector3.Slerp(offset, regularOffset, 0.05f);
        }
    }
}