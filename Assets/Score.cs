using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
    public Text text;
    public static int rows = 0;

	// Use this for initialization
	void Start () {
        text.text = "Score :\nRows :"; //\nLevel:
    }
	
	// Update is called once per frame
	void Update () {
        /*if (Grid.lvl>=9)
        {
            Grid.lvl = 9;
        }
        else
        {
            Grid.lvl = Grid.score / 1000;
        }*/
        text.text = "Score :" + Grid.score + "\nRows :" + rows;
    }
}
