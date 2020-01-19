using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GamePaused = false;
    [SerializeField] private Player player;
    [SerializeField] private CameraMovement mainCamera;
    [SerializeField] private Transform checkpoint;
    [SerializeField] private float respawnTime = 1;
    [SerializeField] private Player playerPrefab;
    [SerializeField] private WinLevelTrigger Win;
    [SerializeField] private GameObject CompleteLevelUI;
    [SerializeField] private GameObject PauseMenu;


    private void Start()
    {
        player.Died += OnPlayerDie;
        Win.PlayerWon += ShowWinScreen;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            ShowPauseMenu();
        }
    }

    private void OnPlayerDie()
    {
        Debug.LogError("OMG THE WOLF IS DEAD =(");
        StartCoroutine(RespawnPlayer());
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(respawnTime);
        Player NewPlayer = Instantiate<Player>(playerPrefab, checkpoint.position, Quaternion.identity);
        mainCamera.playerTransform = NewPlayer.gameObject.transform;

        player = NewPlayer;
        player.Died += OnPlayerDie;
    }

    public void SetActiveCheckpoint(Transform transform)
    {
        checkpoint = transform;
    }

    private void ShowWinScreen()
    {
        GamePaused = !GamePaused;
        Win.PlayerWon -= ShowWinScreen;
        CompleteLevelUI.SetActive(true);
    }

    public void ShowPauseMenu()
    {
        GamePaused = !GamePaused;
        PauseMenu.SetActive(GamePaused);
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
