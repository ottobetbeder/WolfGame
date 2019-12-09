using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private CameraMovement mainCamera;
    [SerializeField] private Transform checkpoint;
    [SerializeField] private float respawnTime = 1;

    [SerializeField] private Player playerPrefab;

    private void Start()
    {
        player.Died += OnPlayerDie; 
    }

    private void OnPlayerDie()
    {
        Debug.LogError("OMG THE WOLF IS DEAD =(");
        StartCoroutine(RespawnPlayer());
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(respawnTime);//see the time
        Player NewPlayer = Instantiate<Player>(playerPrefab, checkpoint);
        mainCamera.playerTransform = NewPlayer.gameObject.transform;

        player = NewPlayer;
        player.Died += OnPlayerDie;
    }
}
