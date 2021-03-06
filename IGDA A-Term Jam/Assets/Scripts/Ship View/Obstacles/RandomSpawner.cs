﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    private float spawnCheckInterval = .5f;
    public float spawnTimeVariance = .5f;

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
        List<GameObject> rocks = new List<GameObject>
        {
            Resources.Load<GameObject>("Prefabs/Rocks/Cluster/RockCluster1"),
            Resources.Load<GameObject>("Prefabs/Rocks/Cluster/RockCluster2"),
            Resources.Load<GameObject>("Prefabs/Rocks/Cluster/RockCluster3"),
            Resources.Load<GameObject>("Prefabs/Rocks/Cluster/RockCluster4"),
            Resources.Load<GameObject>("Prefabs/Rocks/Cluster/RockCluster5")
        };
        types[0] = new SpawnObject(rocks, Constants.rockSpawnTime);

        List<GameObject> waves = new List<GameObject>
        {
            Resources.Load<GameObject>("Sprites/Tilesets/Prefabs/Wave")
        };
        types[1] = new SpawnObject(waves, Constants.waveSpawnTime);

        List<GameObject> enemies = new List<GameObject>
        {
            Resources.Load<GameObject>("Prefabs/Ships/EnemyShip")
        };
        types[2] = new SpawnObject(enemies, Constants.enemySpawnTime);

        if(Constants.spawning)InvokeRepeating("SpawnObstacles", 0f, spawnCheckInterval);
    }

    private void SpawnObstacles()
    {
        foreach(SpawnObject type in types)
        {
            if (type.timeSinceLastSpawn > Random.Range(1 - spawnTimeVariance, 1 + spawnTimeVariance) * type.timeBetweenSpawns)
            {
                Instantiate(type.objVariants[(Random.Range(0, type.objVariants.Count - 1))], this.transform);
                type.timeSinceLastSpawn = 0;
            }
            type.timeSinceLastSpawn += spawnCheckInterval;
        }    
    }
}
