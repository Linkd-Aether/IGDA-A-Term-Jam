using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Grid))]
public class TileRenderer : MonoBehaviour
{
    private float oceanSpeed = Constants.oceanSpd;
    
    private static GameObject oceanPrefab;
    private List<GameObject> oceanRows = new List<GameObject>();
    private int ROW_COUNT = 10;

    void Start()
    {
        oceanPrefab = (GameObject)Resources.Load("Sprites/Tilesets/Prefabs/OceanRow");
        GenerateOcean(oceanRows);
    }

    void Update()
    {
        OceanMovement(oceanRows);
    }

    private void GenerateOcean(List<GameObject> rows)
    {
        for (int i = 0; i < ROW_COUNT; i++)
        {
            GameObject row = Instantiate(oceanPrefab, this.transform);
            row.transform.position = new Vector3(0, -i*Mathf.Sqrt(2), 0);
            oceanRows.Add(row);
        }
    }

    private void OceanMovement(List<GameObject> rows)
    {
        for (int i = 0; i < rows.Count; i++)
        {
            GameObject row = oceanRows[i];

            if (Utils.DownwardMovement(row, Constants.oceanSpd))
            {
                Vector3 pos = row.transform.position;
                pos.y += ROW_COUNT * Mathf.Sqrt(2);
                row.transform.position = pos;
            }
        }
    }
}
