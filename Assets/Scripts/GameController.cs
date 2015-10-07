using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject[] aliens;
    public Vector3 spawnValues;
    public int alienRows;
    public int alienLines;
    //public float spawnWait;
    public float startWait;
    public float waveWait;
    public int rowSpace;
    //public GUIText scoreText;
    //public GUIText restartText;
    // public GUIText gameOverText;


    private bool gameOver;
    private bool restart;
    private int score;

    void Start()
    {
        gameOver = false;
        restart = false;
        //restartText.text = "";
        //gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            GameObject alien = aliens[Random.Range(0, aliens.Length)];
            for (int y = 0; y < alienLines; y++)
            {
                for (int i = 0; i < alienRows; i++)
                {                  
                    Vector3 spawnPosition = new Vector3(spawnValues.x + i * rowSpace, spawnValues.y + y * rowSpace, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.Euler(0, 90, 0);
                    //alien.transform.position = new Vector3(spawnValues.x + i * rowSpace, spawnValues.y + y * rowSpace, spawnValues.z);
                    //alien.GetComponent<Rigidbody>().velocity = transform.forward * alienSpeed;
                    Instantiate(alien, spawnPosition, spawnRotation);

                   // yield return new WaitForSeconds(spawnWait);
                }
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                //restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newscore)
    {

    }
    void UpdateScore()
    {

    }
    public void GameOver()
    {

    }
}
