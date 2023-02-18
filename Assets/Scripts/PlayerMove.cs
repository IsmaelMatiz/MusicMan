using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform target;//what object do i need to move
    private Touch fingerPlayer;//Get the screen inputs
    private Vector3 fingerPosition;
    [SerializeField] private Camera mainCamera;// this is also usegul to aim
    private Vector3 lookAtDirection;// how to aim
    public GameObject bulletObj;//var of the object that will be the bullet
    public Transform bulletSpawnPoint;// Where shoot the Bullet
    public float bulletSpeed;//The name just say everything
    CameraFollow follow;//get the camera script
    bool isAbleToShoot;


    // Update is called once per frame
    void Start(){
        follow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        isAbleToShoot = true;
    }
    
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
                Debug.Log("Intentaron disparar y is able to shoot es: "+isAbleToShoot);
                if (isAbleToShoot){
                    var bullet = Instantiate(bulletObj, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                    bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
                    follow.SetTarget(bullet.GetComponent<Rigidbody2D>().transform);
                    Shoot();//Disable shoot again
                    Invoke("Shoot",6f);
                }
            }

        }

    }

    //the Only purpose of this function is to indicate if we can shoot or no
    public void Shoot(){
        if (isAbleToShoot){
            isAbleToShoot = false;
        }else{
            isAbleToShoot = true;
        }
    }


}
