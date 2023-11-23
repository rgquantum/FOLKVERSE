using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;   

public class SpawnPlayers : MonoBehaviourPunCallbacks
{

    public GameObject playerPrefabs;
    

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    private void Start()
    {
        Vector2 randomposition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        playerPrefabs = PhotonNetwork.Instantiate(playerPrefabs.name, randomposition, Quaternion.identity);
        MultiplayerCamera cameraScript = playerPrefabs.GetComponentInChildren<MultiplayerCamera>();
        if(cameraScript != null)
        {
            cameraScript.gameObject.SetActive(true);
            cameraScript.target = playerPrefabs.transform;
            cameraScript.targetPhotonView = playerPrefabs.GetComponent<PhotonView>();
        }
        
    }

    // Update is called once per frame
    void Update()   
    {
        
    }
}
