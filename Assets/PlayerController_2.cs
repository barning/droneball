using UnityEngine;
using System.Collections;

public class PlayerController_2 : MonoBehaviour {

	public float speed = 12;
	public AudioClip theHit;

	public GameObject theController;

	void Start () {
	}
	
	void FixedUpdate () {
		if (Input.GetButton ("Fire2")== false) {
			transform.position += transform.right *Input.GetAxis("Horizontal_2")* speed * Time.deltaTime;
			transform.position += transform.forward *Input.GetAxis("Vertical_2")* speed * Time.deltaTime;
		}
		if (Input.GetButtonUp ("Fire2")) {
			theController.audio.PlayOneShot(theHit);
				}
	}
}
