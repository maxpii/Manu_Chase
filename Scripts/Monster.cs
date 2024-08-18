using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{


    [HideInInspector]
    public float speed;
    // Start is called before the first frame update

    private Rigidbody2D mybody;
    void Start()
    {
        speed = 5;
        mybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // change x velocity to "speed" and keep the y velocity the same
        mybody.velocity = new Vector2(speed, mybody.velocity.y);
    }
}
