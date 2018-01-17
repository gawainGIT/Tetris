using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Statistic : MonoBehaviour {
    public Text text;

    // Use this for initialization
    void Start () {
        text.text = "I\t\t\t\t0\n" +
                    "J\t\t\t\t0\n" +
                    "L\t\t\t\t0\n" +
                    "O\t\t\t\t0\n" +
                    "S\t\t\t\t0\n" +
                    "T\t\t\t\t0\n" +
                    "Z\t\t\t\t0\n" +
                    "SUM\t\t0";
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "I\t\t\t\t" + Spawner.num_I +
                    "\nJ\t\t\t\t" + Spawner.num_J +
                    "\nL\t\t\t\t" + Spawner.num_L +
                    "\nO\t\t\t\t" + Spawner.num_O +
                    "\nS\t\t\t\t" + Spawner.num_S +
                    "\nT\t\t\t\t" + Spawner.num_T +
                    "\nZ\t\t\t\t" + Spawner.num_Z +
                    "\nSUM\t\t" + Spawner.sum;
    }
}
