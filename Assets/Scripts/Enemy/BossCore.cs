using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossCore : MonoBehaviour
{
    [SerializeField] private int health = 1;

    private SpriteRenderer sprite;
    [SerializeField] private TimeManager timer;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void GetDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            timer.StopTimer();
            sprite.color = new Color(0.5f, 0.5f, 0.5f);
            Invoke("GameClear", 3f);
        }
    }

    public void GameClear()
    {
        SceneManager.LoadScene("ClearScene");
    }
}
