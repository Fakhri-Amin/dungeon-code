using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;

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

    public IEnumerator SetWinCondition()
    {
        yield return new WaitForSeconds(0.2f);
        var vfx = Instantiate(winVFX, transform.position, Quaternion.identity);
        Destroy(vfx, 3f);

        BE2_AudioManager.instance.PlaySound(2);
        yield return new WaitForSeconds(3f);
        Go();
        // Invoke("Go", 3f);
    }

    private void Go()
    {
        winUI.SetActive(true);
    }
}
