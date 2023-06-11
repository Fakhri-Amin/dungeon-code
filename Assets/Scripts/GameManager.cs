using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isRunning = false;
    public bool isNoDelay = false;
    public List<int> numberList;

    private NumberCollectableItem[] numberArrays;
    private GameObject player;
    private PlayerAnimation playerAnimation;
    private Vector3 playerPosition;
    private Vector3 playerRotation;
    private RotatingItem rotatingItem;
    private CollisionHandler collisionHandler;

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
        rotatingItem = FindObjectOfType<RotatingItem>();
        collisionHandler = FindObjectOfType<CollisionHandler>();
        // collisionHandler = FindObjectOfType<CollisionHandler>();
    }

    void Start()
    {
        playerPosition = player.transform.position;
        playerRotation = player.transform.eulerAngles;

        numberArrays = FindObjectsOfType<NumberCollectableItem>();
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
        playerAnimation.SetReachedAnimation(false);
        collisionHandler.isPlayed = false;

        foreach (NumberCollectableItem number in numberArrays)
        {
            number.gameObject.SetActive(true);
            number.isOnce = false;
        }

        BE2_VariablesListManager.instance.ClearList("Daftar angka");

        if (!rotatingItem) return;
        rotatingItem.gameObject.SetActive(true);

        // Time.timeScale = 1;
        // collisionHandler.SetActiveToFalse();
    }

    public void ListenBack()
    {
        BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPlay, OnButtonPlay);
        BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnStop, OnButtonStop);
    }

}
