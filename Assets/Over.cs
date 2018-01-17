using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Over : MonoBehaviour {
    public Text text;

    // Use this for initialization
    void Start () {
        text.text = "";
    }
	
	// Update is called once per frame
	void Update () {
	    if(Group.flaggo)
        {
            text.text = "Game Over!";
        }
	}
}
