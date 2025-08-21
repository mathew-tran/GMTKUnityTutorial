using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int PlayerScore;
    public GameObject mGameOverScene;
    public Player mPlayer;
 

    [SerializeField]
    private UnityEvent<int> OnPlayerScoreUpdate;

    public UnityEvent OnGameEnd;

    [ContextMenu("Add score")]
    public void AddScore()
    {
        PlayerScore += 1;
        OnPlayerScoreUpdate.Invoke(PlayerScore);
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        mGameOverScene.SetActive(true);
        OnGameEnd.Invoke();
    }
}
