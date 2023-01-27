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
        }

    }
}
