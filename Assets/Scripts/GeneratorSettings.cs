using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorSettings : MonoBehaviour {
    
    public static float straightChance = .5f;
    public static float rightTurnChance = .5f;
    public static float generateChance = 0f;

    public static List<GameObject> tiles = new List<GameObject>();
    public static List<GameObject> generators = new List<GameObject>();

    public Slider straightChanceSlider;
    public Slider rightTurnChanceSlider;
    public Slider generateChanceSlider;

    public Text straightNum;
    public Text rightTurnNum;
    public Text generateNum;

    public GameObject generator;
    

    public void Generate() {
        int tileCount = tiles.Count;

        foreach (GameObject generator in generators)
            Destroy(generator);

        generators.RemoveRange(0, generators.Count);

        for (int i = 0; i < tiles.Count; i++)  {
            GameObject tile = tiles[i];
            Destroy(tile);
        }

  

        tiles.RemoveRange(0, tiles.Count);
        

        Instantiate(generator);
    }

    void Update() {
        
        straightChance = straightChanceSlider.value;
        rightTurnChance = rightTurnChanceSlider.value;
        generateChance = generateChanceSlider.value;

        straightNum.text = "" + straightChanceSlider.value;
        rightTurnNum.text = "" + rightTurnChanceSlider.value;
        generateNum.text = "" + generateChanceSlider.value;
    }
}
