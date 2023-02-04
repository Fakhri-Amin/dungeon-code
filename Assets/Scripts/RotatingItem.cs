using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingItem : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject explodeVFX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
    }

    public void Destroyed()
    {
        var vfx = Instantiate(explodeVFX, transform.position, Quaternion.identity);
        Destroy(vfx, 2f);
        gameObject.SetActive(false);
    }
}
