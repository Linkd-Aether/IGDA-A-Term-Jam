using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Grid))]
public class TileRenderer : MonoBehaviour
{
    private float oceanSpeed = Constants.oceanSpd;
    
    private static GameObject oceanPrefab;
    private List<GameObject> oceanRows = new List<GameObject>();

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
        for (int i = 0; i < -Constants.DESPAWN_ZONE; i++)
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

            if (Utils.DiagonalMovement(row, Constants.oceanSpd))
            {
                float overhang = Mathf.Min(0, row.transform.position.y - Constants.DESPAWN_ZONE);
                oceanRows[i] = (Instantiate(oceanPrefab, this.transform));
                oceanRows[i].transform.position = new Vector3(overhang, overhang, 0);
                Destroy(row);
            }
        }
    }
}
