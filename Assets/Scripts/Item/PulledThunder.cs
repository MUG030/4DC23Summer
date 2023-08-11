using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulledThunder : MonoBehaviour
{
    //[SerializeField] private SpriteRenderer sprite;
    //[SerializeField] private float fadeOutSpeed = 1f;
    [SerializeField] private float upSpeed = 1f;
    [SerializeField] private float destroyTime = 0.7f;

    //private float alpha = 0f;

    void Update()
    {
        //sprite.color = new Color(1, 1, 1, alpha);
        transform.Translate(Vector2.up * Time.deltaTime * upSpeed);
        //alpha += Time.deltaTime;
        destroyTime -= Time.deltaTime;
        if(destroyTime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
