using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedTentSpawn : MonoBehaviour
{
    public Transform spawnLocation;
    public enum SpawnState { Spawning, Waiting, Counting };

    [System.Serializable]
    public class Troop
    {
        public GameObject troopPrefab;
        public string name;
        public Transform unit;
        public int count;
        public float rate;
    }

    public Troop[] troops;
    private int nextTroop = 0;


    public float timeBetweenGroups = 10f;
    public float groupCountDown = 0f;

    private SpawnState state = SpawnState.Counting;

    void Start()
    {
        //groupCountDown - timeBetweenGroups;
        groupCountDown = timeBetweenGroups;
    }

    void Update()
    {
            
        if (groupCountDown >= 0)
            {
                groupCountDown -= Time.deltaTime;
            }



    }

    public void SpawnTroop(int numTroop)
    {
        if (groupCountDown <= 0)
        {

            if (state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnGroup(troops[numTroop]));
            }
        }
    }

    IEnumerator SpawnGroup(Troop _group)
    {
        state = SpawnState.Spawning;

        for (int i = 0; i < _group.count; i++)
        {
            SpawnUnit(_group.troopPrefab);
            yield return new WaitForSeconds(1f / _group.rate);
        }

        state = SpawnState.Waiting;

        groupCountDown = timeBetweenGroups;

        yield break;
    }

    void SpawnUnit(GameObject _troop)
    {
        Debug.Log("spawning Unit: " + _troop.name);
        Instantiate(_troop, spawnLocation.position, spawnLocation.rotation);
    }
}