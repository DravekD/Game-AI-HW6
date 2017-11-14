using System;
using System.IO;
using UnityEngine;

public class Instantiate : MonoBehaviour {
    private string map1 = "Assets/Maps/arena2.map";
    private string map2 = "Assets/Maps/hrt201n.map";
    private string type;
    private uint height;
    private uint width;
    private bool current_map = true;
    private bool[][] adjacency_matrix = new bool[109][];
    private bool[][] adjacency_matrix2 = new bool[319][];
    private Transform[] waypoints = new Transform[109];
    private Transform[] waypoints2 = new Transform[319];
    public Transform oob;
    public Transform tree;
    public Transform floor;
    public Transform waypoint;

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
        StreamReader reader = new StreamReader(map2);
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
            if (j == 0 && i == 0)
            {
                Debug.Log(c);
            }
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
        for (int a = 0; a < height; a++)
        {
            for (int b = 0; b < width; b++)
            {
                int y = a;
                int x = b;
                Vector3 loc = new Vector3((x * 0.5f + 0.25f), (y * -0.5f - 0.25f), 0);
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

        //Initialize the adjacency matrix.
        for (int a=0; a<109; a++)
        {
            adjacency_matrix[a] = new bool[109];
            for (int b=0; b<109; b++)
            {
                adjacency_matrix[a][b] = false;
            }
        }

        //Generate the waypoint map
        if (!current_map)
        {
            waypoints[0] = Instantiate(waypoint, new Vector3(48.5f, -4.5f, 0), Quaternion.identity);
            waypoints[1] = Instantiate(waypoint, new Vector3(56.5f, -4.5f, 0), Quaternion.identity);
            waypoints[2] = Instantiate(waypoint, new Vector3(64.5f, -4.5f, 0), Quaternion.identity);

            waypoints[3] = Instantiate(waypoint, new Vector3(64.5f, -12.5f, 0), Quaternion.identity);

            waypoints[4] = Instantiate(waypoint, new Vector3(48.5f, -20.5f, 0), Quaternion.identity);
            waypoints[5] = Instantiate(waypoint, new Vector3(56.5f, -20.5f, 0), Quaternion.identity);
            waypoints[6] = Instantiate(waypoint, new Vector3(64.5f, -20.5f, 0), Quaternion.identity);
            waypoints[7] = Instantiate(waypoint, new Vector3(72.5f, -20.5f, 0), Quaternion.identity);
            waypoints[8] = Instantiate(waypoint, new Vector3(80.5f, -20.5f, 0), Quaternion.identity);

            waypoints[9] = Instantiate(waypoint, new Vector3(40.5f, -28.5f, 0), Quaternion.identity);
            waypoints[10] = Instantiate(waypoint, new Vector3(48.5f, -28.5f, 0), Quaternion.identity);
            waypoints[11] = Instantiate(waypoint, new Vector3(56.5f, -28.5f, 0), Quaternion.identity);
            waypoints[12] = Instantiate(waypoint, new Vector3(64.5f, -28.5f, 0), Quaternion.identity);
            waypoints[13] = Instantiate(waypoint, new Vector3(72.5f, -28.5f, 0), Quaternion.identity);
            waypoints[14] = Instantiate(waypoint, new Vector3(80.5f, -28.5f, 0), Quaternion.identity);
            waypoints[15] = Instantiate(waypoint, new Vector3(88.5f, -28.5f, 0), Quaternion.identity);

            waypoints[16] = Instantiate(waypoint, new Vector3(40.5f, -36.5f, 0), Quaternion.identity);
            waypoints[17] = Instantiate(waypoint, new Vector3(48.5f, -36.5f, 0), Quaternion.identity);
            waypoints[18] = Instantiate(waypoint, new Vector3(56.5f, -36.5f, 0), Quaternion.identity);
            waypoints[19] = Instantiate(waypoint, new Vector3(64.5f, -36.5f, 0), Quaternion.identity);
            waypoints[20] = Instantiate(waypoint, new Vector3(72.5f, -36.5f, 0), Quaternion.identity);
            waypoints[21] = Instantiate(waypoint, new Vector3(80.5f, -36.5f, 0), Quaternion.identity);
            waypoints[22] = Instantiate(waypoint, new Vector3(88.5f, -36.5f, 0), Quaternion.identity);
            waypoints[23] = Instantiate(waypoint, new Vector3(96.5f, -36.5f, 0), Quaternion.identity);

            waypoints[24] = Instantiate(waypoint, new Vector3(32.5f, -44.5f, 0), Quaternion.identity);
            waypoints[25] = Instantiate(waypoint, new Vector3(40.5f, -44.5f, 0), Quaternion.identity);
            waypoints[26] = Instantiate(waypoint, new Vector3(48.5f, -44.5f, 0), Quaternion.identity);
            waypoints[27] = Instantiate(waypoint, new Vector3(56.5f, -44.5f, 0), Quaternion.identity);
            waypoints[28] = Instantiate(waypoint, new Vector3(64.5f, -44.5f, 0), Quaternion.identity);
            waypoints[29] = Instantiate(waypoint, new Vector3(72.5f, -44.5f, 0), Quaternion.identity);
            waypoints[30] = Instantiate(waypoint, new Vector3(80.5f, -44.5f, 0), Quaternion.identity);
            waypoints[31] = Instantiate(waypoint, new Vector3(88.5f, -44.5f, 0), Quaternion.identity);
            waypoints[32] = Instantiate(waypoint, new Vector3(96.5f, -44.5f, 0), Quaternion.identity);
            waypoints[33] = Instantiate(waypoint, new Vector3(104.5f, -44.5f, 0), Quaternion.identity);

            waypoints[34] = Instantiate(waypoint, new Vector3(0.5f, -52.5f, 0), Quaternion.identity);
            waypoints[35] = Instantiate(waypoint, new Vector3(8.5f, -52.5f, 0), Quaternion.identity);
            waypoints[36] = Instantiate(waypoint, new Vector3(14.5f, -52.5f, 0), Quaternion.identity);

            waypoints[37] = Instantiate(waypoint, new Vector3(16.5f, -50f, 0), Quaternion.identity);
            waypoints[38] = Instantiate(waypoint, new Vector3(19.5f, -50f, 0), Quaternion.identity);

            waypoints[39] = Instantiate(waypoint, new Vector3(24.5f, -52.5f, 0), Quaternion.identity);
            waypoints[40] = Instantiate(waypoint, new Vector3(32.5f, -52.5f, 0), Quaternion.identity);
            waypoints[41] = Instantiate(waypoint, new Vector3(40.5f, -52.5f, 0), Quaternion.identity);
            waypoints[42] = Instantiate(waypoint, new Vector3(48.5f, -52.5f, 0), Quaternion.identity);
            waypoints[43] = Instantiate(waypoint, new Vector3(56.5f, -52.5f, 0), Quaternion.identity);
            waypoints[44] = Instantiate(waypoint, new Vector3(64.5f, -52.5f, 0), Quaternion.identity);
            waypoints[45] = Instantiate(waypoint, new Vector3(72.5f, -52.5f, 0), Quaternion.identity);
            waypoints[46] = Instantiate(waypoint, new Vector3(80.5f, -52.5f, 0), Quaternion.identity);
            waypoints[47] = Instantiate(waypoint, new Vector3(88.5f, -52.5f, 0), Quaternion.identity);
            waypoints[48] = Instantiate(waypoint, new Vector3(96.5f, -52.5f, 0), Quaternion.identity);
            waypoints[49] = Instantiate(waypoint, new Vector3(104.5f, -52.5f, 0), Quaternion.identity);
            waypoints[50] = Instantiate(waypoint, new Vector3(112.5f, -52.5f, 0), Quaternion.identity);
            waypoints[51] = Instantiate(waypoint, new Vector3(116.5f, -52.5f, 0), Quaternion.identity);

            waypoints[52] = Instantiate(waypoint, new Vector3(128.5f, -20.5f, 0), Quaternion.identity);
            waypoints[53] = Instantiate(waypoint, new Vector3(136.5f, -20.5f, 0), Quaternion.identity);
            waypoints[54] = Instantiate(waypoint, new Vector3(120.5f, -28.5f, 0), Quaternion.identity);
            waypoints[55] = Instantiate(waypoint, new Vector3(128.5f, -28.5f, 0), Quaternion.identity);
            waypoints[56] = Instantiate(waypoint, new Vector3(136.5f, -28.5f, 0), Quaternion.identity);
            waypoints[57] = Instantiate(waypoint, new Vector3(120.5f, -36.5f, 0), Quaternion.identity);
            waypoints[58] = Instantiate(waypoint, new Vector3(128.5f, -36.5f, 0), Quaternion.identity);
            waypoints[59] = Instantiate(waypoint, new Vector3(136.5f, -36.5f, 0), Quaternion.identity);
            waypoints[60] = Instantiate(waypoint, new Vector3(128.5f, -44.5f, 0), Quaternion.identity);
            waypoints[61] = Instantiate(waypoint, new Vector3(120.5f, -52.5f, 0), Quaternion.identity);
            waypoints[62] = Instantiate(waypoint, new Vector3(128.5f, -52.5f, 0), Quaternion.identity);
            waypoints[63] = Instantiate(waypoint, new Vector3(128.5f, -60.5f, 0), Quaternion.identity);
            waypoints[64] = Instantiate(waypoint, new Vector3(128.5f, -68.5f, 0), Quaternion.identity);
            waypoints[65] = Instantiate(waypoint, new Vector3(136.5f, -68.5f, 0), Quaternion.identity);
            waypoints[66] = Instantiate(waypoint, new Vector3(112.5f, -76.5f, 0), Quaternion.identity);
            waypoints[67] = Instantiate(waypoint, new Vector3(120.5f, -76.5f, 0), Quaternion.identity);
            waypoints[68] = Instantiate(waypoint, new Vector3(128.5f, -76.5f, 0), Quaternion.identity);
            waypoints[69] = Instantiate(waypoint, new Vector3(136.5f, -76.5f, 0), Quaternion.identity);
            waypoints[70] = Instantiate(waypoint, new Vector3(112.5f, -84.5f, 0), Quaternion.identity);
            waypoints[71] = Instantiate(waypoint, new Vector3(120.5f, -84.5f, 0), Quaternion.identity);

            waypoints[72] = Instantiate(waypoint, new Vector3(112.5f, -92.5f, 0), Quaternion.identity);
            waypoints[73] = Instantiate(waypoint, new Vector3(120.5f, -92.5f, 0), Quaternion.identity);
            waypoints[74] = Instantiate(waypoint, new Vector3(128.5f, -92.5f, 0), Quaternion.identity);
            waypoints[75] = Instantiate(waypoint, new Vector3(136.5f, -92.5f, 0), Quaternion.identity);

            waypoints[76] = Instantiate(waypoint, new Vector3(120.5f, -100.5f, 0), Quaternion.identity);
            waypoints[77] = Instantiate(waypoint, new Vector3(128.5f, -100.5f, 0), Quaternion.identity);
            waypoints[78] = Instantiate(waypoint, new Vector3(136.5f, -100.5f, 0), Quaternion.identity);

            waypoints[79] = Instantiate(waypoint, new Vector3(32.5f, -60.5f, 0), Quaternion.identity);
            waypoints[80] = Instantiate(waypoint, new Vector3(40.5f, -60.5f, 0), Quaternion.identity);
            waypoints[81] = Instantiate(waypoint, new Vector3(48.5f, -60.5f, 0), Quaternion.identity);
            waypoints[82] = Instantiate(waypoint, new Vector3(56.5f, -60.5f, 0), Quaternion.identity);
            waypoints[83] = Instantiate(waypoint, new Vector3(64.5f, -60.5f, 0), Quaternion.identity);
            waypoints[84] = Instantiate(waypoint, new Vector3(72.5f, -60.5f, 0), Quaternion.identity);
            waypoints[85] = Instantiate(waypoint, new Vector3(80.5f, -60.5f, 0), Quaternion.identity);
            waypoints[86] = Instantiate(waypoint, new Vector3(88.5f, -60.5f, 0), Quaternion.identity);
            waypoints[87] = Instantiate(waypoint, new Vector3(96.5f, -60.5f, 0), Quaternion.identity);
            waypoints[88] = Instantiate(waypoint, new Vector3(104.5f, -60.5f, 0), Quaternion.identity);

            waypoints[89] = Instantiate(waypoint, new Vector3(40.5f, -68.5f, 0), Quaternion.identity);
            waypoints[90] = Instantiate(waypoint, new Vector3(48.5f, -68.5f, 0), Quaternion.identity);
            waypoints[91] = Instantiate(waypoint, new Vector3(56.5f, -68.5f, 0), Quaternion.identity);
            waypoints[92] = Instantiate(waypoint, new Vector3(64.5f, -68.5f, 0), Quaternion.identity);
            waypoints[93] = Instantiate(waypoint, new Vector3(72.5f, -68.5f, 0), Quaternion.identity);
            waypoints[94] = Instantiate(waypoint, new Vector3(80.5f, -68.5f, 0), Quaternion.identity);
            waypoints[95] = Instantiate(waypoint, new Vector3(88.5f, -68.5f, 0), Quaternion.identity);
            waypoints[96] = Instantiate(waypoint, new Vector3(96.5f, -68.5f, 0), Quaternion.identity);

            waypoints[97] = Instantiate(waypoint, new Vector3(40.5f, -76.5f, 0), Quaternion.identity);
            waypoints[98] = Instantiate(waypoint, new Vector3(48.5f, -76.5f, 0), Quaternion.identity);
            waypoints[99] = Instantiate(waypoint, new Vector3(56.5f, -76.5f, 0), Quaternion.identity);
            waypoints[100] = Instantiate(waypoint, new Vector3(64.5f, -76.5f, 0), Quaternion.identity);
            waypoints[101] = Instantiate(waypoint, new Vector3(72.5f, -76.5f, 0), Quaternion.identity);
            waypoints[102] = Instantiate(waypoint, new Vector3(80.5f, -76.5f, 0), Quaternion.identity);
            waypoints[103] = Instantiate(waypoint, new Vector3(88.5f, -76.5f, 0), Quaternion.identity);

            waypoints[104] = Instantiate(waypoint, new Vector3(48.5f, -84.5f, 0), Quaternion.identity);
            waypoints[105] = Instantiate(waypoint, new Vector3(56.5f, -84.5f, 0), Quaternion.identity);
            waypoints[106] = Instantiate(waypoint, new Vector3(64.5f, -84.5f, 0), Quaternion.identity);
            waypoints[107] = Instantiate(waypoint, new Vector3(72.5f, -84.5f, 0), Quaternion.identity);
            waypoints[108] = Instantiate(waypoint, new Vector3(80.5f, -84.5f, 0), Quaternion.identity);
        }
        else
        {
            waypoints2[0] = Instantiate(waypoint, new Vector3(17.5f, -8f, 0.0f), Quaternion.identity);
            waypoints2[1] = Instantiate(waypoint, new Vector3(22.5f, -8f, 0.0f), Quaternion.identity);
            waypoints2[2] = Instantiate(waypoint, new Vector3(20f, -15f, 0.0f), Quaternion.identity);
            waypoints2[3] = Instantiate(waypoint, new Vector3(20f, -20f, 0.0f), Quaternion.identity);
            waypoints2[4] = Instantiate(waypoint, new Vector3(17f, -20f, 0.0f), Quaternion.identity);
            waypoints2[5] = Instantiate(waypoint, new Vector3(23f, -20f, 0.0f), Quaternion.identity);
            waypoints2[6] = Instantiate(waypoint, new Vector3(17f, -25f, 0.0f), Quaternion.identity);
            waypoints2[7] = Instantiate(waypoint, new Vector3(17f, -30f, 0.0f), Quaternion.identity);
            waypoints2[8] = Instantiate(waypoint, new Vector3(20f, -25f, 0.0f), Quaternion.identity);
            waypoints2[9] = Instantiate(waypoint, new Vector3(20f, -30f, 0.0f), Quaternion.identity);
            waypoints2[10] = Instantiate(waypoint, new Vector3(23f, -25f, 0.0f), Quaternion.identity);
            waypoints2[11] = Instantiate(waypoint, new Vector3(23f, -30f, 0.0f), Quaternion.identity);
            waypoints2[12] = Instantiate(waypoint, new Vector3(17f, -32.5f, 0.0f), Quaternion.identity);
            waypoints2[13] = Instantiate(waypoint, new Vector3(20f, -32.5f, 0.0f), Quaternion.identity);
            waypoints2[14] = Instantiate(waypoint, new Vector3(23f, -32.5f, 0.0f), Quaternion.identity);
            waypoints2[15] = Instantiate(waypoint, new Vector3(12f, -32.5f, 0.0f), Quaternion.identity);
            waypoints2[16] = Instantiate(waypoint, new Vector3(9f, -32.5f, 0.0f), Quaternion.identity);
            waypoints2[17] = Instantiate(waypoint, new Vector3(4f, -32.5f, 0.0f), Quaternion.identity);
            waypoints2[18] = Instantiate(waypoint, new Vector3(4f, -27.5f, 0.0f), Quaternion.identity);
            waypoints2[19] = Instantiate(waypoint, new Vector3(3f, -37.5f, 0.0f), Quaternion.identity);
            waypoints2[20] = Instantiate(waypoint, new Vector3(9f, -37.5f, 0.0f), Quaternion.identity);
            waypoints2[21] = Instantiate(waypoint, new Vector3(28f, -32.5f, 0.0f), Quaternion.identity);
            waypoints2[22] = Instantiate(waypoint, new Vector3(33f, -32.5f, 0.0f), Quaternion.identity);
            waypoints2[23] = Instantiate(waypoint, new Vector3(33f, -27.5f, 0.0f), Quaternion.identity);
            waypoints2[24] = Instantiate(waypoint, new Vector3(37f, -27.5f, 0.0f), Quaternion.identity);
            waypoints2[25] = Instantiate(waypoint, new Vector3(33f, -37.5f, 0.0f), Quaternion.identity);
            waypoints2[26] = Instantiate(waypoint, new Vector3(37f, -37.5f, 0.0f), Quaternion.identity);
            waypoints2[27] = Instantiate(waypoint, new Vector3(37f, -32.5f, 0.0f), Quaternion.identity);
            waypoints2[28] = Instantiate(waypoint, new Vector3(17f, -36f, 0.0f), Quaternion.identity);
            waypoints2[29] = Instantiate(waypoint, new Vector3(20f, -36f, 0.0f), Quaternion.identity);
            waypoints2[30] = Instantiate(waypoint, new Vector3(23f, -36f, 0.0f), Quaternion.identity);
            waypoints2[31] = Instantiate(waypoint, new Vector3(20f, -40f, 0.0f), Quaternion.identity);

            waypoints2[32] = Instantiate(waypoint, new Vector3(17f, -45f, 0.0f), Quaternion.identity);
            waypoints2[33] = Instantiate(waypoint, new Vector3(20f, -45f, 0.0f), Quaternion.identity);
            waypoints2[34] = Instantiate(waypoint, new Vector3(23f, -45f, 0.0f), Quaternion.identity);
            waypoints2[35] = Instantiate(waypoint, new Vector3(17f, -48f, 0.0f), Quaternion.identity);
            waypoints2[36] = Instantiate(waypoint, new Vector3(20f, -48f, 0.0f), Quaternion.identity);
            waypoints2[37] = Instantiate(waypoint, new Vector3(23f, -48f, 0.0f), Quaternion.identity);
            waypoints2[38] = Instantiate(waypoint, new Vector3(17f, -52f, 0.0f), Quaternion.identity);
            waypoints2[39] = Instantiate(waypoint, new Vector3(20f, -52f, 0.0f), Quaternion.identity);
            waypoints2[40] = Instantiate(waypoint, new Vector3(23f, -52f, 0.0f), Quaternion.identity);
            waypoints2[41] = Instantiate(waypoint, new Vector3(20f, -56f, 0.0f), Quaternion.identity);

            waypoints2[42] = Instantiate(waypoint, new Vector3(12f, -48f, 0.0f), Quaternion.identity);
            waypoints2[43] = Instantiate(waypoint, new Vector3(9f, -48f, 0.0f), Quaternion.identity);
            waypoints2[44] = Instantiate(waypoint, new Vector3(9f, -44f, 0.0f), Quaternion.identity);
            waypoints2[45] = Instantiate(waypoint, new Vector3(9f, -52f, 0.0f), Quaternion.identity);

            waypoints2[46] = Instantiate(waypoint, new Vector3(28f, -48f, 0.0f), Quaternion.identity);
            waypoints2[47] = Instantiate(waypoint, new Vector3(32f, -48f, 0.0f), Quaternion.identity);
            waypoints2[48] = Instantiate(waypoint, new Vector3(32f, -45f, 0.0f), Quaternion.identity);
            waypoints2[49] = Instantiate(waypoint, new Vector3(32f, -51f, 0.0f), Quaternion.identity);

            waypoints2[50] = Instantiate(waypoint, new Vector3(20f, -60f, 0.0f), Quaternion.identity);
            waypoints2[51] = Instantiate(waypoint, new Vector3(20f, -65f, 0.0f), Quaternion.identity);
            waypoints2[52] = Instantiate(waypoint, new Vector3(20f, -70f, 0.0f), Quaternion.identity);
            waypoints2[53] = Instantiate(waypoint, new Vector3(20f, -75f, 0.0f), Quaternion.identity);
            waypoints2[54] = Instantiate(waypoint, new Vector3(20f, -80f, 0.0f), Quaternion.identity);
            waypoints2[55] = Instantiate(waypoint, new Vector3(20f, -84f, 0.0f), Quaternion.identity);

            waypoints2[56] = Instantiate(waypoint, new Vector3(16f, -84f, 0.0f), Quaternion.identity);
            waypoints2[57] = Instantiate(waypoint, new Vector3(12f, -84f, 0.0f), Quaternion.identity);
            waypoints2[58] = Instantiate(waypoint, new Vector3(12f, -81f, 0.0f), Quaternion.identity);
            waypoints2[59] = Instantiate(waypoint, new Vector3(12f, -87f, 0.0f), Quaternion.identity);
            waypoints2[60] = Instantiate(waypoint, new Vector3(8f, -81f, 0.0f), Quaternion.identity);
            waypoints2[61] = Instantiate(waypoint, new Vector3(8f, -87f, 0.0f), Quaternion.identity);
            waypoints2[62] = Instantiate(waypoint, new Vector3(5f, -81f, 0.0f), Quaternion.identity);
            waypoints2[63] = Instantiate(waypoint, new Vector3(5f, -84f, 0.0f), Quaternion.identity);
            waypoints2[64] = Instantiate(waypoint, new Vector3(5f, -87f, 0.0f), Quaternion.identity);

            waypoints2[65] = Instantiate(waypoint, new Vector3(25f, -84f, 0.0f), Quaternion.identity);
            waypoints2[66] = Instantiate(waypoint, new Vector3(30f, -84f, 0.0f), Quaternion.identity);
            waypoints2[67] = Instantiate(waypoint, new Vector3(35f, -84f, 0.0f), Quaternion.identity);
            waypoints2[68] = Instantiate(waypoint, new Vector3(40f, -84f, 0.0f), Quaternion.identity);
            waypoints2[69] = Instantiate(waypoint, new Vector3(45.5f, -84f, 0.0f), Quaternion.identity);
            waypoints2[70] = Instantiate(waypoint, new Vector3(45.5f, -79f, 0.0f), Quaternion.identity);
            waypoints2[71] = Instantiate(waypoint, new Vector3(43f, -79f, 0.0f), Quaternion.identity);
            waypoints2[72] = Instantiate(waypoint, new Vector3(43f, -89.5f, 0.0f), Quaternion.identity);
            waypoints2[73] = Instantiate(waypoint, new Vector3(45.5f, -89.5f, 0.0f), Quaternion.identity);
            waypoints2[74] = Instantiate(waypoint, new Vector3(50f, -84f, 0.0f), Quaternion.identity);
            waypoints2[75] = Instantiate(waypoint, new Vector3(55f, -84f, 0.0f), Quaternion.identity);
            waypoints2[76] = Instantiate(waypoint, new Vector3(60f, -84f, 0.0f), Quaternion.identity);
            waypoints2[77] = Instantiate(waypoint, new Vector3(60f, -90f, 0.0f), Quaternion.identity);
            waypoints2[78] = Instantiate(waypoint, new Vector3(60f, -95f, 0.0f), Quaternion.identity);
            waypoints2[79] = Instantiate(waypoint, new Vector3(60f, -100f, 0.0f), Quaternion.identity);
            waypoints2[80] = Instantiate(waypoint, new Vector3(56f, -100f, 0.0f), Quaternion.identity);

            waypoints2[81] = Instantiate(waypoint, new Vector3(52f, -101f, 0.0f), Quaternion.identity);
            waypoints2[82] = Instantiate(waypoint, new Vector3(52f, -95f, 0.0f), Quaternion.identity);
            waypoints2[83] = Instantiate(waypoint, new Vector3(52f, -109f, 0.0f), Quaternion.identity);
            waypoints2[84] = Instantiate(waypoint, new Vector3(47f, -101f, 0.0f), Quaternion.identity);
            waypoints2[85] = Instantiate(waypoint, new Vector3(42f, -101f, 0.0f), Quaternion.identity);
            waypoints2[86] = Instantiate(waypoint, new Vector3(37f, -101f, 0.0f), Quaternion.identity);
            waypoints2[87] = Instantiate(waypoint, new Vector3(47f, -95f, 0.0f), Quaternion.identity);
            waypoints2[88] = Instantiate(waypoint, new Vector3(42f, -95f, 0.0f), Quaternion.identity);
            waypoints2[89] = Instantiate(waypoint, new Vector3(37f, -95f, 0.0f), Quaternion.identity);
            waypoints2[90] = Instantiate(waypoint, new Vector3(47f, -109f, 0.0f), Quaternion.identity);
            waypoints2[91] = Instantiate(waypoint, new Vector3(42f, -110f, 0.0f), Quaternion.identity);
            waypoints2[92] = Instantiate(waypoint, new Vector3(37f, -110f, 0.0f), Quaternion.identity);
            waypoints2[93] = Instantiate(waypoint, new Vector3(31f, -95f, 0.0f), Quaternion.identity);
            waypoints2[94] = Instantiate(waypoint, new Vector3(31f, -101f, 0.0f), Quaternion.identity);
            waypoints2[95] = Instantiate(waypoint, new Vector3(31f, -109f, 0.0f), Quaternion.identity);

            waypoints2[96] = Instantiate(waypoint, new Vector3(60f, -80f, 0.0f), Quaternion.identity);
            waypoints2[97] = Instantiate(waypoint, new Vector3(60f, -76f, 0.0f), Quaternion.identity);
            waypoints2[98] = Instantiate(waypoint, new Vector3(60f, -72f, 0.0f), Quaternion.identity);
            waypoints2[99] = Instantiate(waypoint, new Vector3(60f, -68f, 0.0f), Quaternion.identity);
            waypoints2[100] = Instantiate(waypoint, new Vector3(56f, -68f, 0.0f), Quaternion.identity);
            waypoints2[101] = Instantiate(waypoint, new Vector3(52f, -68f, 0.0f), Quaternion.identity);
            waypoints2[102] = Instantiate(waypoint, new Vector3(48f, -68f, 0.0f), Quaternion.identity);
            waypoints2[103] = Instantiate(waypoint, new Vector3(44f, -68f, 0.0f), Quaternion.identity);
            waypoints2[104] = Instantiate(waypoint, new Vector3(41f, -68f, 0.0f), Quaternion.identity);
            waypoints2[105] = Instantiate(waypoint, new Vector3(36f, -68f, 0.0f), Quaternion.identity);
            waypoints2[106] = Instantiate(waypoint, new Vector3(33f, -68f, 0.0f), Quaternion.identity);
            waypoints2[107] = Instantiate(waypoint, new Vector3(48f, -72.5f, 0.0f), Quaternion.identity);
            waypoints2[108] = Instantiate(waypoint, new Vector3(41f, -72.5f, 0.0f), Quaternion.identity);
            waypoints2[109] = Instantiate(waypoint, new Vector3(36f, -72.5f, 0.0f), Quaternion.identity);
            waypoints2[110] = Instantiate(waypoint, new Vector3(36f, -75f, 0.0f), Quaternion.identity);
            waypoints2[111] = Instantiate(waypoint, new Vector3(31f, -72.5f, 0.0f), Quaternion.identity);
            waypoints2[112] = Instantiate(waypoint, new Vector3(31f, -75f, 0.0f), Quaternion.identity);
            waypoints2[113] = Instantiate(waypoint, new Vector3(48f, -64f, 0.0f), Quaternion.identity);
            waypoints2[114] = Instantiate(waypoint, new Vector3(48f, -59f, 0.0f), Quaternion.identity);
            waypoints2[115] = Instantiate(waypoint, new Vector3(41f, -64f, 0.0f), Quaternion.identity);
            waypoints2[116] = Instantiate(waypoint, new Vector3(41f, -59f, 0.0f), Quaternion.identity);
            waypoints2[117] = Instantiate(waypoint, new Vector3(36f, -64f, 0.0f), Quaternion.identity);
            waypoints2[118] = Instantiate(waypoint, new Vector3(36f, -59f, 0.0f), Quaternion.identity);
            waypoints2[119] = Instantiate(waypoint, new Vector3(32f, -64f, 0.0f), Quaternion.identity);
            waypoints2[120] = Instantiate(waypoint, new Vector3(32f, -59f, 0.0f), Quaternion.identity);

            waypoints2[121] = Instantiate(waypoint, new Vector3(48.5f, -54f, 0.0f), Quaternion.identity);
            waypoints2[122] = Instantiate(waypoint, new Vector3(42.5f, -52f, 0.0f), Quaternion.identity);
            waypoints2[123] = Instantiate(waypoint, new Vector3(42.5f, -47f, 0.0f), Quaternion.identity);
            waypoints2[124] = Instantiate(waypoint, new Vector3(49f, -50f, 0.0f), Quaternion.identity);
            waypoints2[125] = Instantiate(waypoint, new Vector3(49f, -48f, 0.0f), Quaternion.identity);
            waypoints2[126] = Instantiate(waypoint, new Vector3(46f, -48f, 0.0f), Quaternion.identity);
            waypoints2[127] = Instantiate(waypoint, new Vector3(54f, -50f, 0.0f), Quaternion.identity);
            waypoints2[128] = Instantiate(waypoint, new Vector3(49f, -46f, 0.0f), Quaternion.identity);

            waypoints2[129] = Instantiate(waypoint, new Vector3(64f, -68f, 0.0f), Quaternion.identity);
            waypoints2[130] = Instantiate(waypoint, new Vector3(68f, -68f, 0.0f), Quaternion.identity);
            waypoints2[131] = Instantiate(waypoint, new Vector3(72f, -68f, 0.0f), Quaternion.identity);
            waypoints2[132] = Instantiate(waypoint, new Vector3(76f, -68f, 0.0f), Quaternion.identity);
            waypoints2[133] = Instantiate(waypoint, new Vector3(76f, -64f, 0.0f), Quaternion.identity);
            waypoints2[134] = Instantiate(waypoint, new Vector3(76f, -60f, 0.0f), Quaternion.identity);
            waypoints2[135] = Instantiate(waypoint, new Vector3(76f, -56f, 0.0f), Quaternion.identity);
            waypoints2[136] = Instantiate(waypoint, new Vector3(76f, -52f, 0.0f), Quaternion.identity);
            waypoints2[137] = Instantiate(waypoint, new Vector3(76f, -48f, 0.0f), Quaternion.identity);
            waypoints2[138] = Instantiate(waypoint, new Vector3(76f, -43f, 0.0f), Quaternion.identity);
            waypoints2[139] = Instantiate(waypoint, new Vector3(72f, -52f, 0.0f), Quaternion.identity);

            waypoints2[139] = Instantiate(waypoint, new Vector3(67f, -48f, 0.0f), Quaternion.identity);
            waypoints2[140] = Instantiate(waypoint, new Vector3(67f, -52f, 0.0f), Quaternion.identity);
            waypoints2[141] = Instantiate(waypoint, new Vector3(67f, -56f, 0.0f), Quaternion.identity);
            waypoints2[142] = Instantiate(waypoint, new Vector3(59.5f, -48f, 0.0f), Quaternion.identity);
            waypoints2[143] = Instantiate(waypoint, new Vector3(59.5f, -52f, 0.0f), Quaternion.identity);
            waypoints2[144] = Instantiate(waypoint, new Vector3(59.5f, -56f, 0.0f), Quaternion.identity);
            waypoints2[145] = Instantiate(waypoint, new Vector3(65f, -48f, 0.0f), Quaternion.identity);
            waypoints2[146] = Instantiate(waypoint, new Vector3(65f, -40f, 0.0f), Quaternion.identity);
            waypoints2[147] = Instantiate(waypoint, new Vector3(60f, -40f, 0.0f), Quaternion.identity);
            waypoints2[148] = Instantiate(waypoint, new Vector3(69f, -40f, 0.0f), Quaternion.identity);
            waypoints2[149] = Instantiate(waypoint, new Vector3(65f, -35f, 0.0f), Quaternion.identity);
            waypoints2[150] = Instantiate(waypoint, new Vector3(65f, -30f, 0.0f), Quaternion.identity);
            waypoints2[151] = Instantiate(waypoint, new Vector3(60f, -30f, 0.0f), Quaternion.identity);
            waypoints2[152] = Instantiate(waypoint, new Vector3(69f, -30f, 0.0f), Quaternion.identity);

            waypoints2[153] = Instantiate(waypoint, new Vector3(81f, -68f, 0.0f), Quaternion.identity);
            waypoints2[154] = Instantiate(waypoint, new Vector3(87f, -68f, 0.0f), Quaternion.identity);
            waypoints2[155] = Instantiate(waypoint, new Vector3(93f, -68f, 0.0f), Quaternion.identity);
            waypoints2[156] = Instantiate(waypoint, new Vector3(93f, -64f, 0.0f), Quaternion.identity);
            waypoints2[157] = Instantiate(waypoint, new Vector3(93f, -58.5f, 0.0f), Quaternion.identity);
            waypoints2[158] = Instantiate(waypoint, new Vector3(88f, -58.5f, 0.0f), Quaternion.identity);
            waypoints2[159] = Instantiate(waypoint, new Vector3(98f, -58.5f, 0.0f), Quaternion.identity);

            waypoints2[160] = Instantiate(waypoint, new Vector3(99f, -68f, 0.0f), Quaternion.identity);
            waypoints2[161] = Instantiate(waypoint, new Vector3(105f, -68f, 0.0f), Quaternion.identity);
            waypoints2[162] = Instantiate(waypoint, new Vector3(110f, -68f, 0.0f), Quaternion.identity);
            waypoints2[163] = Instantiate(waypoint, new Vector3(115f, -68f, 0.0f), Quaternion.identity);
            waypoints2[164] = Instantiate(waypoint, new Vector3(120f, -68f, 0.0f), Quaternion.identity);
            waypoints2[165] = Instantiate(waypoint, new Vector3(124f, -64f, 0.0f), Quaternion.identity);
            waypoints2[166] = Instantiate(waypoint, new Vector3(124f, -60f, 0.0f), Quaternion.identity);
            waypoints2[167] = Instantiate(waypoint, new Vector3(124f, -55f, 0.0f), Quaternion.identity);
            waypoints2[168] = Instantiate(waypoint, new Vector3(124f, -50f, 0.0f), Quaternion.identity);

            waypoints2[169] = Instantiate(waypoint, new Vector3(124f, -45f, 0.0f), Quaternion.identity);
            waypoints2[170] = Instantiate(waypoint, new Vector3(118f, -45f, 0.0f), Quaternion.identity);
            waypoints2[171] = Instantiate(waypoint, new Vector3(132f, -45f, 0.0f), Quaternion.identity);
            waypoints2[172] = Instantiate(waypoint, new Vector3(115f, -43f, 0.0f), Quaternion.identity);
            waypoints2[173] = Instantiate(waypoint, new Vector3(118f, -41f, 0.0f), Quaternion.identity);
            waypoints2[174] = Instantiate(waypoint, new Vector3(124f, -41f, 0.0f), Quaternion.identity);
            waypoints2[175] = Instantiate(waypoint, new Vector3(132f, -41f, 0.0f), Quaternion.identity);
            waypoints2[176] = Instantiate(waypoint, new Vector3(118f, -36f, 0.0f), Quaternion.identity);
            waypoints2[177] = Instantiate(waypoint, new Vector3(124f, -36f, 0.0f), Quaternion.identity);
            waypoints2[178] = Instantiate(waypoint, new Vector3(132f, -36f, 0.0f), Quaternion.identity);
            waypoints2[179] = Instantiate(waypoint, new Vector3(118f, -33f, 0.0f), Quaternion.identity);
            waypoints2[180] = Instantiate(waypoint, new Vector3(124f, -33f, 0.0f), Quaternion.identity);
            waypoints2[181] = Instantiate(waypoint, new Vector3(132f, -33f, 0.0f), Quaternion.identity);

            waypoints2[182] = Instantiate(waypoint, new Vector3(92.5f, -73f, 0.0f), Quaternion.identity);
            waypoints2[183] = Instantiate(waypoint, new Vector3(92.5f, -78f, 0.0f), Quaternion.identity);
            waypoints2[184] = Instantiate(waypoint, new Vector3(87f, -78f, 0.0f), Quaternion.identity);
            waypoints2[185] = Instantiate(waypoint, new Vector3(84f, -75f, 0.0f), Quaternion.identity);
            waypoints2[186] = Instantiate(waypoint, new Vector3(87f, -82f, 0.0f), Quaternion.identity);
            waypoints2[187] = Instantiate(waypoint, new Vector3(92f, -82f, 0.0f), Quaternion.identity);
            waypoints2[188] = Instantiate(waypoint, new Vector3(96f, -82f, 0.0f), Quaternion.identity);
            waypoints2[189] = Instantiate(waypoint, new Vector3(100f, -82f, 0.0f), Quaternion.identity);
            waypoints2[190] = Instantiate(waypoint, new Vector3(104f, -82f, 0.0f), Quaternion.identity);
            waypoints2[191] = Instantiate(waypoint, new Vector3(108f, -82f, 0.0f), Quaternion.identity);
            waypoints2[192] = Instantiate(waypoint, new Vector3(87f, -86f, 0.0f), Quaternion.identity);
            waypoints2[193] = Instantiate(waypoint, new Vector3(92f, -86f, 0.0f), Quaternion.identity);
            waypoints2[194] = Instantiate(waypoint, new Vector3(96f, -86f, 0.0f), Quaternion.identity);
            waypoints2[195] = Instantiate(waypoint, new Vector3(100f, -86f, 0.0f), Quaternion.identity);
            waypoints2[196] = Instantiate(waypoint, new Vector3(104f, -86f, 0.0f), Quaternion.identity);
            waypoints2[197] = Instantiate(waypoint, new Vector3(108f, -86f, 0.0f), Quaternion.identity);
            waypoints2[186] = Instantiate(waypoint, new Vector3(87f, -82f, 0.0f), Quaternion.identity);
            waypoints2[187] = Instantiate(waypoint, new Vector3(92f, -82f, 0.0f), Quaternion.identity);
            waypoints2[188] = Instantiate(waypoint, new Vector3(96f, -82f, 0.0f), Quaternion.identity);
            waypoints2[189] = Instantiate(waypoint, new Vector3(100f, -82f, 0.0f), Quaternion.identity);
            waypoints2[190] = Instantiate(waypoint, new Vector3(104f, -82f, 0.0f), Quaternion.identity);
            waypoints2[191] = Instantiate(waypoint, new Vector3(108f, -82f, 0.0f), Quaternion.identity);
            waypoints2[192] = Instantiate(waypoint, new Vector3(87f, -86f, 0.0f), Quaternion.identity);
            waypoints2[193] = Instantiate(waypoint, new Vector3(92f, -86f, 0.0f), Quaternion.identity);
            waypoints2[194] = Instantiate(waypoint, new Vector3(96f, -86f, 0.0f), Quaternion.identity);
            waypoints2[195] = Instantiate(waypoint, new Vector3(100f, -86f, 0.0f), Quaternion.identity);
            waypoints2[196] = Instantiate(waypoint, new Vector3(104f, -86f, 0.0f), Quaternion.identity);
            waypoints2[197] = Instantiate(waypoint, new Vector3(108f, -86f, 0.0f), Quaternion.identity);
            waypoints2[198] = Instantiate(waypoint, new Vector3(98f, -78f, 0.0f), Quaternion.identity);
            waypoints2[199] = Instantiate(waypoint, new Vector3(110f, -76f, 0.0f), Quaternion.identity);
            waypoints2[200] = Instantiate(waypoint, new Vector3(84f, -91f, 0.0f), Quaternion.identity);
            waypoints2[201] = Instantiate(waypoint, new Vector3(88f, -91f, 0.0f), Quaternion.identity);
            waypoints2[202] = Instantiate(waypoint, new Vector3(92f, -91f, 0.0f), Quaternion.identity);
            waypoints2[203] = Instantiate(waypoint, new Vector3(98f, -91f, 0.0f), Quaternion.identity);
            waypoints2[204] = Instantiate(waypoint, new Vector3(102f, -91f, 0.0f), Quaternion.identity);
            waypoints2[205] = Instantiate(waypoint, new Vector3(109f, -91f, 0.0f), Quaternion.identity);
            waypoints2[206] = Instantiate(waypoint, new Vector3(109f, -94f, 0.0f), Quaternion.identity);

            waypoints2[207] = Instantiate(waypoint, new Vector3(112f, -84f, 0.0f), Quaternion.identity);
            waypoints2[208] = Instantiate(waypoint, new Vector3(118f, -84f, 0.0f), Quaternion.identity);
            waypoints2[209] = Instantiate(waypoint, new Vector3(123f, -84f, 0.0f), Quaternion.identity);
            waypoints2[210] = Instantiate(waypoint, new Vector3(123f, -80f, 0.0f), Quaternion.identity);
            waypoints2[211] = Instantiate(waypoint, new Vector3(124f, -76f, 0.0f), Quaternion.identity);
            waypoints2[212] = Instantiate(waypoint, new Vector3(128f, -76f, 0.0f), Quaternion.identity);
            waypoints2[213] = Instantiate(waypoint, new Vector3(132f, -78f, 0.0f), Quaternion.identity);
            waypoints2[214] = Instantiate(waypoint, new Vector3(136f, -78f, 0.0f), Quaternion.identity);
            waypoints2[215] = Instantiate(waypoint, new Vector3(140f, -78f, 0.0f), Quaternion.identity);
            waypoints2[216] = Instantiate(waypoint, new Vector3(140f, -74f, 0.0f), Quaternion.identity);
            waypoints2[217] = Instantiate(waypoint, new Vector3(128f, -84f, 0.0f), Quaternion.identity);
            waypoints2[218] = Instantiate(waypoint, new Vector3(132f, -84f, 0.0f), Quaternion.identity);
            waypoints2[219] = Instantiate(waypoint, new Vector3(136f, -84f, 0.0f), Quaternion.identity);
            waypoints2[220] = Instantiate(waypoint, new Vector3(140f, -84f, 0.0f), Quaternion.identity);
            waypoints2[221] = Instantiate(waypoint, new Vector3(144f, -84f, 0.0f), Quaternion.identity);
            waypoints2[222] = Instantiate(waypoint, new Vector3(132f, -81f, 0.0f), Quaternion.identity);
            waypoints2[223] = Instantiate(waypoint, new Vector3(136f, -81f, 0.0f), Quaternion.identity);
            waypoints2[224] = Instantiate(waypoint, new Vector3(140f, -81f, 0.0f), Quaternion.identity);
            waypoints2[225] = Instantiate(waypoint, new Vector3(123f, -88f, 0.0f), Quaternion.identity);
            waypoints2[226] = Instantiate(waypoint, new Vector3(132f, -88f, 0.0f), Quaternion.identity);
            waypoints2[227] = Instantiate(waypoint, new Vector3(136f, -88f, 0.0f), Quaternion.identity);
            waypoints2[228] = Instantiate(waypoint, new Vector3(140f, -88f, 0.0f), Quaternion.identity);
            waypoints2[229] = Instantiate(waypoint, new Vector3(124f, -92f, 0.0f), Quaternion.identity);
            waypoints2[230] = Instantiate(waypoint, new Vector3(128f, -92f, 0.0f), Quaternion.identity);
            waypoints2[231] = Instantiate(waypoint, new Vector3(132f, -92f, 0.0f), Quaternion.identity);
            waypoints2[232] = Instantiate(waypoint, new Vector3(136f, -92f, 0.0f), Quaternion.identity);
            waypoints2[233] = Instantiate(waypoint, new Vector3(140f, -92f, 0.0f), Quaternion.identity);
            waypoints2[234] = Instantiate(waypoint, new Vector3(140f, -95f, 0.0f), Quaternion.identity);
            waypoints2[235] = Instantiate(waypoint, new Vector3(124f, -96f, 0.0f), Quaternion.identity);

            waypoints2[236] = Instantiate(waypoint, new Vector3(124f, -100f, 0.0f), Quaternion.identity);
            waypoints2[237] = Instantiate(waypoint, new Vector3(124f, -104f, 0.0f), Quaternion.identity);
            waypoints2[238] = Instantiate(waypoint, new Vector3(124f, -108f, 0.0f), Quaternion.identity);
            waypoints2[239] = Instantiate(waypoint, new Vector3(124f, -112f, 0.0f), Quaternion.identity);
            waypoints2[240] = Instantiate(waypoint, new Vector3(124f, -116f, 0.0f), Quaternion.identity);

            waypoints2[241] = Instantiate(waypoint, new Vector3(92f, -96f, 0.0f), Quaternion.identity);
            waypoints2[242] = Instantiate(waypoint, new Vector3(92f, -100f, 0.0f), Quaternion.identity);
            waypoints2[243] = Instantiate(waypoint, new Vector3(92f, -105f, 0.0f), Quaternion.identity);
            waypoints2[244] = Instantiate(waypoint, new Vector3(92f, -110f, 0.0f), Quaternion.identity);
            waypoints2[245] = Instantiate(waypoint, new Vector3(92f, -115f, 0.0f), Quaternion.identity);
            waypoints2[246] = Instantiate(waypoint, new Vector3(92f, -120f, 0.0f), Quaternion.identity);
            waypoints2[247] = Instantiate(waypoint, new Vector3(92f, -125f, 0.0f), Quaternion.identity);

            waypoints2[248] = Instantiate(waypoint, new Vector3(93f, -131f, 0.0f), Quaternion.identity);
            waypoints2[249] = Instantiate(waypoint, new Vector3(98f, -132f, 0.0f), Quaternion.identity);
            waypoints2[250] = Instantiate(waypoint, new Vector3(94f, -136f, 0.0f), Quaternion.identity);
            waypoints2[251] = Instantiate(waypoint, new Vector3(98f, -136f, 0.0f), Quaternion.identity);
            waypoints2[252] = Instantiate(waypoint, new Vector3(94f, -139f, 0.0f), Quaternion.identity);
            waypoints2[253] = Instantiate(waypoint, new Vector3(98f, -140f, 0.0f), Quaternion.identity);
            waypoints2[254] = Instantiate(waypoint, new Vector3(90f, -132f, 0.0f), Quaternion.identity);
            waypoints2[255] = Instantiate(waypoint, new Vector3(88f, -136f, 0.0f), Quaternion.identity);
            waypoints2[256] = Instantiate(waypoint, new Vector3(89.5f, -139.5f, 0.0f), Quaternion.identity);

            waypoints2[257] = Instantiate(waypoint, new Vector3(96f, -125f, 0.0f), Quaternion.identity);
            waypoints2[258] = Instantiate(waypoint, new Vector3(100f, -125f, 0.0f), Quaternion.identity);
            waypoints2[259] = Instantiate(waypoint, new Vector3(104f, -125f, 0.0f), Quaternion.identity);
            waypoints2[260] = Instantiate(waypoint, new Vector3(108f, -125f, 0.0f), Quaternion.identity);
            waypoints2[261] = Instantiate(waypoint, new Vector3(112f, -125f, 0.0f), Quaternion.identity);
            waypoints2[262] = Instantiate(waypoint, new Vector3(116f, -125f, 0.0f), Quaternion.identity);
            waypoints2[263] = Instantiate(waypoint, new Vector3(120f, -125f, 0.0f), Quaternion.identity);

            waypoints2[264] = Instantiate(waypoint, new Vector3(108f, -120f, 0.0f), Quaternion.identity);
            waypoints2[265] = Instantiate(waypoint, new Vector3(108f, -116f, 0.0f), Quaternion.identity);
            waypoints2[266] = Instantiate(waypoint, new Vector3(105f, -116f, 0.0f), Quaternion.identity);
            waypoints2[267] = Instantiate(waypoint, new Vector3(111f, -116f, 0.0f), Quaternion.identity);
            waypoints2[268] = Instantiate(waypoint, new Vector3(105f, -112f, 0.0f), Quaternion.identity);
            waypoints2[269] = Instantiate(waypoint, new Vector3(112f, -112f, 0.0f), Quaternion.identity);
            waypoints2[270] = Instantiate(waypoint, new Vector3(105f, -108f, 0.0f), Quaternion.identity);
            waypoints2[271] = Instantiate(waypoint, new Vector3(108f, -108f, 0.0f), Quaternion.identity);
            waypoints2[272] = Instantiate(waypoint, new Vector3(112f, -108f, 0.0f), Quaternion.identity);

            waypoints2[273] = Instantiate(waypoint, new Vector3(88f, -100f, 0.0f), Quaternion.identity);
            waypoints2[274] = Instantiate(waypoint, new Vector3(84f, -100f, 0.0f), Quaternion.identity);
            waypoints2[275] = Instantiate(waypoint, new Vector3(80f, -100f, 0.0f), Quaternion.identity);
            waypoints2[276] = Instantiate(waypoint, new Vector3(76f, -100f, 0.0f), Quaternion.identity);
            waypoints2[277] = Instantiate(waypoint, new Vector3(76f, -104f, 0.0f), Quaternion.identity);
            waypoints2[278] = Instantiate(waypoint, new Vector3(76f, -108f, 0.0f), Quaternion.identity);
            waypoints2[279] = Instantiate(waypoint, new Vector3(76f, -112f, 0.0f), Quaternion.identity);
            waypoints2[280] = Instantiate(waypoint, new Vector3(76f, -116.5f, 0.0f), Quaternion.identity);
            waypoints2[281] = Instantiate(waypoint, new Vector3(76f, -120f, 0.0f), Quaternion.identity);
            waypoints2[282] = Instantiate(waypoint, new Vector3(76f, -124f, 0.0f), Quaternion.identity);
            waypoints2[283] = Instantiate(waypoint, new Vector3(76f, -128f, 0.0f), Quaternion.identity);
            waypoints2[284] = Instantiate(waypoint, new Vector3(76f, -132f, 0.0f), Quaternion.identity);
            waypoints2[285] = Instantiate(waypoint, new Vector3(77f, -136f, 0.0f), Quaternion.identity);

            waypoints2[286] = Instantiate(waypoint, new Vector3(76f, -140f, 0.0f), Quaternion.identity);
            waypoints2[287] = Instantiate(waypoint, new Vector3(72f, -140f, 0.0f), Quaternion.identity);
            waypoints2[288] = Instantiate(waypoint, new Vector3(80f, -140f, 0.0f), Quaternion.identity);
            waypoints2[289] = Instantiate(waypoint, new Vector3(70f, -142f, 0.0f), Quaternion.identity);
            waypoints2[290] = Instantiate(waypoint, new Vector3(74f, -142f, 0.0f), Quaternion.identity);
            waypoints2[291] = Instantiate(waypoint, new Vector3(78f, -142f, 0.0f), Quaternion.identity);
            waypoints2[292] = Instantiate(waypoint, new Vector3(82f, -142f, 0.0f), Quaternion.identity);
            waypoints2[293] = Instantiate(waypoint, new Vector3(71f, -146f, 0.0f), Quaternion.identity);
            waypoints2[294] = Instantiate(waypoint, new Vector3(74f, -146f, 0.0f), Quaternion.identity);
            waypoints2[295] = Instantiate(waypoint, new Vector3(78f, -146f, 0.0f), Quaternion.identity);
            waypoints2[296] = Instantiate(waypoint, new Vector3(82f, -146f, 0.0f), Quaternion.identity);
            waypoints2[297] = Instantiate(waypoint, new Vector3(80f, -148f, 0.0f), Quaternion.identity);
            waypoints2[298] = Instantiate(waypoint, new Vector3(80f, -148f, 0.0f), Quaternion.identity);
            waypoints2[299] = Instantiate(waypoint, new Vector3(80f, -148f, 0.0f), Quaternion.identity);

            waypoints2[300] = Instantiate(waypoint, new Vector3(72f, -116.5f, 0.0f), Quaternion.identity);
            waypoints2[301] = Instantiate(waypoint, new Vector3(68f, -116.5f, 0.0f), Quaternion.identity);
            waypoints2[302] = Instantiate(waypoint, new Vector3(68f, -113.5f, 0.0f), Quaternion.identity);
            waypoints2[303] = Instantiate(waypoint, new Vector3(64f, -113.5f, 0.0f), Quaternion.identity);
            waypoints2[304] = Instantiate(waypoint, new Vector3(60f, -113.5f, 0.0f), Quaternion.identity);
            waypoints2[305] = Instantiate(waypoint, new Vector3(60f, -117f, 0.0f), Quaternion.identity);
            waypoints2[306] = Instantiate(waypoint, new Vector3(64f, -117f, 0.0f), Quaternion.identity);
            waypoints2[307] = Instantiate(waypoint, new Vector3(60f, -120f, 0.0f), Quaternion.identity);
            waypoints2[308] = Instantiate(waypoint, new Vector3(68f, -120f, 0.0f), Quaternion.identity);
            waypoints2[309] = Instantiate(waypoint, new Vector3(60f, -124f, 0.0f), Quaternion.identity);
            waypoints2[310] = Instantiate(waypoint, new Vector3(64f, -124f, 0.0f), Quaternion.identity);
            waypoints2[311] = Instantiate(waypoint, new Vector3(68f, -124f, 0.0f), Quaternion.identity);
            waypoints2[312] = Instantiate(waypoint, new Vector3(64f, -128f, 0.0f), Quaternion.identity);
            waypoints2[313] = Instantiate(waypoint, new Vector3(64f, -132f, 0.0f), Quaternion.identity);
            waypoints2[314] = Instantiate(waypoint, new Vector3(61f, -132f, 0.0f), Quaternion.identity);
            waypoints2[315] = Instantiate(waypoint, new Vector3(58f, -132f, 0.0f), Quaternion.identity);
            waypoints2[316] = Instantiate(waypoint, new Vector3(64f, -136f, 0.0f), Quaternion.identity);
            waypoints2[317] = Instantiate(waypoint, new Vector3(61f, -136f, 0.0f), Quaternion.identity);
            waypoints2[318] = Instantiate(waypoint, new Vector3(58f, -136f, 0.0f), Quaternion.identity);
        }
        //Generate the adjacency matrix.
        if (!current_map)
        {
            adjacency_matrix[0][1] = true;
            adjacency_matrix[1][0] = true; adjacency_matrix[1][2] = true;
            adjacency_matrix[2][1] = true; adjacency_matrix[2][3] = true;
            adjacency_matrix[3][2] = true; adjacency_matrix[3][4] = true;
            adjacency_matrix[4][5] = true; adjacency_matrix[4][10] = true;
            adjacency_matrix[5][4] = true; adjacency_matrix[5][6] = true; adjacency_matrix[5][11] = true;
            adjacency_matrix[6][3] = true; adjacency_matrix[6][5] = true; adjacency_matrix[6][7] = true; adjacency_matrix[6][12] = true;
            adjacency_matrix[7][6] = true; adjacency_matrix[7][8] = true; adjacency_matrix[7][13] = true;
            adjacency_matrix[8][7] = true; adjacency_matrix[8][14] = true;
            adjacency_matrix[9][10] = true; adjacency_matrix[9][16] = true;
            adjacency_matrix[10][4] = true; adjacency_matrix[10][9] = true; adjacency_matrix[10][11] = true; adjacency_matrix[10][17] = true;
            adjacency_matrix[11][5] = true; adjacency_matrix[11][10] = true; adjacency_matrix[11][12] = true;
            adjacency_matrix[12][6] = true; adjacency_matrix[12][11] = true; adjacency_matrix[12][13] = true;
            adjacency_matrix[13][7] = true; adjacency_matrix[13][12] = true; adjacency_matrix[13][14] = true;
            adjacency_matrix[14][8] = true; adjacency_matrix[14][13] = true; adjacency_matrix[14][15] = true; adjacency_matrix[14][21] = true;
            adjacency_matrix[15][14] = true; adjacency_matrix[15][22] = true;
            adjacency_matrix[16][9] = true; adjacency_matrix[16][17] = true; adjacency_matrix[16][25] = true;
            adjacency_matrix[17][10] = true; adjacency_matrix[17][16] = true; adjacency_matrix[17][26] = true;
            adjacency_matrix[18][19] = true; adjacency_matrix[18][27] = true;
            adjacency_matrix[19][18] = true; adjacency_matrix[19][20] = true; adjacency_matrix[19][28] = true;
            adjacency_matrix[20][19] = true; adjacency_matrix[20][21] = true;
            adjacency_matrix[21][14] = true; adjacency_matrix[21][22] = true;
            adjacency_matrix[22][15] = true; adjacency_matrix[22][21] = true; adjacency_matrix[22][23] = true;
            adjacency_matrix[23][22] = true; adjacency_matrix[23][32] = true;
            adjacency_matrix[24][25] = true; adjacency_matrix[24][40] = true;
            adjacency_matrix[25][16] = true; adjacency_matrix[25][24] = true; adjacency_matrix[25][26] = true; adjacency_matrix[25][42] = true;
            adjacency_matrix[26][17] = true; adjacency_matrix[26][25] = true;
            adjacency_matrix[27][18] = true; adjacency_matrix[27][28] = true; adjacency_matrix[27][43] = true;
            adjacency_matrix[28][19] = true; adjacency_matrix[28][27] = true; adjacency_matrix[28][29] = true; adjacency_matrix[28][44] = true;
            adjacency_matrix[29][20] = true; adjacency_matrix[29][28] = true; adjacency_matrix[29][30] = true; adjacency_matrix[29][45] = true;
            adjacency_matrix[30][29] = true; adjacency_matrix[30][31] = true; adjacency_matrix[30][46] = true;
            adjacency_matrix[31][30] = true; adjacency_matrix[31][32] = true;
            adjacency_matrix[32][23] = true; adjacency_matrix[32][31] = true; adjacency_matrix[32][33] = true; adjacency_matrix[32][48] = true;
            adjacency_matrix[33][32] = true; adjacency_matrix[33][49] = true;
            adjacency_matrix[34][35] = true;
            adjacency_matrix[35][34] = true; adjacency_matrix[35][36] = true;
            adjacency_matrix[36][35] = true; adjacency_matrix[36][37] = true;
            adjacency_matrix[37][36] = true; adjacency_matrix[37][38] = true;
            adjacency_matrix[38][37] = true; adjacency_matrix[38][39] = true;
            adjacency_matrix[39][38] = true; adjacency_matrix[39][40] = true;
            adjacency_matrix[40][24] = true; adjacency_matrix[40][39] = true; adjacency_matrix[40][41] = true; adjacency_matrix[40][79] = true;
            adjacency_matrix[41][25] = true; adjacency_matrix[41][40] = true; adjacency_matrix[41][42] = true; adjacency_matrix[41][80] = true;
            adjacency_matrix[42][41] = true; adjacency_matrix[42][43] = true;
            adjacency_matrix[43][27] = true; adjacency_matrix[43][42] = true; adjacency_matrix[43][44] = true; adjacency_matrix[43][82] = true;
            adjacency_matrix[44][28] = true; adjacency_matrix[44][43] = true; adjacency_matrix[44][45] = true; adjacency_matrix[44][83] = true;
            adjacency_matrix[45][29] = true; adjacency_matrix[45][44] = true; adjacency_matrix[45][46] = true; adjacency_matrix[45][84] = true;
            adjacency_matrix[46][30] = true; adjacency_matrix[46][45] = true; adjacency_matrix[46][85] = true;
            adjacency_matrix[47][49] = true;
            adjacency_matrix[48][32] = true; adjacency_matrix[48][47] = true; adjacency_matrix[48][49] = true; adjacency_matrix[48][87] = true;
            adjacency_matrix[49][33] = true; adjacency_matrix[49][48] = true; adjacency_matrix[49][50] = true; adjacency_matrix[49][88] = true;
            adjacency_matrix[50][49] = true; adjacency_matrix[50][51] = true;
            adjacency_matrix[51][50] = true; adjacency_matrix[51][62] = true;
            adjacency_matrix[52][53] = true; adjacency_matrix[52][55] = true;
            adjacency_matrix[53][52] = true; adjacency_matrix[53][56] = true;
            adjacency_matrix[54][55] = true; adjacency_matrix[54][57] = true;
            adjacency_matrix[55][52] = true; adjacency_matrix[55][54] = true; adjacency_matrix[55][56] = true; adjacency_matrix[55][58] = true;
            adjacency_matrix[56][53] = true; adjacency_matrix[56][55] = true; adjacency_matrix[56][59] = true;
            adjacency_matrix[57][54] = true; adjacency_matrix[57][58] = true;
            adjacency_matrix[58][55] = true; adjacency_matrix[58][57] = true; adjacency_matrix[58][59] = true; adjacency_matrix[58][60] = true;
            adjacency_matrix[59][56] = true; adjacency_matrix[59][58] = true;
            adjacency_matrix[60][58] = true; adjacency_matrix[60][62] = true;
            adjacency_matrix[61][51] = true; adjacency_matrix[61][62] = true;
            adjacency_matrix[62][60] = true; adjacency_matrix[62][61] = true; adjacency_matrix[62][63] = true;
            adjacency_matrix[63][62] = true; adjacency_matrix[63][64] = true;
            adjacency_matrix[64][63] = true; adjacency_matrix[64][65] = true; adjacency_matrix[64][68] = true;
            adjacency_matrix[65][64] = true; adjacency_matrix[65][69] = true;
            adjacency_matrix[66][67] = true; adjacency_matrix[66][70] = true;
            adjacency_matrix[67][66] = true; adjacency_matrix[67][68] = true; adjacency_matrix[67][71] = true;
            adjacency_matrix[68][64] = true; adjacency_matrix[68][67] = true; adjacency_matrix[68][69] = true;
            adjacency_matrix[69][65] = true; adjacency_matrix[69][68] = true;
            adjacency_matrix[70][66] = true; adjacency_matrix[70][71] = true; adjacency_matrix[70][72] = true;
            adjacency_matrix[71][67] = true; adjacency_matrix[71][70] = true; adjacency_matrix[71][73] = true;
            adjacency_matrix[72][70] = true; adjacency_matrix[72][73] = true;
            adjacency_matrix[73][71] = true; adjacency_matrix[73][72] = true; adjacency_matrix[73][74] = true; adjacency_matrix[73][76] = true;
            adjacency_matrix[74][73] = true; adjacency_matrix[74][75] = true; adjacency_matrix[74][77] = true;
            adjacency_matrix[75][74] = true; adjacency_matrix[75][78] = true;
            adjacency_matrix[76][73] = true; adjacency_matrix[76][77] = true;
            adjacency_matrix[77][74] = true; adjacency_matrix[77][76] = true; adjacency_matrix[77][78] = true;
            adjacency_matrix[78][75] = true; adjacency_matrix[78][77] = true;
            adjacency_matrix[79][40] = true; adjacency_matrix[79][80] = true;
            adjacency_matrix[80][41] = true; adjacency_matrix[80][79] = true; adjacency_matrix[80][81] = true; adjacency_matrix[80][89] = true;
            adjacency_matrix[81][80] = true; adjacency_matrix[81][90] = true;
            adjacency_matrix[82][43] = true; adjacency_matrix[82][83] = true; adjacency_matrix[82][91] = true;
            adjacency_matrix[83][44] = true; adjacency_matrix[83][82] = true; adjacency_matrix[83][84] = true; adjacency_matrix[83][92] = true;
            adjacency_matrix[84][45] = true; adjacency_matrix[84][83] = true; adjacency_matrix[84][85] = true; adjacency_matrix[84][93] = true;
            adjacency_matrix[85][46] = true; adjacency_matrix[85][84] = true; adjacency_matrix[85][86] = true;
            adjacency_matrix[86][85] = true; adjacency_matrix[86][87] = true;
            adjacency_matrix[87][48] = true; adjacency_matrix[87][86] = true; adjacency_matrix[87][88] = true; adjacency_matrix[87][96] = true;
            adjacency_matrix[88][49] = true; adjacency_matrix[88][87] = true;
            adjacency_matrix[89][80] = true; adjacency_matrix[89][90] = true; adjacency_matrix[89][97] = true;
            adjacency_matrix[90][81] = true; adjacency_matrix[90][89] = true; adjacency_matrix[90][98] = true;
            adjacency_matrix[91][82] = true; adjacency_matrix[91][92] = true;
            adjacency_matrix[92][83] = true; adjacency_matrix[92][91] = true; adjacency_matrix[92][93] = true;
            adjacency_matrix[93][84] = true; adjacency_matrix[93][92] = true;
            adjacency_matrix[94][95] = true; adjacency_matrix[94][102] = true;
            adjacency_matrix[95][94] = true; adjacency_matrix[95][96] = true; adjacency_matrix[95][103] = true;
            adjacency_matrix[96][87] = true; adjacency_matrix[96][95] = true;
            adjacency_matrix[97][89] = true; adjacency_matrix[97][98] = true;
            adjacency_matrix[98][90] = true; adjacency_matrix[98][97] = true; adjacency_matrix[98][99] = true; adjacency_matrix[98][104] = true;
            adjacency_matrix[99][98] = true; adjacency_matrix[99][100] = true; adjacency_matrix[99][105] = true;
            adjacency_matrix[100][99] = true; adjacency_matrix[100][101] = true; adjacency_matrix[100][106] = true;
            adjacency_matrix[101][100] = true; adjacency_matrix[101][102] = true; adjacency_matrix[101][107] = true;
            adjacency_matrix[102][94] = true; adjacency_matrix[102][101] = true; adjacency_matrix[102][103] = true; adjacency_matrix[102][108] = true;
            adjacency_matrix[103][95] = true; adjacency_matrix[103][102] = true;
            adjacency_matrix[104][98] = true; adjacency_matrix[104][105] = true;
            adjacency_matrix[105][99] = true; adjacency_matrix[105][104] = true; adjacency_matrix[105][106] = true;
            adjacency_matrix[106][100] = true; adjacency_matrix[106][105] = true; adjacency_matrix[106][107] = true;
            adjacency_matrix[107][101] = true; adjacency_matrix[107][106] = true; adjacency_matrix[107][108] = true;
            adjacency_matrix[108][102] = true; adjacency_matrix[108][107] = true;
        }
        else
        {
            adjacency_matrix2[0][1] = true; adjacency_matrix2[0][2] = true;
            adjacency_matrix2[1][0] = true; adjacency_matrix2[1][2] = true;
            adjacency_matrix2[2][0] = true; adjacency_matrix2[2][1] = true; adjacency_matrix2[0][3] = true;
            adjacency_matrix2[3][2] = true; adjacency_matrix2[3][4] = true; adjacency_matrix2[3][5] = true; adjacency_matrix2[3][8] = true;
            adjacency_matrix2[4][3] = true; adjacency_matrix2[4][6] = true;
            adjacency_matrix2[5][3] = true; adjacency_matrix2[5][10] = true;
            adjacency_matrix2[6][4] = true; adjacency_matrix2[6][7] = true; adjacency_matrix2[6][8] = true;
            adjacency_matrix2[7][6] = true; adjacency_matrix2[7][9] = true; adjacency_matrix2[7][12] = true;
            adjacency_matrix2[8][3] = true; adjacency_matrix2[8][6] = true; adjacency_matrix2[8][9] = true; adjacency_matrix2[8][10] = true;
            adjacency_matrix2[9][7] = true; adjacency_matrix2[9][8] = true; adjacency_matrix2[9][11] = true; adjacency_matrix2[9][13] = true;
            adjacency_matrix2[10][5] = true; adjacency_matrix2[10][8] = true; adjacency_matrix2[10][11] = true;
            adjacency_matrix2[11][5] = true; adjacency_matrix2[11][9] = true; adjacency_matrix2[11][14] = true;
            adjacency_matrix2[12][7] = true; adjacency_matrix2[12][13] = true; adjacency_matrix2[12][15] = true; adjacency_matrix2[12][28] = true;
            adjacency_matrix2[13][9] = true; adjacency_matrix2[13][12] = true; adjacency_matrix2[13][14] = true; adjacency_matrix2[13][29] = true;
            adjacency_matrix2[14][11] = true; adjacency_matrix2[14][13] = true; adjacency_matrix2[14][21] = true; adjacency_matrix2[14][30] = true;
            adjacency_matrix2[15][12] = true; adjacency_matrix2[15][16] = true; adjacency_matrix2[15][20] = true;
            adjacency_matrix2[16][15] = true; adjacency_matrix2[16][17] = true;
            adjacency_matrix2[17][16] = true; adjacency_matrix2[17][18] = true; adjacency_matrix2[17][19] = true;
            adjacency_matrix2[18][17] = true;
            adjacency_matrix2[19][17] = true;
            adjacency_matrix2[20][15] = true;
            adjacency_matrix2[21][14] = true; adjacency_matrix2[21][22] = true;
            adjacency_matrix2[22][21] = true; adjacency_matrix2[22][23] = true; adjacency_matrix2[22][25] = true; adjacency_matrix2[22][27] = true;
            adjacency_matrix2[23][22] = true; adjacency_matrix2[23][24] = true;
            adjacency_matrix2[24][23] = true;
            adjacency_matrix2[25][22] = true; adjacency_matrix2[25][26] = true;
            adjacency_matrix2[26][27] = true; adjacency_matrix2[26][25] = true;
            adjacency_matrix2[27][22] = true; adjacency_matrix2[27][26] = true;
            adjacency_matrix2[28][12] = true; adjacency_matrix2[28][29] = true;
            adjacency_matrix2[29][13] = true; adjacency_matrix2[29][28] = true; adjacency_matrix2[29][30] = true; adjacency_matrix2[29][31] = true;
            adjacency_matrix2[30][14] = true; adjacency_matrix2[30][29] = true;
            adjacency_matrix2[31][29] = true; adjacency_matrix2[31][33] = true;
            adjacency_matrix2[32][33] = true; adjacency_matrix2[32][35] = true;
            adjacency_matrix2[33][31] = true; adjacency_matrix2[33][32] = true; adjacency_matrix2[33][34] = true; adjacency_matrix2[33][36] = true;
            adjacency_matrix2[34][33] = true; adjacency_matrix2[34][37] = true;
            adjacency_matrix2[35][32] = true; adjacency_matrix2[35][36] = true; adjacency_matrix2[35][38] = true; adjacency_matrix2[35][42] = true;
            adjacency_matrix2[36][33] = true; adjacency_matrix2[36][35] = true; adjacency_matrix2[36][37] = true; adjacency_matrix2[36][39] = true;
            adjacency_matrix2[37][34] = true; adjacency_matrix2[37][36] = true; adjacency_matrix2[37][40] = true; adjacency_matrix2[37][46] = true;
            adjacency_matrix2[38][35] = true; adjacency_matrix2[38][39] = true;
            adjacency_matrix2[39][36] = true; adjacency_matrix2[39][38] = true; adjacency_matrix2[39][40] = true; adjacency_matrix2[39][41] = true;
            adjacency_matrix2[40][39] = true; adjacency_matrix2[40][37] = true;
            adjacency_matrix2[41][39] = true; adjacency_matrix2[41][50] = true;
            adjacency_matrix2[42][35] = true; adjacency_matrix2[42][43] = true;
            adjacency_matrix2[43][42] = true; adjacency_matrix2[43][44] = true; adjacency_matrix2[43][45] = true;
            adjacency_matrix2[44][43] = true;
            adjacency_matrix2[45][43] = true;
            adjacency_matrix2[46][37] = true; adjacency_matrix2[46][47] = true;
            adjacency_matrix2[47][46] = true; adjacency_matrix2[47][48] = true; adjacency_matrix2[47][49] = true;
            adjacency_matrix2[48][47] = true;
            adjacency_matrix2[49][47] = true;
            adjacency_matrix2[50][41] = true; adjacency_matrix2[50][51] = true;
            adjacency_matrix2[51][50] = true; adjacency_matrix2[51][52] = true;
            adjacency_matrix2[52][51] = true; adjacency_matrix2[52][53] = true;
            adjacency_matrix2[53][52] = true; adjacency_matrix2[53][54] = true;
            adjacency_matrix2[54][53] = true; adjacency_matrix2[54][55] = true;
            adjacency_matrix2[55][54] = true; adjacency_matrix2[55][56] = true; adjacency_matrix2[55][65] = true;
            adjacency_matrix2[56][55] = true; adjacency_matrix2[56][57] = true;
            adjacency_matrix2[57][56] = true; adjacency_matrix2[57][58] = true; adjacency_matrix2[57][59] = true;
            adjacency_matrix2[58][57] = true; adjacency_matrix2[58][60] = true;
            adjacency_matrix2[59][57] = true; adjacency_matrix2[59][61] = true;
            adjacency_matrix2[60][58] = true; adjacency_matrix2[60][62] = true;
            adjacency_matrix2[61][59] = true; adjacency_matrix2[61][64] = true;
            adjacency_matrix2[62][60] = true; adjacency_matrix2[62][63] = true;
            adjacency_matrix2[63][62] = true; adjacency_matrix2[63][64] = true;
            adjacency_matrix2[64][61] = true; adjacency_matrix2[64][63] = true;
            adjacency_matrix2[65][54] = true; adjacency_matrix2[65][66] = true;
            adjacency_matrix2[66][65] = true; adjacency_matrix2[66][67] = true;
            adjacency_matrix2[67][66] = true; adjacency_matrix2[67][68] = true;
            adjacency_matrix2[68][67] = true; adjacency_matrix2[68][69] = true;
            adjacency_matrix2[69][68] = true; adjacency_matrix2[69][70] = true; adjacency_matrix2[69][73] = true; adjacency_matrix2[69][74] = true;
            adjacency_matrix2[70][71] = true; adjacency_matrix2[70][69] = true;
            adjacency_matrix2[71][70] = true;
            adjacency_matrix2[72][73] = true;
            adjacency_matrix2[73][69] = true; adjacency_matrix2[73][72] = true;
            adjacency_matrix2[74][69] = true; adjacency_matrix2[74][75] = true;
            adjacency_matrix2[75][74] = true; adjacency_matrix2[75][76] = true;
            adjacency_matrix2[76][96] = true; adjacency_matrix2[76][75] = true; adjacency_matrix2[76][77] = true;
            adjacency_matrix2[77][76] = true; adjacency_matrix2[77][78] = true;
            adjacency_matrix2[78][77] = true; adjacency_matrix2[78][79] = true;
            adjacency_matrix2[79][78] = true; adjacency_matrix2[79][80] = true;
            adjacency_matrix2[80][79] = true; adjacency_matrix2[80][81] = true;
            adjacency_matrix2[81][80] = true; adjacency_matrix2[81][82] = true; adjacency_matrix2[81][83] = true; adjacency_matrix2[81][84] = true;
            adjacency_matrix2[82][81] = true; adjacency_matrix2[82][87] = true;
            adjacency_matrix2[83][81] = true; adjacency_matrix2[83][90] = true;
            adjacency_matrix2[84][81] = true; adjacency_matrix2[84][85] = true;
            adjacency_matrix2[85][84] = true; adjacency_matrix2[85][86] = true;
            adjacency_matrix2[86][85] = true; adjacency_matrix2[86][89] = true; adjacency_matrix2[86][92] = true;
            adjacency_matrix2[87][82] = true; adjacency_matrix2[87][88] = true;
            adjacency_matrix2[88][87] = true; adjacency_matrix2[88][89] = true;
            adjacency_matrix2[89][88] = true; adjacency_matrix2[89][93] = true; adjacency_matrix2[89][86] = true;
            adjacency_matrix2[90][83] = true; adjacency_matrix2[90][91] = true;
            adjacency_matrix2[91][90] = true; adjacency_matrix2[91][92] = true;
            adjacency_matrix2[92][91] = true; adjacency_matrix2[92][95] = true;
            adjacency_matrix2[93][89] = true; adjacency_matrix2[93][94] = true;
            adjacency_matrix2[94][93] = true; adjacency_matrix2[94][95] = true;
            adjacency_matrix2[95][94] = true; adjacency_matrix2[95][92] = true;
            adjacency_matrix2[96][76] = true; adjacency_matrix2[96][97] = true;
            adjacency_matrix2[97][96] = true; adjacency_matrix2[97][98] = true;
            adjacency_matrix2[98][97] = true; adjacency_matrix2[98][99] = true;
            adjacency_matrix2[99][98] = true; adjacency_matrix2[99][100] = true; adjacency_matrix2[99][129] = true;
            adjacency_matrix2[100][99] = true; adjacency_matrix2[100][101] = true;
            adjacency_matrix2[101][100] = true; adjacency_matrix2[101][102] = true;
            adjacency_matrix2[102][101] = true; adjacency_matrix2[102][103] = true; adjacency_matrix2[102][107] = true; adjacency_matrix2[102][113] = true;
            adjacency_matrix2[103][102] = true; adjacency_matrix2[103][104] = true;
            adjacency_matrix2[104][103] = true; adjacency_matrix2[104][105] = true; adjacency_matrix2[104][108] = true; adjacency_matrix2[104][115] = true;
            adjacency_matrix2[105][104] = true; adjacency_matrix2[105][106] = true; adjacency_matrix2[105][109] = true; adjacency_matrix2[105][117] = true;
            adjacency_matrix2[106][105] = true;
            adjacency_matrix2[107][102] = true;
            adjacency_matrix2[108][104] = true;
            adjacency_matrix2[109][105] = true; adjacency_matrix2[109][110] = true; adjacency_matrix2[109][111] = true;
            adjacency_matrix2[110][109] = true; adjacency_matrix2[110][112] = true;
            adjacency_matrix2[111][109] = true; adjacency_matrix2[111][112] = true;
            adjacency_matrix2[112][111] = true; adjacency_matrix2[112][110] = true;
            adjacency_matrix2[113][102] = true; adjacency_matrix2[113][114] = true;
            adjacency_matrix2[114][113] = true; adjacency_matrix2[114][121] = true;
            adjacency_matrix2[115][104] = true; adjacency_matrix2[115][116] = true;
            adjacency_matrix2[116][115] = true;
            adjacency_matrix2[117][105] = true; adjacency_matrix2[117][118] = true; adjacency_matrix2[117][119] = true;
            adjacency_matrix2[118][117] = true; adjacency_matrix2[118][120] = true;
            adjacency_matrix2[119][117] = true;
            adjacency_matrix2[120][118] = true;
            adjacency_matrix2[121][114] = true; adjacency_matrix2[121][122] = true; adjacency_matrix2[121][124] = true;
            adjacency_matrix2[122][121] = true; adjacency_matrix2[122][123] = true;
            adjacency_matrix2[123][122] = true; adjacency_matrix2[123][124] = true;
            adjacency_matrix2[124][121] = true; adjacency_matrix2[124][123] = true; adjacency_matrix2[124][127] = true; adjacency_matrix2[124][125] = true;
            adjacency_matrix2[125][124] = true; adjacency_matrix2[125][126] = true;
            adjacency_matrix2[126][125] = true;
            adjacency_matrix2[127][124] = true; adjacency_matrix2[127][128] = true;
            adjacency_matrix2[128][127] = true;
            adjacency_matrix2[129][99] = true; adjacency_matrix2[129][130] = true;
            adjacency_matrix2[130][129] = true; adjacency_matrix2[130][131] = true;
            adjacency_matrix2[131][130] = true; adjacency_matrix2[131][132] = true;
            adjacency_matrix2[132][131] = true; adjacency_matrix2[132][133] = true; adjacency_matrix2[132][153] = true;
            adjacency_matrix2[133][132] = true; adjacency_matrix2[133][134] = true;
            adjacency_matrix2[134][133] = true; adjacency_matrix2[134][135] = true;
            adjacency_matrix2[135][134] = true; adjacency_matrix2[135][136] = true;
            adjacency_matrix2[136][135] = true; adjacency_matrix2[136][137] = true; adjacency_matrix2[136][139] = true;
            adjacency_matrix2[137][136] = true; adjacency_matrix2[137][138] = true;
            adjacency_matrix2[138][137] = true;
            adjacency_matrix2[139][136] = true; adjacency_matrix2[139][141] = true;
            adjacency_matrix2[140][141] = true; adjacency_matrix2[140][143] = true; adjacency_matrix2[140][146] = true;
            adjacency_matrix2[141][140] = true; adjacency_matrix2[141][142] = true; adjacency_matrix2[141][139] = true;
            adjacency_matrix2[142][141] = true;
            adjacency_matrix2[143][146] = true; adjacency_matrix2[143][144] = true; adjacency_matrix2[143][146] = true;
            adjacency_matrix2[144][143] = true; adjacency_matrix2[144][145] = true;
            adjacency_matrix2[145][144] = true;
            adjacency_matrix2[146][143] = true; adjacency_matrix2[146][140] = true; adjacency_matrix2[146][147] = true;
            adjacency_matrix2[147][146] = true; adjacency_matrix2[147][148] = true; adjacency_matrix2[147][149] = true; adjacency_matrix2[147][150] = true;
            adjacency_matrix2[148][147] = true;
            adjacency_matrix2[149][147] = true;
            adjacency_matrix2[150][147] = true; adjacency_matrix2[150][151] = true;
            adjacency_matrix2[151][150] = true; adjacency_matrix2[151][152] = true; adjacency_matrix2[151][153] = true;
            adjacency_matrix2[152][151] = true;
            adjacency_matrix2[153][151] = true;
            adjacency_matrix2[154][132] = true; adjacency_matrix2[154][155] = true;
            adjacency_matrix2[155][154] = true; adjacency_matrix2[155][156] = true;
            adjacency_matrix2[156][157] = true; adjacency_matrix2[156][161] = true; adjacency_matrix2[156][155] = true; adjacency_matrix2[156][183] = true;
            adjacency_matrix2[157][156] = true; adjacency_matrix2[157][158] = true;
            adjacency_matrix2[158][157] = true; adjacency_matrix2[158][159] = true; adjacency_matrix2[158][160] = true;
            adjacency_matrix2[159][158] = true;
            adjacency_matrix2[160][158] = true;
            adjacency_matrix2[161][156] = true; adjacency_matrix2[161][162] = true;
            adjacency_matrix2[162][161] = true; adjacency_matrix2[162][163] = true;
            adjacency_matrix2[163][162] = true; adjacency_matrix2[163][164] = true;
            adjacency_matrix2[164][163] = true; adjacency_matrix2[164][165] = true;
            adjacency_matrix2[165][164] = true; adjacency_matrix2[165][166] = true;
            adjacency_matrix2[166][165] = true; adjacency_matrix2[166][167] = true;
            adjacency_matrix2[167][166] = true; adjacency_matrix2[167][168] = true;
            adjacency_matrix2[168][167] = true; adjacency_matrix2[168][169] = true;
            adjacency_matrix2[169][168] = true; adjacency_matrix2[169][170] = true;
            adjacency_matrix2[170][169] = true; adjacency_matrix2[170][171] = true; adjacency_matrix2[170][172] = true; adjacency_matrix2[170][175] = true;
            adjacency_matrix2[171][170] = true; adjacency_matrix2[171][173] = true; adjacency_matrix2[171][174] = true;
            adjacency_matrix2[172][170] = true; adjacency_matrix2[172][176] = true;
            adjacency_matrix2[173][171] = true; adjacency_matrix2[173][174] = true;
            adjacency_matrix2[174][171] = true; adjacency_matrix2[174][173] = true; adjacency_matrix2[174][177] = true;
            adjacency_matrix2[175][170] = true; adjacency_matrix2[175][178] = true; adjacency_matrix2[175][176] = true;
            adjacency_matrix2[176][172] = true; adjacency_matrix2[176][175] = true; adjacency_matrix2[176][179] = true;
            adjacency_matrix2[177][174] = true; adjacency_matrix2[177][178] = true; adjacency_matrix2[177][180] = true;
            adjacency_matrix2[178][175] = true; adjacency_matrix2[178][177] = true; adjacency_matrix2[178][179] = true;
            adjacency_matrix2[179][176] = true; adjacency_matrix2[179][178] = true; adjacency_matrix2[179][182] = true;
            adjacency_matrix2[180][177] = true; adjacency_matrix2[180][181] = true;
            adjacency_matrix2[181][180] = true; adjacency_matrix2[181][182] = true;
            adjacency_matrix2[182][181] = true; adjacency_matrix2[182][179] = true;
            adjacency_matrix2[183][156] = true; adjacency_matrix2[183][184] = true;
            adjacency_matrix2[184][183] = true; adjacency_matrix2[184][185] = true; adjacency_matrix2[184][188] = true;
            adjacency_matrix2[185][184] = true; adjacency_matrix2[185][186] = true;
            adjacency_matrix2[186][185] = true;
            adjacency_matrix2[187][188] = true; adjacency_matrix2[187][193] = true;
            adjacency_matrix2[188][184] = true; adjacency_matrix2[188][187] = true; adjacency_matrix2[188][189] = true; adjacency_matrix2[188][194] = true;
            adjacency_matrix2[189][188] = true; adjacency_matrix2[189][190] = true; adjacency_matrix2[189][195] = true;
            adjacency_matrix2[190][189] = true; adjacency_matrix2[190][199] = true; adjacency_matrix2[190][191] = true; adjacency_matrix2[190][196] = true;
            adjacency_matrix2[191][190] = true; adjacency_matrix2[191][192] = true; adjacency_matrix2[191][197] = true;
            adjacency_matrix2[192][191] = true; adjacency_matrix2[192][198] = true; adjacency_matrix2[192][200] = true; adjacency_matrix2[192][208] = true;
            adjacency_matrix2[193][194] = true; adjacency_matrix2[193][187] = true;
            adjacency_matrix2[194][188] = true; adjacency_matrix2[194][193] = true; adjacency_matrix2[194][195] = true; adjacency_matrix2[194][203] = true;
            adjacency_matrix2[195][189] = true; adjacency_matrix2[195][194] = true; adjacency_matrix2[195][196] = true; adjacency_matrix2[195][204] = true;
            adjacency_matrix2[196][190] = true; adjacency_matrix2[196][195] = true; adjacency_matrix2[196][197] = true; adjacency_matrix2[196][205] = true;
            adjacency_matrix2[197][198] = true; adjacency_matrix2[197][196] = true; adjacency_matrix2[197][191] = true;
            adjacency_matrix2[198][197] = true; adjacency_matrix2[198][192] = true; adjacency_matrix2[198][206] = true; adjacency_matrix2[198][208] = true;
            adjacency_matrix2[199][190] = true;
            adjacency_matrix2[200][192] = true;
            adjacency_matrix2[201][202] = true;
            adjacency_matrix2[202][201] = true; adjacency_matrix2[202][203] = true;
            adjacency_matrix2[203][202] = true; adjacency_matrix2[203][194] = true; adjacency_matrix2[203][242] = true;
            adjacency_matrix2[204][195] = true; adjacency_matrix2[204][205] = true;
            adjacency_matrix2[205][196] = true; adjacency_matrix2[205][204] = true;
            adjacency_matrix2[206][198] = true; adjacency_matrix2[206][207] = true;
            adjacency_matrix2[207][206] = true;
            adjacency_matrix2[208][192] = true; adjacency_matrix2[208][198] = true; adjacency_matrix2[208][209] = true;
            adjacency_matrix2[209][208] = true; adjacency_matrix2[209][210] = true;
            adjacency_matrix2[210][209] = true; adjacency_matrix2[210][211] = true; adjacency_matrix2[210][218] = true; adjacency_matrix2[210][226] = true;
            adjacency_matrix2[211][210] = true; adjacency_matrix2[211][212] = true;
            adjacency_matrix2[212][211] = true; adjacency_matrix2[212][213] = true;
            adjacency_matrix2[213][212] = true; adjacency_matrix2[213][214] = true;
            adjacency_matrix2[214][213] = true; adjacency_matrix2[214][215] = true; adjacency_matrix2[214][223] = true;
            adjacency_matrix2[215][214] = true; adjacency_matrix2[215][216] = true; adjacency_matrix2[215][224] = true;
            adjacency_matrix2[216][215] = true; adjacency_matrix2[216][217] = true; adjacency_matrix2[216][225] = true;
            adjacency_matrix2[217][216] = true;
            adjacency_matrix2[218][210] = true; adjacency_matrix2[218][219] = true;
            adjacency_matrix2[219][218] = true; adjacency_matrix2[219][220] = true; adjacency_matrix2[219][223] = true; adjacency_matrix2[219][227] = true;
            adjacency_matrix2[220][219] = true; adjacency_matrix2[220][221] = true; adjacency_matrix2[220][224] = true; adjacency_matrix2[220][228] = true;
            adjacency_matrix2[221][220] = true; adjacency_matrix2[221][222] = true; adjacency_matrix2[221][225] = true; adjacency_matrix2[221][229] = true;
            adjacency_matrix2[222][221] = true;
            adjacency_matrix2[223][214] = true; adjacency_matrix2[223][224] = true; adjacency_matrix2[223][219] = true;
            adjacency_matrix2[224][223] = true; adjacency_matrix2[224][215] = true; adjacency_matrix2[224][225] = true; adjacency_matrix2[224][220] = true;
            adjacency_matrix2[225][216] = true; adjacency_matrix2[225][224] = true; adjacency_matrix2[225][221] = true;
            adjacency_matrix2[226][210] = true; adjacency_matrix2[226][230] = true;
            adjacency_matrix2[227][219] = true; adjacency_matrix2[227][228] = true; adjacency_matrix2[227][232] = true;
            adjacency_matrix2[228][220] = true; adjacency_matrix2[228][227] = true; adjacency_matrix2[228][229] = true; adjacency_matrix2[228][233] = true;
            adjacency_matrix2[229][228] = true; adjacency_matrix2[229][221] = true; adjacency_matrix2[229][234] = true;
            adjacency_matrix2[230][226] = true; adjacency_matrix2[230][231] = true; adjacency_matrix2[230][236] = true;
            adjacency_matrix2[231][230] = true; adjacency_matrix2[231][232] = true;
            adjacency_matrix2[232][231] = true; adjacency_matrix2[232][227] = true; adjacency_matrix2[232][233] = true;
            adjacency_matrix2[233][228] = true; adjacency_matrix2[233][232] = true; adjacency_matrix2[233][234] = true;
            adjacency_matrix2[234][229] = true; adjacency_matrix2[234][233] = true; adjacency_matrix2[234][235] = true;
            adjacency_matrix2[235][234] = true;
            adjacency_matrix2[236][230] = true; adjacency_matrix2[236][237] = true;
            adjacency_matrix2[237][236] = true; adjacency_matrix2[237][238] = true;
            adjacency_matrix2[238][237] = true; adjacency_matrix2[238][239] = true;
            adjacency_matrix2[239][238] = true; adjacency_matrix2[239][240] = true;
            adjacency_matrix2[240][239] = true; adjacency_matrix2[240][241] = true;
            adjacency_matrix2[241][240] = true;
            adjacency_matrix2[242][203] = true; adjacency_matrix2[242][243] = true;
            adjacency_matrix2[243][242] = true; adjacency_matrix2[243][244] = true; adjacency_matrix2[243][274] = true;
            adjacency_matrix2[244][243] = true; adjacency_matrix2[244][245] = true;
            adjacency_matrix2[245][244] = true; adjacency_matrix2[245][246] = true;
            adjacency_matrix2[246][245] = true; adjacency_matrix2[246][247] = true;
            adjacency_matrix2[247][246] = true; adjacency_matrix2[247][248] = true;
            adjacency_matrix2[248][247] = true; adjacency_matrix2[248][249] = true; adjacency_matrix2[248][258] = true;
            adjacency_matrix2[249][248] = true; adjacency_matrix2[249][250] = true; adjacency_matrix2[249][251] = true; adjacency_matrix2[249][255] = true;
            adjacency_matrix2[250][249] = true;
            adjacency_matrix2[251][249] = true; adjacency_matrix2[251][252] = true; adjacency_matrix2[251][253] = true;
            adjacency_matrix2[252][251] = true; adjacency_matrix2[252][254] = true;
            adjacency_matrix2[253][251] = true; adjacency_matrix2[253][254] = true; adjacency_matrix2[253][257] = true;
            adjacency_matrix2[254][252] = true; adjacency_matrix2[254][253] = true;
            adjacency_matrix2[255][249] = true; adjacency_matrix2[255][256] = true;
            adjacency_matrix2[256][255] = true; adjacency_matrix2[256][257] = true;
            adjacency_matrix2[257][256] = true; adjacency_matrix2[257][253] = true;
            adjacency_matrix2[258][248] = true; adjacency_matrix2[258][259] = true;
            adjacency_matrix2[259][258] = true; adjacency_matrix2[259][260] = true;
            adjacency_matrix2[260][259] = true; adjacency_matrix2[260][261] = true; adjacency_matrix2[260][265] = true;
            adjacency_matrix2[261][260] = true; adjacency_matrix2[261][262] = true;
            adjacency_matrix2[262][261] = true; adjacency_matrix2[262][263] = true;
            adjacency_matrix2[263][262] = true; adjacency_matrix2[263][264] = true;
            adjacency_matrix2[264][263] = true;
            adjacency_matrix2[265][260] = true; adjacency_matrix2[265][266] = true;
            adjacency_matrix2[266][265] = true; adjacency_matrix2[266][267] = true; adjacency_matrix2[266][268] = true;
            adjacency_matrix2[267][266] = true; adjacency_matrix2[266][269] = true;
            adjacency_matrix2[268][266] = true; adjacency_matrix2[268][270] = true;
            adjacency_matrix2[269][267] = true; adjacency_matrix2[269][271] = true;
            adjacency_matrix2[270][268] = true; adjacency_matrix2[270][273] = true;
            adjacency_matrix2[271][269] = true; adjacency_matrix2[271][272] = true;
            adjacency_matrix2[272][271] = true; adjacency_matrix2[272][273] = true;
            adjacency_matrix2[273][272] = true; adjacency_matrix2[273][270] = true;
            adjacency_matrix2[274][243] = true; adjacency_matrix2[274][275] = true;
            adjacency_matrix2[275][274] = true; adjacency_matrix2[275][276] = true;
            adjacency_matrix2[276][275] = true; adjacency_matrix2[276][277] = true;
            adjacency_matrix2[277][276] = true; adjacency_matrix2[277][278] = true;
            adjacency_matrix2[278][277] = true; adjacency_matrix2[278][279] = true;
            adjacency_matrix2[279][278] = true; adjacency_matrix2[279][280] = true;
            adjacency_matrix2[280][279] = true; adjacency_matrix2[280][281] = true;
            adjacency_matrix2[281][280] = true; adjacency_matrix2[281][301] = true; adjacency_matrix2[281][282] = true;
            adjacency_matrix2[282][281] = true; adjacency_matrix2[282][283] = true;
            adjacency_matrix2[283][282] = true; adjacency_matrix2[283][284] = true;
            adjacency_matrix2[284][283] = true; adjacency_matrix2[284][285] = true;
            adjacency_matrix2[285][284] = true; adjacency_matrix2[285][286] = true;
            adjacency_matrix2[286][285] = true; adjacency_matrix2[286][287] = true;
            adjacency_matrix2[287][286] = true; adjacency_matrix2[287][288] = true; adjacency_matrix2[287][289] = true; adjacency_matrix2[287][291] = true; adjacency_matrix2[287][292] = true;
            adjacency_matrix2[288][287] = true; adjacency_matrix2[288][290] = true;
            adjacency_matrix2[289][287] = true; adjacency_matrix2[289][293] = true;
            adjacency_matrix2[290][288] = true; adjacency_matrix2[290][294] = true;
            adjacency_matrix2[291][287] = true; adjacency_matrix2[291][292] = true; adjacency_matrix2[291][295] = true;
            adjacency_matrix2[292][287] = true; adjacency_matrix2[292][291] = true; adjacency_matrix2[292][296] = true;
            adjacency_matrix2[293][289] = true; adjacency_matrix2[293][297] = true;
            adjacency_matrix2[294][290] = true; adjacency_matrix2[294][298] = true;
            adjacency_matrix2[295][291] = true; adjacency_matrix2[295][296] = true; adjacency_matrix2[295][298] = true; adjacency_matrix2[295][299] = true;
            adjacency_matrix2[296][292] = true; adjacency_matrix2[296][295] = true; adjacency_matrix2[296][297] = true; adjacency_matrix2[296][299] = true; adjacency_matrix2[296][300] = true;
            adjacency_matrix2[297][293] = true; adjacency_matrix2[297][296] = true; adjacency_matrix2[297][300] = true;
            adjacency_matrix2[298][294] = true; adjacency_matrix2[298][295] = true; adjacency_matrix2[298][299] = true;
            adjacency_matrix2[299][295] = true; adjacency_matrix2[299][296] = true; adjacency_matrix2[299][298] = true; adjacency_matrix2[299][300] = true;
            adjacency_matrix2[300][296] = true; adjacency_matrix2[300][297] = true; adjacency_matrix2[300][299] = true;
            adjacency_matrix2[301][281] = true; adjacency_matrix2[301][302] = true;
            adjacency_matrix2[302][301] = true; adjacency_matrix2[302][303] = true; adjacency_matrix2[302][307] = true; adjacency_matrix2[302][309] = true;
            adjacency_matrix2[303][304] = true; adjacency_matrix2[303][302] = true;
            adjacency_matrix2[304][303] = true; adjacency_matrix2[304][305] = true;
            adjacency_matrix2[305][304] = true; adjacency_matrix2[305][306] = true;
            adjacency_matrix2[306][305] = true; adjacency_matrix2[306][307] = true; adjacency_matrix2[306][308] = true;
            adjacency_matrix2[307][306] = true; adjacency_matrix2[307][302] = true;
            adjacency_matrix2[308][306] = true; adjacency_matrix2[308][310] = true;
            adjacency_matrix2[309][302] = true; adjacency_matrix2[309][312] = true;
            adjacency_matrix2[310][308] = true; adjacency_matrix2[310][311] = true;
            adjacency_matrix2[311][310] = true; adjacency_matrix2[311][312] = true; adjacency_matrix2[311][313] = true;
            adjacency_matrix2[312][309] = true; adjacency_matrix2[312][311] = true;
            adjacency_matrix2[313][311] = true; adjacency_matrix2[313][314] = true;
            adjacency_matrix2[314][313] = true; adjacency_matrix2[314][315] = true; adjacency_matrix2[314][317] = true;
            adjacency_matrix2[315][314] = true; adjacency_matrix2[315][316] = true; adjacency_matrix2[315][318] = true;
            adjacency_matrix2[316][315] = true; adjacency_matrix2[316][319] = true;
            adjacency_matrix2[317][314] = true; adjacency_matrix2[317][318] = true;
            adjacency_matrix2[318][315] = true; adjacency_matrix2[318][317] = true; adjacency_matrix2[318][319] = true;
            adjacency_matrix2[319][316] = true; adjacency_matrix2[319][318] = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
