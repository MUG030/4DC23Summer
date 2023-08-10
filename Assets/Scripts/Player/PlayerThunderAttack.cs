using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerThunderAttack : MonoBehaviour
{
    [SerializeField] private CanvasGroup flashObject;
    [SerializeField] private float flashSpeed = 10f;

    float flashAlpha = 0f;

    void Update()
    {
        if(flashAlpha > 0f)
        {
            flashAlpha = Mathf.Max(0f, flashAlpha - Time.deltaTime * flashSpeed);
        }

        flashObject.alpha = flashAlpha;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Flash();
            ThunderAttack();
        }
    }

    void ThunderAttack()
    {
        GameObject[] enemys = GameObject
            .FindGameObjectsWithTag("Enemy")
            .Where(x => x.GetComponent<SpriteRenderer>().isVisible == true)
            .ToArray();
        GameObject[] enemys_walk = enemys.Where(x => x.GetComponent<Enemy_Walk>() != null).ToArray();
        GameObject[] enemys_shoot = enemys.Where(x => x.GetComponent<Enemy_Shoot>() != null).ToArray();
        GameObject[] enemys_bullet = enemys.Where(x => x.GetComponent<Enemy_Bullet>() != null).ToArray();
        GameObject[] bosscore = enemys.Where(x => x.GetComponent<BossCore>() != null).ToArray();
        foreach (var enemy in enemys_walk)
        {
            enemy.GetComponent<Enemy_Walk>().GetDamage(1);
        }
        foreach (var enemy in enemys_shoot)
        {
            enemy.GetComponent<Enemy_Shoot>().GetDamage(1);
        }
        foreach (var enemy in enemys_bullet)
        {
            enemy.GetComponent<Enemy_Bullet>().GetDamage(1);
        }
        foreach (var enemy in bosscore)
        {
            enemy.GetComponent<BossCore>().GetDamage(1);
        }
    }

    void Flash()
    {
        flashAlpha = 1f;
    }
}
