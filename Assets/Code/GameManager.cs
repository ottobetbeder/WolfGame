using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private CameraMovement mainCamera;
    [SerializeField] private Transform checkpoint;
    [SerializeField] private float respawnTime = 1;
    [SerializeField] private Player playerPrefab;
    [SerializeField] private WinLevelTrigger Win;
    [SerializeField] private GameObject CompleteLevelUI;

    private void Start()
    {
        player.Died += OnPlayerDie;
        Win.PlayerWon += ShowWinScreen;
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
        Win.PlayerWon -= ShowWinScreen;
        CompleteLevelUI.SetActive(true);
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
