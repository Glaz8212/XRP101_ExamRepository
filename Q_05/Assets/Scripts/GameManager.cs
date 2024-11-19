using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public float Score { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            SingletonInit();
            Score = 0.1f;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(int buildIndex)
    {
        Debug.Log($"{buildIndex}æ¿¿∏∑Œ ¿Ãµø");
        SceneManager.LoadScene(buildIndex);
    }
}
