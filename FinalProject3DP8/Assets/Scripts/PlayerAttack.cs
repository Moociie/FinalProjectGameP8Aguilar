using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePosition;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            var bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            bullet.GetComponent<Rigidbody>().velocity = firePosition.forward * bulletSpeed;

        }
    }
}
