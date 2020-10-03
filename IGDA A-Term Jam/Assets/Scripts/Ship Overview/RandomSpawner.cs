using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    class SpawnObject
    {
        public List<GameObject> objVariants = new List<GameObject>();
        public float timeSinceLastSpawn = 0;
        public float timeBetweenSpawns;
        

        public SpawnObject(List<GameObject> obj, float time)
        {
            this.objVariants = obj;
            this.timeBetweenSpawns = time;
        }
    }

    static SpawnObject[] types = new SpawnObject[3];

    void Start()
    {
        List<GameObject> singleRocks = new List<GameObject>
        {
            Resources.Load<GameObject>("Prefabs/Rocks/Single/Rock1"),
            Resources.Load<GameObject>("Prefabs/Rocks/Single/Rock2")
        };
        types[0] = new SpawnObject(singleRocks, 5);

        List<GameObject> largeRocks = new List<GameObject>
        {
            Resources.Load<GameObject>("Prefabs/Rocks/Cluster/RockCluster1"),
            Resources.Load<GameObject>("Prefabs/Rocks/Cluster/RockCluster2")
        };
        types[1] = new SpawnObject(largeRocks, 8);

        List<GameObject> waves = new List<GameObject>
        {
            Resources.Load<GameObject>("Sprites/Tilesets/Prefabs/Wave")
        };
        types[2] = new SpawnObject(waves, 10);
    }

    void Update()
    {
        foreach(SpawnObject type in types)
        {
            if (type.timeSinceLastSpawn > Random.Range(0.8f, 1.2f) * type.timeBetweenSpawns)
            {
                Instantiate(type.objVariants[(Random.Range(0, type.objVariants.Count - 1))], this.transform);
                type.timeSinceLastSpawn = 0;
            }
            type.timeSinceLastSpawn += Time.deltaTime;
        }    
    }
}
