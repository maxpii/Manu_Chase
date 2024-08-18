using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterReference;

    [SerializeField]
    private Transform leftPos, rightPos;

    [SerializeField]
    private GameObject spawnedMonster;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
        
    }
    IEnumerator SpawnMonsters() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(1,5));
            randomIndex = Random.Range(0,monsterReference.Length);
            randomSide = 0;

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            // left side
            if (randomSide == 0) {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4,10);
            }
            else {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4,10);
                spawnedMonster.transform.localScale = new UnityEngine.Vector3(-1f,1f,1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
