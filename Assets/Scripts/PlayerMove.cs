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
    private ParabollicShoot parabollic;//Control the Aim system
    bool isAbleToShoot;

    public int playerSpeed;

    // Update is called once per frame
    void Start(){
        isAbleToShoot = true;
        parabollic = GetComponent<ParabollicShoot>();
    }
    
    void Update()
    {
        if (Input.touchCount > 0 && Input.touchCount < 2)
        {
            fingerPlayer = Input.GetTouch(0);
            fingerPosition = mainCamera.ScreenToWorldPoint(fingerPlayer.position);
            fingerPosition.z = 0;

            lookAtDirection = new Vector3(0,-fingerPosition.y*2.5f,0) -target.position ;
            target.right = lookAtDirection;
            
            if (fingerPlayer.phase == TouchPhase.Ended) {             
                if (isAbleToShoot){
                    var bullet = Instantiate(bulletObj, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                    Shoot();//Disable shoot
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
