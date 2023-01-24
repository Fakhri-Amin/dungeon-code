using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float runeGoalDetectRange = 0.5f;
    [SerializeField] private float ObstacleDetectRange = 0.4f;
    private WinLoseManager winLoseManager;
    private PlayerAnimation playerAnimation;

    protected virtual void OnButtonPlay() { }
    protected virtual void OnButtonStop() { }

    private bool isPlayed;

    private void Awake()
    {
        winLoseManager = GetComponent<WinLoseManager>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetObstacleInfo();
        GetRuneGoalInfo();
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    private void GetObstacleInfo()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 0.25f, transform.forward, out hit, ObstacleDetectRange))
        {
            if (hit.collider.gameObject.GetComponent<Obstacle>())
            {
                Debug.Log("We hit Obstacle!");
                Debug.Log("There is an obstacle!");
                playerAnimation.SetDieAnimation(true);
                BE2_ExecutionManager.Instance.Stop();
            }
        }
        Debug.DrawRay(transform.position + Vector3.up * 0.25f, transform.forward * ObstacleDetectRange, Color.red);
    }

    private void GetRuneGoalInfo()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 0.5f, -transform.up, out hit, runeGoalDetectRange))
        {
            if (hit.collider.gameObject.GetComponent<RuneGoal>())
            {
                Debug.Log("We hit Rune Goal!");
                if (GameManager.Instance.isRunning) return;
                BE2_ExecutionManager.Instance.Stop();
                winLoseManager.SetWinUI();

                if (isPlayed) return;
                BE2_AudioManager.instance.PlaySound(2);
                isPlayed = true;
            }
        }
        Debug.DrawRay(transform.position + Vector3.up * 0.5f, -transform.up * runeGoalDetectRange, Color.red);
    }

    private void OnTriggerStay(Collider other)
    {
        // Debug.Log(GameManager.Instance.isRunning.ToString());
        // if (GameManager.Instance.isRunning) return;

        // winLoseManager.SetWinUI();
    }

    // public void CheckObstacleInFront()
    // {
    //     if (GetObstacleInFront())
    //     {
    //         Debug.Log("There is an obstacle!");
    //         playerAnimation.SetDieAnimation(true);
    //         FindObjectOfType<BE2_BlocksStack>().IsActive = false;
    //     }
    // }

    // public bool GetObstacleInFront()
    // {
    //     RaycastHit hit;
    //     if (Physics.Raycast(transform.position + Vector3.up * 0.5f, transform.forward, out hit, detectRange))
    //     {
    //         if (hit.collider.gameObject.GetComponent<Obstacle>())
    //         {
    //             return true;
    //         }
    //     }
    //     return false;
    // }
}



