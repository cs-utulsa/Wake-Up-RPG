using UnityEngine;
using System.Collections;

public class MazeSprite : MonoBehaviour {

    SpriteRenderer sRenderer;

    void Awake() {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite sprite, int sortingOrder) {
        sRenderer.sprite = sprite;
        sRenderer.sortingOrder = sortingOrder;
    }

    public void SetSprite(Sprite sprite) {
        SetSprite(sprite, 0);
    }
}