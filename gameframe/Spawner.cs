using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SpawnModes
{  
    Fixed,
    Random

}
public class Spawner : MonoBehaviour
{
    [Header("设置")]
    [SerializeField]private SpawnModes spawnMode = SpawnModes.Fixed;
    [SerializeField]private int enemyCount=10;
    [SerializeField]private GameObject enemyObject;

    [Header("固定时间间隔")]
    [SerializeField]private float delaybtwSpawns;

    [Header("随机时间间隔")]
    [SerializeField]private float minRandomdelay;
    [SerializeField]private float maxRandomdelay;
    
    private float spwantimer;//当前生成倒计时
    private int enemyspawned;//敌人已生成数

    private ObjectPooler pooler;
    
    // Start is called before the first frame update
    void Start()
    {
        pooler = GetComponent<ObjectPooler>();
    }

    // Update is called once per frame
    void Update()
    {
        spwantimer -= Time.deltaTime;
        if(spwantimer <0)
        {
          spwantimer = GetSpawnDelay();
          if(enemyspawned<enemyCount)
          {
            SpawnEnemy();
            enemyspawned++;
          }
          
        }
    }
    
    private void SpawnEnemy()
    {
        GameObject newInstacne=pooler.GetInstanceFromPool();
        newInstacne.SetActive(true);
    }
    
    private float GetSpawnDelay()
    {
       if(spawnMode == SpawnModes.Fixed)
       {
          return delaybtwSpawns;
       }
       else
       {
          return GetRandomDelay();

       }
    }
    private float GetRandomDelay()
    {
        float randomtime = Random.Range(minRandomdelay,maxRandomdelay);
        return randomtime;
    }
}
