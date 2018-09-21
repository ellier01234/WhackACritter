using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> critterPrefabs;
    public float critterSpawnFreqency = 1.0f;
    public Score scoreDisplay;

    private float lastCritterSpawn = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // check if its time to spawn the next critter
        float nextSpawnTime = lastCritterSpawn + critterSpawnFreqency;
        if (Time.time >= lastCritterSpawn + critterSpawnFreqency)
        {
            // it is time! 
            int critterIndex = Random.Range(0, critterPrefabs.Count);
            GameObject prefabToSpawn = critterPrefabs[critterIndex];

            // spawn the critter!
            GameObject spawnedCritter = Instantiate(prefabToSpawn);

            // get access to our Critter script
            Critter critterScript = spawnedCritter.GetComponent<Critter>();

            // tell the critter script the score object 
            critterScript.scoreDisplay = scoreDisplay;

            // update the most recent critter spawn to now 
            lastCritterSpawn = Time.time;

        }
	}
}
