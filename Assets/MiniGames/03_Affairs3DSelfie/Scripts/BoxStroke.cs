using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BoxStroke : MonoBehaviour
{
    Image image;

  
    public static List<Arrow> arrows = new List<Arrow>();

    private void Awake()
    {
        image = GetComponent<Image>();
        arrows.Clear();
        EventManager.OnCorrect += OnCorrectEffect;
        EventManager.OnWrong += OnWrongEffect; 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        arrows.Add(collision.GetComponent<Arrow>());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        arrows.Clear();
    }


    void OnCorrectEffect()
    {
        StartCoroutine(ColorChange(Color.green, 0.1f));
    }


    void OnWrongEffect()
    {
        StartCoroutine(ColorChange(Color.red, 0.2f));
        transform.DOShakeScale(0.4f,0.2f);
    }

    IEnumerator ColorChange(Color color, float delay)
    {
        image.DOColor(color, delay).SetEase(Ease.Flash);
        yield return new WaitForSeconds(delay);
        image.DOColor(Color.white, delay).SetEase(Ease.Flash);
    }


    private void OnDisable()
    {
        EventManager.OnCorrect -= OnCorrectEffect;
        EventManager.OnWrong -= OnWrongEffect;
    }

}
