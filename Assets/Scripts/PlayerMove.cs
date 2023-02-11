using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Touch fingerPlayer;
    private Vector3 fingerPosition;
    [SerializeField] private Camera mainCamera;
    private Vector3 lookAtDirection;

    public GameObject bulletObj;
    public Transform bulletSpawnPoint;
    public float bulletSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touchCount < 2)
        {
            fingerPlayer = Input.GetTouch(0);
            fingerPosition = mainCamera.ScreenToWorldPoint(fingerPlayer.position);
            fingerPosition.z = 0;

            lookAtDirection = fingerPosition - target.position;
            target.right = lookAtDirection;

            
            if (fingerPlayer.phase == TouchPhase.Ended) {
                Debug.Log("FIREEE!!");
                var bullet = Instantiate(bulletObj, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
            }

        }

    }


}
