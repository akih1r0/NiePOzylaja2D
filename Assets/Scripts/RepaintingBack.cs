using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepaintingBack : MonoBehaviour
{
    private BoxCollider2D boxColl;
    private float lenght;

    // Start is called before the first frame update
    void Start()
    {
        boxColl = GetComponentInChildren<BoxCollider2D>();
        lenght = 2*boxColl.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y< -lenght)
        {
            RepositionBack();
        }
    }
    private void RepositionBack()
    {
        Vector2 groundOffset = new Vector2(0, lenght * 2f);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
