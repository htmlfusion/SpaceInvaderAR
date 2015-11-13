using UnityEngine;
using System.Collections;

public class OnImpact : MonoBehaviour {
	
	public int scoreValue;
	private GameController gameController;
	
	
	void Start()
	{
		// Go and grab the gamecontroller object
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}
	}
	
	void Update() {
	}
	
	void OnCollisionEnter(Collision other)
	{

		GetComponent<AudioSource> ().Play ();

		Debug.Log ("Collision blue");
		gameController.AddScore(scoreValue);
		//Destroy(other.gameObject);
		//Destroy(gameObject);
	}
}
