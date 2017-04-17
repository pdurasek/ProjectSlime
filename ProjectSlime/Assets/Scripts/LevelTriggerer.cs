using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTriggerer : MonoBehaviour
{
   private LevelManager levelManager;
   private GameObject player;

   void Start()
   {
      levelManager = FindObjectOfType<LevelManager>();
      player = GameObject.FindGameObjectWithTag("Player");
   }

   void OnTriggerEnter2D(Collider2D collider)
   {
      if (collider.GetComponent<PlayerController>())
      {
         player.transform.Translate(new Vector3(100, 100, 0));
         levelManager.LoadNextLevel();
      }
   }
}
