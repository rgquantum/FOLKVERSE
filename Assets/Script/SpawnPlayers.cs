using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;   

public class SpawnPlayers : MonoBehaviour
{
    
    public GameObject playerPrefabs;
    
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

<<<<<<< HEAD

    [PunRPC]
    // Start is called before the first frame update
    private void Start()
    {   



        if(PlayerMovement.LocalPlayerInstance == null)
        {
            Vector2 randomposition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            PhotonNetwork.Instantiate(playerPrefabs.name, randomposition, Quaternion.identity);
            Debug.Log("spawned players");
        }
        else
        {
            GameObject.FindWithTag("Player").transform.position = this.gameObject.transform.position;
        }

        
        
=======
    [PunRPC]

    // Start is called before the first frame update
    private void Start()
    {
        Vector2 randomposition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            PhotonNetwork.Instantiate(playerPrefabs.name, randomposition, Quaternion.identity);
        PhotonNetwork.AutomaticallySyncScene = true;
>>>>>>> 6a0f473b4aeb728855036f379d69a2cf233d26bb
    }

    // Update is called once per frame
    void Update()   
    {
        
    }

<<<<<<< HEAD
    void Awake()
    {

    }


    void SpawnOther()
    {

    }


    

=======
>>>>>>> 6a0f473b4aeb728855036f379d69a2cf233d26bb

}
