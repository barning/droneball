using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	

	int playerOneCounter;
	int playerTwoCounter;

	private float fireRate = 0.5F;
	private float nextFire = 0.0F;

	public GameObject theCanvas;
	public GameObject PlayerOne;
	public GameObject PlayerTwo;

	TextMesh playerOneText;
	TextMesh playerTwoText;

	public bool theplayerOneLast;
	public bool thePlayerTwoLast;
	public bool outofGame;
	// Use this for initialization
	void Start () {
		playerOneText = PlayerOne.transform.FindChild("TextOne").gameObject.GetComponent<TextMesh>();
		playerTwoText = PlayerTwo.transform.FindChild("TextTwo").gameObject.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		if (theplayerOneLast && outofGame && Time.time > nextFire) {
			playerOneCounter++;
			nextFire = Time.time + fireRate;
			playerOneText.text = "Score: "+playerOneCounter;
			//thePlayerTwoLast = false;

		}
		if (thePlayerTwoLast && outofGame && Time.time > nextFire) {
			playerTwoCounter++;
			playerTwoText.text = "Score: "+playerTwoCounter;
			nextFire = Time.time + fireRate;
			//theplayerOneLast = false;
		}
	}
}
