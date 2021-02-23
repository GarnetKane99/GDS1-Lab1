using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    private Vector2 ScreenBounds;
    [SerializeField]
    private float HeliWidth, HeliHeight;

    // Start is called before the first frame update
    void Start()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        HeliWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        HeliHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 CameraPos = transform.position;
        CameraPos.x = Mathf.Clamp(CameraPos.x, ScreenBounds.x * - 1 + HeliWidth, ScreenBounds.x - HeliWidth);
        CameraPos.y = Mathf.Clamp(CameraPos.y, ScreenBounds.y * - 1 + HeliHeight, ScreenBounds.y - HeliHeight);
        transform.position = CameraPos;
    }
}
