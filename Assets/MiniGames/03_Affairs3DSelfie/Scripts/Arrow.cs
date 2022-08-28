using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArrowType
{
    Up = 0,
    Left = 90,
    Down = 180,
    Right = 270,
    None,


}

public class Arrow : MonoBehaviour
{
    public ArrowType arrowType;

    Rigidbody2D rb2d;
    int speed = 100;
 
    private void Awake()
    {
        transform.localRotation = Quaternion.Euler(0, 0, (int)arrowType);
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb2d.AddForce(Vector3.left * speed, ForceMode2D.Impulse);
    }
}
