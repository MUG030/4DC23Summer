using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // AnimationController参照
    [SerializeField] private Animator anim;

    // 移動していない時のアニメーション処理
    public void SetStop()
    {
        anim.SetFloat("MoveX", 0f);
    }

    // 移動中のアニメーション処理
    public void SetMove()
    {
        anim.SetFloat("MoveX", 1f);
    }
}
