using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG_BlocksEngine2.Core;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isRunning = false;

    private GameObject player;
    private PlayerAnimation playerAnimation;
    private Vector3 playerPosition;
    private Vector3 playerRotation;

    protected virtual void OnButtonPlay() { }
    protected virtual void OnButtonStop() { }

    private void Awake()
    {
        // if (FindObjectsOfType(GetType()).Length > 1)
        if (Instance != null && Instance != this)
        {
            // gameObject.SetActive(false);
            Destroy(this);
            return;
        }
        Instance = this;
        Time.timeScale = 1;
        // DontDestroyOnLoad(gameObject);

        player = FindObjectOfType<GameObjectStorage>().GetPlayer();
        playerAnimation = FindObjectOfType<PlayerAnimation>();
        // collisionHandler = FindObjectOfType<CollisionHandler>();
    }

    void Start()
    {
        playerPosition = player.transform.position;
        playerRotation = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetPlayerPosition()
    {
        player.transform.position = playerPosition;
        player.transform.rotation = Quaternion.Euler(playerRotation);
        playerAnimation.SetDieAnimation(false);
        // Time.timeScale = 1;
        // collisionHandler.SetActiveToFalse();
    }

    public void ListenBack()
    {
        BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPlay, OnButtonPlay);
        BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnStop, OnButtonStop);
    }

}
