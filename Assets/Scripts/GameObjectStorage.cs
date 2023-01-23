using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectStorage : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject runeGoal;

    public GameObject GetPlayer() { return player; }
    public GameObject GetRuneGoal() { return runeGoal; }

}
