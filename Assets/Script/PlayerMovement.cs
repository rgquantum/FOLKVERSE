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
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        role = GetComponent<RoleChecker>();
        view = GetComponent<PhotonView>();

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
        if (view.IsMine)
        {
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
        {
            return;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

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
