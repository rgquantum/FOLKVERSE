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

    [PunRPC]

    // Start is called before the first frame update
    private void Start()
    {
        Vector2 randomposition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            PhotonNetwork.Instantiate(playerPrefabs.name, randomposition, Quaternion.identity);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Update is called once per frame
    void Update()   
    {
        
    }


}
