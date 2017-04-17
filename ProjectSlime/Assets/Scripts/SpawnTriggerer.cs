using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTriggerer : MonoBehaviour
{
   [SerializeField] private int[] spawnerIndex;
   [SerializeField] private GameObject[] enemies;
   [SerializeField] private int[] enemiesCount;
   private bool hasSpawned = false;
   private SpawnManager spawnManager;

   void Start()
   {
      spawnManager = FindObjectOfType<SpawnManager>();

      if (enemies.Length != enemiesCount.Length)
      {
         Debug.LogWarning("Enemies and enemies count arrays must be of same size");
      }
   }

   void Update()
   {

   }

   void OnTriggerEnter2D(Collider2D collider)
   {
      if (collider.GetComponent<PlayerController>() && !hasSpawned)
      {
         hasSpawned = true;

         for (int i = 0; i < spawnerIndex.Length; i++)
         {
            for (int j = 0; j < enemies.Length; ++j)
            {
               spawnManager.ActivateSpawner(spawnerIndex[i], enemies[j], enemiesCount[j]);
            }
         }
      }
   }
}
