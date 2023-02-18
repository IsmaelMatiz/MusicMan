using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]Transform target;

    Transform myTransform;
    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        SetTarget(target);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = target.position + offset;
    }
    /**
    * Remember the thing is use Triggers to change the target in that way you can jus invoke this function
    */
    public void SetTarget(Transform target)
    {
        this.target = target;
    }


}
