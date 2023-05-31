using UnityEngine;
using Photon.Pun;

public class MultiplayerCamera : MonoBehaviourPun
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public PhotonView targetPhotonView;

    private void LateUpdate()
    {
        if (!photonView.IsMine)
        {
            if (targetPhotonView != null && targetPhotonView.IsMine)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        }
            return;

        
        
    }

}