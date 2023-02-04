using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;

public class NumberCollectableItem : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private GameObject explodeVFX;

    public bool isOnce;

    // Update is called once per frame
    void Update()
    {

    }

    public void Destroyed()
    {
        var vfx = Instantiate(explodeVFX, transform.position, Quaternion.identity);
        Destroy(vfx, 2f);

        if (isOnce) return;
        BE2_VariablesListManager.instance.AddValueInList("Daftar angka", number.ToString());
        gameObject.SetActive(false);
        isOnce = true;
    }
}
