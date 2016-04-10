using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Late Update runs every frame but after every movement has been made for the frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
