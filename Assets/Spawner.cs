using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public GameObject[] groups;
    public static int num_I = 0, num_O = 0, num_S = 0, num_Z = 0, num_L = 0, num_J = 0, num_T = 0, sum = 0;

    public void SpawnNext() {
        int i = Random.Range(0, groups.Length);
        switch (i)
        {
            case 0:
                num_I++;
                break;
            case 1:
                num_J++;
                break;
            case 2:
                num_L++;
                break;
            case 3:
                num_O++;
                break;
            case 4:
                num_S++;
                break;
            case 5:
                num_T++;
                break;
            case 6:
                num_Z++;
                break;
            default:
                break;
        }
        Group.i = 0;
        Instantiate(groups[i], transform.position, Quaternion.identity);
        sum++;
    }

	// Use this for initialization
	void Start () {
        SpawnNext();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
