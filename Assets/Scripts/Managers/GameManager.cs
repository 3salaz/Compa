using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;

    // Define game states
    public enum GameState { MainMenu, Playing, Cutscene, Paused, GameOver }
    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        // Singleton pattern to ensure only one GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist through scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to load scenes
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // Asynchronous scene loading with optional loading screen
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // Optional: Show a loading screen here
        yield return SceneManager.LoadSceneAsync(sceneName);
        // Optional: Hide the loading screen here
    }

    // Method to handle cutscene completion
    public void OnCutsceneComplete()
    {
        // Update the game state
        SetGameState(GameState.Playing);

        // Load the main gameplay scene after the cutscene
        LoadScene("GameplayScene"); // Replace with your actual gameplay scene name
    }

    // Set the current game state
    public void SetGameState(GameState newState)
    {
        CurrentState = newState;
        // Handle actions based on the new state
        switch (newState)
        {
            case GameState.MainMenu:
                // Handle Main Menu state
                break;
            case GameState.Playing:
                // Handle Playing state
                break;
            case GameState.Cutscene:
                // Handle Cutscene state
                break;
            case GameState.Paused:
                // Handle Paused state
                break;
            case GameState.GameOver:
                // Handle Game Over state
                break;
        }
    }

    // Example method to pause the game
    public void PauseGame()
    {
        SetGameState(GameState.Paused);
        Time.timeScale = 0f; // Pause the game
    }

    // Example method to resume the game
    public void ResumeGame()
    {
        SetGameState(GameState.Playing);
        Time.timeScale = 1f; // Resume the game
    }

    // Example method to handle game over
    public void GameOver()
    {
        SetGameState(GameState.GameOver);
        // Load Game Over scene or show Game Over UI
        LoadScene("GameOverScene"); // Replace with your actual game over scene name
    }
}
