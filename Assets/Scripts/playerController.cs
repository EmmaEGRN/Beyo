using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playerController : MonoBehaviour
{
    private CharacterController controller;
    public float playerSpeed = 2.0f;
    public Camera cam;
    [SerializeField] float gravity = 10f;
    public Interactable interactable;
    public Objects mision;
    Collider colider;
    //public int maxRange = 2;
    
    public List<Interactable> targets;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        colider = GetComponent<Collider>();
    }


    void Update()
    {
       
        if (DialogueManager.DialogueManagerinstance.conversationGoingOn)
        {
            return;
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 moveDir = move;
        if (!controller.isGrounded)
        {
            move.y -= gravity * Time.deltaTime;
        }
        Debug.Log(!controller.isGrounded);
        controller.Move(move * Time.deltaTime * playerSpeed);
        
        if (moveDir != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 7f);

        }



        if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                    if (interactable.transform.position.x - transform.position.x < interactable.radius && interactable.transform.position.y - transform.position.y < interactable.radius)
                    {   
                            interactable.Interact();
                            //Debug.Log("Has recogido un objeto");
                            interactable = null;
                        }

                    }
                    }
                }


            }
        }
