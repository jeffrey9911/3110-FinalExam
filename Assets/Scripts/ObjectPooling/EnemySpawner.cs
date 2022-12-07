using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _Enemies;
    [SerializeField] private Transform _SpawnPos1;
    [SerializeField] private Transform _SpawnPos2;

    [SerializeField] private int _NumberOfEnemy;

    private int _MaxNumber;


    private void Start()
    {
        _MaxNumber = ObjectPoolManager.instance._objectPoolDictionary["Enemy1"].Count;
        for (int i = 0; i < _NumberOfEnemy; i++)
        {
            float select = Random.Range(0f, 10f);
            if (((int)select % 2) == 0)
            {
                ObjectPoolManager.instance.SetActiveFromPool("Enemy1", _SpawnPos1.position, Quaternion.identity);
            }
            else
            {
                ObjectPoolManager.instance.SetActiveFromPool("Enemy2", _SpawnPos2.position, Quaternion.identity);
            }


            if (i == _MaxNumber)
            {
                break;
            }
        }
    }

    private void Update()
    {
        
    }
}
