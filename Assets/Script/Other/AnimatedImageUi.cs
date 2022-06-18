using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedImageUi : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Image image;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = sprite.sprite;
    }
}
