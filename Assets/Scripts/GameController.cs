using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    private bool isPaused = false;

    [SerializeField]
    private Canvas titleScreen;
    [SerializeField]
    private Canvas pauseMenu;
    [SerializeField]
    private Canvas mainGameUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause(isPaused);
            

        }


    }

    private void togglePause(bool paused)
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            pauseMenu.GetComponent<Canvas>().enabled = true;
            

        } else
        {
            pauseMenu.GetComponent<Canvas>().enabled = false;

        }
    }

    public static class GameState
    {

        // PAUSED = Main game loop not running. 
        public const int NewgameAtTitle = 0; // newgame at the title Menu PAUSED
        public const int NewgameAtMenu = 1; // new game at the UI Menu PAUSED
        public const int GameStarted = 2; // the main game is running RUNNING
        public const int InProgressPaused = 3; // game is in progress and PAUSED
        public const int GameOver = 4; // game is showing Ending screen with restart option PAUSED
    }
}
