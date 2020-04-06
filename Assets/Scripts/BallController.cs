using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    private bool StartPositionIsCompleted = false;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, GameController.instance.ballStartSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d.transform.position.y < -3.0f && !StartPositionIsCompleted)
        {
            Debug.Log("Suka");
            rb2d.velocity = Vector2.zero;
            StartPositionIsCompleted = true;
        } 
    }
}
