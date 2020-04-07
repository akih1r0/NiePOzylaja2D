using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    private bool StartPositionIsCompleted = false;
    private bool tap, swipeUp, doubleTap;
    private Vector2 swipeDelta, startTouch;
    public float deadZone = 100f;
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
          
            rb2d.velocity = Vector2.zero;
            StartPositionIsCompleted = true;
        }

        tap = swipeUp = doubleTap = false;
        //Check for input
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase==TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.mousePosition;

            }
            else if (Input.touches[0].phase==TouchPhase.Ended|| Input.touches[0].phase==TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;
            }
        }


        //Calculate swipes
        swipeDelta = Vector2.zero;
        if (startTouch!=Vector2.zero)
        {
            if (Input.touches.Length!=0)
            {
                swipeDelta = Input.touches[0].position - startTouch; //swipe exist
            }
            
        }

        if (swipeDelta.magnitude>deadZone)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(y)>Mathf.Abs(x))
            {
                if (y>0)
                {
                    swipeUp = true;
                    gameObject.SetActive(false);
                }
            }
        }
        else if (Input.touches.Length != 0)
        { 
            tap = true;
            transform.Translate(0, 4, 0);
        }

    }
}
