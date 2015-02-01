using UnityEngine;
using System.Collections;

public class FieldCollider : MonoBehaviour {

	public GameObject drone;
	public GameObject theController;
	bool outOfGame;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (gameObject.name == "Field_Player_One" || gameObject.name == "Field_Player_Two" ) {
			theController.GetComponent<GameController>().outofGame = true;
				}
		drone.GetComponent<Rotator>().flyBack = true;
	}
	void OnTriggerExit(Collider other) {
		drone.GetComponent<Rotator>().flyBack = true;
		theController.GetComponent<GameController>().outofGame = false;
	}
}