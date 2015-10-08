using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public Transform explosion;
    public int scoreValue;
	public AudioClip boom;
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

    void OnTriggerEnter(Collider other)
    {
		Debug.Log ("colided");
        if (other.tag == "Boundary" || other.tag == "Alien")
        {
            return;
        }

		GetComponent<AudioSource>().PlayOneShot (boom, 1F);

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
			Debug.Log ("boom");
        }

        if (other.tag == "Player")
        {
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue);
        //Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
