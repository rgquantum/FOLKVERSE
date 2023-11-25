using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun
{

    public float moveSpeed = 5f;
    private Vector3 targetPosition;

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    Vector2 lastMoveDirection;

    PhotonView view;

    

    void Start()
    {

        view = this.gameObject.GetComponent<PhotonView>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();

        CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();

         if (_cameraWork != null)
        {
            if (photonView.IsMine)
            {
                _cameraWork.OnStartFollowing();
            }
        }


        
    }

     

    void Update()
    {

        if(view.IsMine)
        {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        }

        if(!view.IsMine)
        {
            return;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
        // input
        

        
    }

    void FixedUpdate()
    {
        // movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);  
    }


   
}
