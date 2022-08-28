using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
    Transform mT;
    Image img;
    int speed = 150;
 
    private void Awake()
    {
        mT = transform;
        img = GetComponent<Image>();
        rb2d = GetComponent<Rigidbody2D>();
        mT.localRotation = Quaternion.Euler(0, 0, (int)arrowType);
    }

    private void OnEnable()
    {
        rb2d.AddForce(Vector3.left * speed, ForceMode2D.Impulse);
    }

    public void CorrectEffect()
    {
        rb2d.velocity = Vector2.zero;
        mT.DOLocalMoveY(300, 0.6f);
        img.DOColor(Color.clear, 0.6f);

        Destroy(gameObject, 1);
        
    }
}
