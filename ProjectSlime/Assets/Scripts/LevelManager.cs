using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   private GameObject player;

   void Start()
   {
      DontDestroyOnLoad(gameObject);
   }

   public void LoadLevel(string levelName)
   {
      SceneManager.LoadScene(levelName);
   }

   public void LoadNextLevel()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void Quit()
   {
      Application.Quit();
   }

   void OnEnable()
   {
      SceneManager.sceneLoaded += OnLevelLoaded;
   }

   void OnDisable()
   {
      SceneManager.sceneLoaded -= OnLevelLoaded;
   }

   void OnLevelLoaded(Scene scene, LoadSceneMode mode)
   {
      player = GameObject.FindGameObjectWithTag("Player");
      GameObject playerSpawner = GameObject.Find("PlayerSpawn");
      Debug.Log(player);
      Debug.Log(playerSpawner);

      if (playerSpawner)
      {
         player.transform.position = playerSpawner.transform.position;
      }
      else
      {
         Debug.LogWarning("Must have PlayerSpawn object in the scene");
      }
   }
}
