using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]private Transform player;
    [SerializeField]private float backOffset = 5;
    [SerializeField]private float forwardOffset = 2;
	
    private void Update()
    {
        if (player.position.x > transform.position.x+forwardOffset)
            transform.position = new Vector3(player.position.x-forwardOffset,player.position.y,transform.position.z);

        if (player.position.x < transform.position.x-backOffset)
            transform.position = new Vector3(player.position.x+backOffset,player.position.y,transform.position.z);
    }
}
