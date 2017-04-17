using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   private GameObject enemiesParent;

   void Start()
   {
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
      
   }

   public void Spawn(GameObject enemyPrefab)
   {
      Instantiate(enemyPrefab, transform.position, Quaternion.identity, enemiesParent.transform);
   }
}
