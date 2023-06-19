using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;

using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;

public class PlayerMovements : BE2_InstructionBase
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.5f;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isMoving)
        {
            StartCoroutine(MovePlayer(transform.forward));
        }
        if (Input.GetKey(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MovePlayer(-transform.forward));
        }
        if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            StartCoroutine(FaceDirection(new Vector3(0, 90, 0)));

        }
        if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            StartCoroutine(FaceDirection(new Vector3(0, -90, 0)));
        }

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }


    }

    public IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        // origPos = transform.position;
        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // transform.position = targetPos;
        transform.position = targetPos;

        isMoving = false;
    }

    private IEnumerator FaceDirection(Vector3 direction)
    {
        isMoving = true;
        Quaternion initialRotation = transform.rotation;

        float elapsedTime = 0f;

        while (elapsedTime < timeToMove)
        {
            elapsedTime += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(initialRotation, initialRotation * Quaternion.Euler(direction.x, direction.y, direction.z), (elapsedTime / timeToMove));
            yield return null;
        }

        isMoving = false;
    }
}
