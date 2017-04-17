using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   private Spawner[] spawnerList;

   void Start()
   {
      spawnerList = FindObjectsOfType<Spawner>();
   }

   void Update()
   {

   }

   public void ActivateSpawner(int spawnerIndex, GameObject enemyPrefab, int enemyCount)
   {
      for (int i = 0; i < enemyCount; ++i)
      {
         spawnerList[spawnerIndex].Spawn(enemyPrefab);
      }
   }
}
