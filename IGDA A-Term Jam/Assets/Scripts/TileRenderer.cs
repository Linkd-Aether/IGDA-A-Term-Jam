using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Grid))]
public class TileRenderer : MonoBehaviour
{
    public float oceanSpeed = 1.2f;
    
    private GameObject oceanPrefab;
    private List<GameObject> oceanRows = new List<GameObject>();
    private int ROW_COUNT = 11;

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
            row.transform.position = new Vector3(i, -i, 0);
            oceanRows.Add(row);
        }
    }

    private void OceanMovement(List<GameObject> rows)
    {
        for (int i = 0; i < rows.Count; i++)
        {
            GameObject row = oceanRows[i];
            Vector3 pos = row.transform.position;
            pos.x += oceanSpeed * Time.deltaTime;
            pos.y -= oceanSpeed * Time.deltaTime;
            row.transform.position = pos;

            if (pos.y <= -ROW_COUNT)
            {
                float overhang = Mathf.Min(0, pos.y + ROW_COUNT);
                oceanRows[i] = (Instantiate(oceanPrefab, this.transform));
                oceanRows[i].transform.position = new Vector3(overhang, overhang, 0);
                Destroy(row);
            }
        }
    }
}
