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
		if (gameObject.name == "Field_Player_One" || gameObject.name == "Field_Player_Two" || gameObject.name != "StartPoint" ) {
			theController.GetComponent<GameController>().outofGame = true;
		}
		if (gameObject.name == "StartPoint" || gameObject.name == "Player_One_Last" || gameObject.name == "Player_Two_Last" && drone.GetComponent<Rotator> ().flyBack == false) {
						drone.GetComponent<Rotator> ().flyBack = false;
				} else {
			drone.GetComponent<Rotator> ().flyBack = true;
				}
		if (gameObject.name == "Player_One_Last" && drone.GetComponent<Rotator> ().flyBack == true) {
						theController.GetComponent<GameController> ().theplayerOneLast = false;
						theController.GetComponent<GameController> ().thePlayerTwoLast = true;
				}
		if (gameObject.name == "Player_Two_Last" && drone.GetComponent<Rotator> ().flyBack == true) {
			theController.GetComponent<GameController> ().theplayerOneLast = true;
			theController.GetComponent<GameController> ().thePlayerTwoLast = false;
		}
	}
	void OnTriggerExit(Collider other) {
			//drone.GetComponent<Rotator>().flyBack = true;
			theController.GetComponent<GameController>().outofGame = false;
	}
}