using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   private Spawner[] spawnerList;
   private bool enemiesAlive = false;
   private GameObject enemiesParent;

   void Start()
   {
      spawnerList = FindObjectsOfType<Spawner>();

      if (!GameObject.Find("Enemies"))
      {
         enemiesParent = new GameObject("Enemies");
      }
      else
      {
         enemiesParent = GameObject.Find("Enemies");
      }
   }

   void Update()
   {
      if (enemiesAlive)
      {
         if (enemiesParent.transform.childCount == 0)
         {
            Destroy(GameObject.Find("Obstacles"));
         }
      }
   }

   public void ActivateSpawner(int spawnerIndex, GameObject enemyPrefab, int enemyCount)
   {
      for (int i = 0; i < enemyCount; ++i)
      {
         spawnerList[spawnerIndex].Spawn(enemyPrefab);
         enemiesAlive = true;
      }
   }
}
