using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    [SerializeField] private GameObject winUI;

    // Start is called before the first frame update
    void Start()
    {
        winUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetWinUI()
    {
        Invoke("Go", 1f);
    }

    private void Go()
    {
        winUI.SetActive(true);
    }
}
