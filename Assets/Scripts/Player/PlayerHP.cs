using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    private int _hp = 3;
    [SerializeField] GameObject _panel;

    [SerializeField] private GameObject lifeObj;

    void Start()
    {
        SetLifeGauge(_hp);
    }

    public void SetLifeGauge(int life)
    {
        for (int i = 0; i < life; i++)
        {
            Instantiate(lifeObj, _panel.transform);
        }
    }
    public void SetLifeGauge2(int damage)
    {
        if (_hp - damage > 0)
        {
            _hp -= damage;
            for (int i = 0; i < damage; i++)
            {
                Destroy(_panel.transform.GetChild(i).gameObject);
            }
        }
        else
        {
            for (int i = 0; i < _hp; i++)
            {
                Destroy(_panel.transform.GetChild(i).gameObject);
            }
            _hp = 0;
        }
    }
}
