using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {



	// Update is called once per frame
	void Update () {
        if (GeneratorSettings.tiles.Count > 0) {

            Vector3 avgPos = new Vector3();

            foreach (GameObject tile in GeneratorSettings.tiles)
                avgPos += tile.transform.position;

            avgPos /= GeneratorSettings.tiles.Count;

            this.transform.position = new Vector3(avgPos.x, transform.position.y, avgPos.z + 100);
        }
	}
}
