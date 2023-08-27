using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    private int currentWave;


    //Variables
    [SerializeField] private Wave[] waves;

    [SerializeField] private float timeBetweenWaves = 3f;
    [SerializeField] private float waveCountdown = 0;

    private SpawnState state = SpawnState.COUNTING;

    //References
    [SerializeField] private Transform[] spawners;
    [SerializeField] private List<CharacterStats> enemyList;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        currentWave = 0;
    }

    private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            //Check if all enemies are dead
            if (!EnemiesAreDead())
                return;
            else
                CompleteWave();
        }

        if (waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[currentWave]));
            }
        }
        else
            waveCountdown -= Time.deltaTime;
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;

        for(int i = 0; i < wave.enemiesAmount; i++)
        {
            SpawnAlien(wave.enemy);
            yield return new WaitForSeconds(wave.delay);
        }    

        state = SpawnState.WAITING;

        yield break;
    }

    private void SpawnAlien(GameObject enemies)
    {
        int randomInt = Random.RandomRange(1, spawners.Length);
        Transform randomSpawner = spawners[randomInt];

        GameObject newEnemy = Instantiate(enemies, randomSpawner.position, randomSpawner.rotation);
        CharacterStats newEnemyStats = newEnemy.GetComponent<CharacterStats>();

        enemyList.Add(newEnemyStats);
    }

    private bool EnemiesAreDead()
    {
        int i = 0;
        foreach(CharacterStats enemy in enemyList)
        {
            if(enemy.IsDead())
                i++;
            else
                return false;
        }
        return true;
    }

    private void CompleteWave()
    {
        Debug.Log("Wave completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(currentWave +1 > waves.Length - 1)
        {
            currentWave = 0;
            Debug.Log("Completed all the waves");
        }
        else
        {
            currentWave++;
        }

    }
}
