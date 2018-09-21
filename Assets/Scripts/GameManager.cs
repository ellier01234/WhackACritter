using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> critterPrefabs;
    public float critterSpawnFreqency = 1.0f;
    public Score scoreDisplay;
    public Timer timer;
    public SpriteRenderer button; 

    private float lastCritterSpawn = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // check if its time to spawn the next critter
        float nextSpawnTime = lastCritterSpawn + critterSpawnFreqency;
        if (Time.time >= nextSpawnTime && timer.IsTimerRunning() == true)
        {
            // it is time! 
            int critterIndex = Random.Range(0, critterPrefabs.Count);
            GameObject prefabToSpawn = critterPrefabs[critterIndex];

            // spawn the critter!
            GameObject spawnedCritter = Instantiate(prefabToSpawn);

            // get access to our Critter script
            Critter critterScript = spawnedCritter.GetComponent<Critter>();

            // tell the critter script the score and timer  object 
            critterScript.scoreDisplay = scoreDisplay;
            critterScript.timer = timer;
           
            // update the most recent critter spawn to now 
            lastCritterSpawn = Time.time;
        }

        // update button visibility 
        if (timer.IsTimerRunning() == true)
        {
            button.enabled = false;
        }
        else  // if game is NOT running
        {
            button.enabled = true;
        }
	}

    private void OnMouseDown()
    {
        // only respond if game is not running
       if (timer.IsTimerRunning() == false)
        {
            timer.StartTimer();
            scoreDisplay.ResetScore();
        }
    }

}
