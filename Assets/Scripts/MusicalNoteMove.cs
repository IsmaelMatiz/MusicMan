using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalNoteMove : MonoBehaviour
{
    private Transform pivot;
    private float springRange;
    private float maxVel;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
