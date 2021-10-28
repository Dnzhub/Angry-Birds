using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;   // static bir de�erin her sahnede farkl� deperi olup ayn� script icinde olmas�d�r
    private Enemy[] _enemies;
    private float nextLevelTimer;


    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }
    void Update()
    {
        foreach(Enemy enemy in _enemies)
        {
            if (enemy != null)
                
                return;
        }
        Debug.Log("You Won !!");
        nextLevelTimer += Time.deltaTime;
        if(nextLevelTimer > 3) { 
        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
        }




    }

}
