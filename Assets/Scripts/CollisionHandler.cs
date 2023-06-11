using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float runeGoalDetectRange = 0.5f;
    [SerializeField] private float obstacleDetectRange = 0.4f;
    [SerializeField] private float itemDetectRange = 0.5f;
    private WinLoseManager winLoseManager;
    private PlayerAnimation playerAnimation;
    private Animator animator;

    protected virtual void OnButtonPlay() { }
    protected virtual void OnButtonStop() { }

    public bool isPlayed;

    private void Awake()
    {
        winLoseManager = GetComponent<WinLoseManager>();
        playerAnimation = GetComponent<PlayerAnimation>();
        animator = GetComponent<Animator>();
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
        GetCollidingItemInfo();
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    private void GetObstacleInfo()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 0.25f, transform.forward, out hit, obstacleDetectRange) || Physics.Raycast(transform.position + Vector3.up * 0.25f, -transform.forward, out hit, obstacleDetectRange))
        {
            if (hit.collider.gameObject.GetComponent<Obstacle>())
            {
                playerAnimation.SetDieAnimation(true);
                BE2_ExecutionManager.Instance.Stop();
            }
        }
        Debug.DrawRay(transform.position + Vector3.up * 0.25f, transform.forward * obstacleDetectRange, Color.red);
    }

    private void GetCollidingItemInfo()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 1.5f, -transform.up, out hit, runeGoalDetectRange))
        {
            if (hit.collider.gameObject.TryGetComponent<RotatingItem>(out RotatingItem rotatingItem))
            {
                rotatingItem.Destroyed();
            }

            if (hit.collider.gameObject.TryGetComponent<NumberCollectableItem>(out NumberCollectableItem numberCollectableItem))
            {
                numberCollectableItem.Destroyed();
            }
        }
        Debug.DrawRay(transform.position + Vector3.up * 1.5f, -transform.up * runeGoalDetectRange, Color.red);

    }

    private void StopTheExecution()
    {
        BE2_ExecutionManager.Instance.Stop();
    }

    public void CheckNumberList()
    {
        string listName = "Daftar angka";
        List<int> numberList = GameManager.Instance.numberList;
        BE2_VariablesListManager variableManager = BE2_VariablesListManager.instance;
        if (!variableManager.ContainsList(listName)) return;

        if (numberList.Count != variableManager.lists[listName].Count) return;

        for (int i = 0; i < variableManager.GetListStringValues(listName).Count; i++)
        {
            if (variableManager.GetListValue(listName, i).floatValue != numberList[i])
            {
                return;
            }
            else
            {
                continue;
            }
        }

        StopTheExecution();
        playerAnimation.SetReachedAnimation(true);
        if (isPlayed) return;
        StartCoroutine(winLoseManager.SetWinCondition());
        isPlayed = true;
    }

    public void CheckRuneGoal()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 1.5f, -transform.up, out hit, runeGoalDetectRange))
        {
            if (hit.collider.gameObject.GetComponent<RuneGoal>())
            {
                StopTheExecution();
                playerAnimation.SetReachedAnimation(true);
                if (isPlayed) return;
                StartCoroutine(winLoseManager.SetWinCondition());
                isPlayed = true;
            }
        }

    }
}



