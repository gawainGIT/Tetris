using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour {
    float lastFall = 0;
    //float falltime = 0.05f * (10 - Grid.lvl);
    float[] falltime = { 0.451f, 0.187f, 0.143f, 0.121f, 0.106f, 0.096f, 0.088f, 0.082f, 0.077f, 0.073f, 0.069f, 0.066f, 0.063f, 0.061f, 0.059f, 0.057f, 0.055f, 0.054f, 0.052f, 0.051f };
    public static int i = 0;
    public static bool flaggo = false;

    bool IsValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.RoundVec2(child.position);

            if (!Grid.InsideBorder(v))
                return false;

            if (Grid.grid[(int)v.x, (int)v.y] != null && Grid.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }

    void UpdateGrid()
    {
        for (int y = 0; y < Grid.h; ++y)
            for (int x = 0; x < Grid.w; ++x)
                if (Grid.grid[x, y] != null)
                    if (Grid.grid[x, y].parent == transform)
                        Grid.grid[x, y] = null;

        foreach(Transform child in transform)
        {
            Vector2 v = Grid.RoundVec2(child.position);
            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }

	// Use this for initialization
	void Start () {
        // Default position not valid? Then it's game over
        if (!IsValidGridPos())
        {
            Debug.Log("GAME OVER");
            flaggo = true;
            Destroy(gameObject);            
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            transform.position += new Vector3(-1, 0, 0);
            if (IsValidGridPos())
                UpdateGrid();
            else
                transform.position += new Vector3(1, 0, 0);
        }
        // Move Right
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Modify position
            transform.position += new Vector3(1, 0, 0);
            // See if valid
            if (IsValidGridPos())
                // It's valid. Update grid.
                UpdateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(-1, 0, 0);
        }
        // Rotate
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);

            // See if valid
            if (IsValidGridPos())
                // It's valid. Update grid.
                UpdateGrid();
            else
                // It's not valid. revert.
                transform.Rotate(0, 0, 90);
        }
        // Fall
        else if (Input.GetKeyUp(KeyCode.DownArrow)||Time.time - lastFall >= 3 * falltime[i])
        {
            // Modify position
            transform.position += new Vector3(0, -1, 0);

            // See if valid
            if (IsValidGridPos())
            {
                // It's valid. Update grid.
                UpdateGrid();
            }
            else
            {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);
 
                // Clear filled horizontal lines
                Grid.DeleteFullRows();

                // Spawn next Group
                FindObjectOfType<Spawner>().SpawnNext();
                
                // Disable script
                enabled = false;
            }
            lastFall = Time.time;
            i++;
        }
    }
}
