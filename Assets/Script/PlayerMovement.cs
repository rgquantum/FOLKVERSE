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

    public RoleChecker role;
    public bool Teacher = false;

    public JoystickMovement joystickMovement;
    
    public static GameObject LocalPlayerInstance;

    PhotonView view;

    void Start()
    {
<<<<<<< HEAD
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        role = GetComponent<RoleChecker>();
        view = GetComponent<PhotonView>();
=======

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
>>>>>>> 6a0f473b4aeb728855036f379d69a2cf233d26bb

        CameraWork _cameraWork = GetComponent<CameraWork>();

        if (_cameraWork != null && view.IsMine)
        {
            _cameraWork.OnStartFollowing();
        }
    }

    void Update()
    {
        if (view.IsMine)
        {
<<<<<<< HEAD
            // Unity Input System
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // Joystick Input
            if (joystickMovement != null)
            {
                movement = joystickMovement.joystickVec;
            }
        }

        if (!view.IsMine)
=======
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        }

        if(!view.IsMine)
>>>>>>> 6a0f473b4aeb728855036f379d69a2cf233d26bb
        {
            return;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
<<<<<<< HEAD
=======
        
        // input
        
>>>>>>> 6a0f473b4aeb728855036f379d69a2cf233d26bb

        Teacher = role;
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "TPStory")
        {
            if (Teacher)
            {
                view.RPC("RPC_TPStory", RpcTarget.All);
                Debug.Log("Teleporting to Story Room");
            }
        }

        if (other.gameObject.name == "TPLobby")
        {
            if (Teacher)
            {
                view.RPC("RPC_TPLobby", RpcTarget.All);
                Debug.Log("Teleporting to Lobby");
            }
        }
    }

    [PunRPC]
    void RPC_TPStory()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel("STORY ROOM");
    }

    [PunRPC]
    void RPC_TPLobby()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel("NEW LOBBY");
    }
}
