using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfShoot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out WayPointMovement wayPointMovement))
        {
            Debug.Log("должен стрельнуть");
            wayPointMovement.Shoot();
        }
    }
}
