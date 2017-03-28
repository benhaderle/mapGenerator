using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public GameObject treeTile;
    public GameObject rockTile;
    public GameObject pondTile;
    public GameObject generator;

    int tileCounter;

    float straightChance = .5f;
    float rightTurnChance = .5f;
    float generateChance = 0f;

    void Start() {
        straightChance = GeneratorSettings.straightChance;
        rightTurnChance = GeneratorSettings.rightTurnChance;
        generateChance = GeneratorSettings.generateChance;
    }

    // Update is called once per frame
    void Update () {


        //is there a block already underneath us?
        Ray ray = new Ray(this.transform.position, Vector3.down);
        RaycastHit hit = new RaycastHit();
        
        //if not spawn a big or small tile
        if (!Physics.Raycast(ray, out hit)) {
            GameObject currentTile;

            if (Random.value < .33f)
                currentTile = Instantiate(treeTile, this.transform.position, Quaternion.identity);
            else {
                if(Random.value < .5f)
                    currentTile = Instantiate(rockTile, this.transform.position, Quaternion.identity);
                else
                    currentTile = Instantiate(pondTile, this.transform.position, Quaternion.identity);
            }

            GeneratorSettings.tiles.Add(currentTile);
            tileCounter++;
        }

        //deciding if/how to rotate
        if (Random.value > straightChance) {
            if (Random.value < rightTurnChance)
                transform.Rotate(0, 90f, 0);
            else
                transform.Rotate(0, -90f, 0);
        }

        //moving
        transform.Translate(Vector3.forward * 5f);

        //small chance of spawning another spawner
        if (Random.value < generateChance)
            GeneratorSettings.generators.Add(Instantiate(generator, this.transform.position, Quaternion.identity));

        //if we've spawned 50 tiles on this spawner, stop
        if (tileCounter > 50 || GeneratorSettings.tiles.Count > 1000)
            Destroy(this.gameObject);
    }
}
