using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviourPunCallbacks
{

    public InputField createInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }



    public override void OnJoinedRoom()
    {
<<<<<<< HEAD
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("NEW LOBBY");
        }
        
=======
        PhotonNetwork.LoadLevel("NEW LOBBY");
>>>>>>> 6a0f473b4aeb728855036f379d69a2cf233d26bb
    }
}
