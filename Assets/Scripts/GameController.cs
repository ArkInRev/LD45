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
    [SerializeField]
    private Canvas ExitUI;
    [SerializeField]
    private int SpiritCount;
    [SerializeField]
    private TMP_Text SpiritCountText;

    [SerializeField]
    private TMP_Text skullCount;
    [SerializeField]
    private TMP_Text ExitTextField;

    [SerializeField]
    private string winTextString;
    [SerializeField]
    private string loseTextString;



    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SpiritCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause(isPaused);
            

        }
        SpiritCountText.text = SpiritCount.ToString();


    }

    private void togglePause(bool paused)
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            pauseMenu.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;

        } else
        {
            pauseMenu.GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;

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

    public int GetSpirit()
    {
        return SpiritCount;
    }

    public void UpdateSpirit(int amount)
    {
        SpiritCount += amount;
        if (SpiritCount <= 0) SpiritCount = 0;
    }

    public void FoundExit()
    {
        skullCount.text = SpiritCount.ToString();
        ExitTextField.text = winTextString;

        titleScreen.enabled = false;
        pauseMenu.enabled = false;
        mainGameUI.enabled = false;


        ExitUI.enabled = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayerDied()
    {
        skullCount.text = SpiritCount.ToString();
        ExitTextField.text = loseTextString;

        titleScreen.enabled = false;
        pauseMenu.enabled = false;
        mainGameUI.enabled = false;


        ExitUI.enabled = true;
    }
}
