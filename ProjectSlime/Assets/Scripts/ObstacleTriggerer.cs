using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTriggerer : MonoBehaviour
{
   [SerializeField] private Sprite obstacleTexture;
   [SerializeField] private Vector2[] obstacleLocations;
   private GameObject obstaclesParent;

   void Start()
   {
      if (!GameObject.Find("Obstacles"))
      {
         obstaclesParent = new GameObject("Obstacles");
      }
      else
      {
         obstaclesParent = GameObject.Find("Obstacles");
      }
   }

   void OnTriggerEnter2D(Collider2D collider)
   {
      if (collider.GetComponent<PlayerController>())
      {
         for (int i = 0; i < obstacleLocations.Length; ++i)
         {
            Debug.Log(i);
            GameObject go = new GameObject("Obstacle");
            go.transform.localScale = new Vector3(4f, 4f, 0);
            go.AddComponent<SpriteRenderer>();
            go.AddComponent<Rigidbody2D>();
            go.AddComponent<BoxCollider2D>();
            go.GetComponent<SpriteRenderer>().sprite = obstacleTexture;
            go.GetComponent<SpriteRenderer>().sortingOrder = 10;
            go.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            go.AddComponent<BoxCollider2D>().size = new Vector3(0.25f, 0.25f, 0);
            go.transform.position = new Vector3(obstacleLocations[i].x, obstacleLocations[i].y, 0);
            go.transform.parent = obstaclesParent.transform;
         }
      }
   }
}
