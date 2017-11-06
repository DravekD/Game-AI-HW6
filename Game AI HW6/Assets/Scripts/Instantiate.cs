using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Instantiate : MonoBehaviour {
    private string map1 = "Assets/Maps/arena2.map";
    private string map2 = "Assets/Maps/hrt201n.map";
    private string type;
    private uint height;
    private uint width;
    public Transform oob;
    public Transform tree;
    public Transform floor;

	// Use this for initialization
	void Start ()
    {
        //Set the default screen resolution.
        Screen.SetResolution(1024, 768, false);

        //Verify the path is valid.
        if (!(File.Exists(map1)))
        {
            Debug.LogError("Invalid Path for Map 1");
        }
        if (!(File.Exists(map2)))
        {
            Debug.LogError("Invalid Path for Map 2");
        }

        //Read in the file and get the basic information.
        StreamReader reader = new StreamReader(map1);
        string line = reader.ReadLine();
        int space = line.IndexOf(" ");
        type = line.Substring(space + 1);
        line = reader.ReadLine();
        space = line.IndexOf(" ");
        height = Convert.ToUInt32(line.Substring(space + 1));
        line = reader.ReadLine();
        space = line.IndexOf(" ");
        width = Convert.ToUInt32(line.Substring(space + 1));
        reader.ReadLine();

        //Generate the 2D array of map data.
        Int32[][] map = new Int32[height][];
        for (int k=0; k<height; k++)
        {
            map[k] = new Int32[width];
        }
        Int32 c;
        int i = 0;
        int j = 0;
        while ((c = reader.Read()) >= 0)
        {
            if (c != 13 && c != 10)
            {
                map[i][j] = c;
                j++;
            }
            else
            {
                i++;
                j = 0;
                reader.Read();
            }
        }

        //Generate the map using the data.
        //@ = 64, T = 84, . = 46
        for (int a = -24; a < height - 24; a++)
        {
            for (int b = -10; b < width - 10; b++)
            {
                int y = a + 24;
                int x = b + 10;
                Vector3 loc = new Vector3(((x - 24f) * 0.5f + 0.25f), ((y - 10f) * -0.5f - 0.25f), 0);
                if (map[y][x] == 64)
                {
                    Instantiate(oob, loc, Quaternion.identity);
                }
                else if (map[y][x] == 84)
                {
                    Instantiate(tree, loc, Quaternion.identity);
                }
                else if (map[y][x] == 46)
                {
                    Instantiate(floor, loc, Quaternion.identity);
                }
                else if (map[y][x] == 0)
                {
                    //Ignore
                }
                else
                {
                    Debug.Log("Invalid map character");
                    Debug.Log(map[y][x]);
                    Debug.Log(a);
                    Debug.Log(b);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
