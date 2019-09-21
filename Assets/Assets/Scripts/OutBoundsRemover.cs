using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutBoundsRemover : MonoBehaviour
{
    public float limit = 1.2f;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(
                Screen.width,
                Screen.height,
                Camera.main.transform.position.z
                )
            );

        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;

        if (
            viewPos.x < (screenBounds.x * -1 - objectWidth) * limit
            || viewPos.x > (screenBounds.x + objectWidth) * limit
            || viewPos.y < (screenBounds.y * -1 - objectHeight) * limit
            || viewPos.y > (screenBounds.y + objectHeight) * limit
            )
        {
            Destroy(this.gameObject);
        }
    }
}
