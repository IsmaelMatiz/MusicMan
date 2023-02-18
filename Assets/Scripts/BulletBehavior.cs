using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    GameObject spawn;
    CameraFollow follow;

    void Start (){
        follow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        spawn = GameObject.FindGameObjectWithTag("Spawn");
    }

    void OnCollisionEnter2D(Collision2D collision){
        Invoke("GoToSpawn", 2f);
        Destroy(gameObject,5);
    }

    void GoToSpawn(){
        follow.SetTarget(spawn.GetComponent<Rigidbody2D>().transform);
    }
}
