using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 12f;
	public GameObject theController;
	public AudioClip theHit;

	void Start () {

	}

	void FixedUpdate () {
		if (Input.GetButton ("Fire1")== false) {
			transform.position += transform.right *Input.GetAxis("Horizontal")* speed * Time.deltaTime;
			transform.position += transform.forward *Input.GetAxis("Vertical")* speed * Time.deltaTime;

		}
		if (Input.GetButtonUp ("Fire1")) {
			theController.audio.PlayOneShot(theHit);
		}
	}

}
