using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowCamScript : MonoBehaviour
{
    private Player_Controller player;
    private CinemachineVirtualCamera trackedDolly;

    void Start()
    {
        trackedDolly = GetComponent<CinemachineVirtualCamera>();
        player = Player_Controller.instance;
    }

    void Update()
    {
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(player.transform.position);

        if (player != null)
        {
            if (playerScreenPoint.x < Camera.main.pixelWidth / 3 || playerScreenPoint.x > Camera.main.pixelWidth - (Camera.main.pixelWidth / 3))
            {
                trackedDolly.Follow = player.transform;
            }
            else
            {
                trackedDolly.Follow = null;
            }
        }
    }
}
