using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public GameObject theController;
	public AudioClip startSound;
	public Transform playerOne;
	public Transform playerTwo;
	public Transform startPoint;
	public float distance;
	public float speed;
	public float maxSpeed;
	Vector3 direction;

	bool willCatch;
	public bool flyBack;
	bool reachedStart;


	void start(){
		willCatch = false;
		flyBack = false;
		reachedStart = false;
	}

	void Update(){
		transform.up = startPoint.transform.up;
		transform.forward = direction;
		if (direction.magnitude < distance && !flyBack) {
			transform.position += transform.right * speed;
		} else {
			transform.position += transform.forward * speed;
		}

		if (Input.GetButton ("Fire1") || Input.GetButton ("Fire2")) {
			willCatch = true;
		} else {
			willCatch = false;
		}

		if (willCatch && speed >= maxSpeed) {
			speed += 0.01f;
		} else if (!willCatch && speed >= maxSpeed) {
			speed = maxSpeed;
		}

		if (flyBack) {
			transform.rotation = Quaternion.identity;
			print(flyBack);
			if (reachedStart){
				transform.position = startPoint.transform.position;
				transform.rotation = Quaternion.identity;
			}
			else{
				direction = startPoint.transform.position - transform.position;
			}
		}
		if (flyBack && transform.position == startPoint.position && Input.GetKey ("space")) {
			flyBack = false;
			theController.audio.PlayOneShot(startSound);
			if (theController.GetComponent<GameController> ().thePlayerTwoLast == true){
				direction = playerOne.transform.position - transform.position;
			}
			if (theController.GetComponent<GameController> ().theplayerOneLast == true){
				direction = playerTwo.transform.position - transform.position;
			}

			theController.GetComponent<GameController>().theplayerOneLast = false;
			theController.GetComponent<GameController>().thePlayerTwoLast = false;
			reachedStart = false;
		}
	}

	void OnTriggerStay(Collider other) {
		if (willCatch == true && Input.GetButton ("Fire1") && other.gameObject.name == "Player_1"){
			direction = other.transform.position - transform.position;
			theController.GetComponent<GameController>().theplayerOneLast = true;
			theController.GetComponent<GameController>().thePlayerTwoLast = false;
		}
		if (willCatch == true && Input.GetButton ("Fire2") && other.gameObject.name == "Player_2"){
			direction = other.transform.position - transform.position;
			theController.GetComponent<GameController>().thePlayerTwoLast = true;
			theController.GetComponent<GameController>().theplayerOneLast = false;
		}
		if (other.gameObject.name == "StartPoint" && flyBack){
		    reachedStart = true;
		}
	}
}
