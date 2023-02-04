using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    [SerializeField] private GameObject winUI;

    [SerializeField] private GameObject winVFX;

    // Start is called before the first frame update
    void Start()
    {
        winUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetWinCondition()
    {
        var vfx = Instantiate(winVFX, transform.position, Quaternion.identity);
        Destroy(vfx, 3f);

        Invoke("Go", 3f);
    }

    private void Go()
    {
        winUI.SetActive(true);
    }
}
