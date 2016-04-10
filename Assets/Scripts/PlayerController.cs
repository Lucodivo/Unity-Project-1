using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // when variable is public, we can make all the changes in the editor
    public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	// called on the first frame the script is active
	void Start() {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	// Update is called before rendering a frame
	void Update () {
	}

	// called just before calling any physics calculations
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	// called by unity when our object first enters a trigger collider
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText () {
		countText.text = "Count: " + count.ToString ();
		if(count >= 10) {
			winText.text = "You Win!";
		}
	}
}