using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTentSpawn : MonoBehaviour
{
    public enum SpawnState { Spawning, Waiting, Counting };

    [System.Serializable]
    public class Troop
    {
        public string name;
        public Transform minion;
        public int count;
        public float rate;
    }

    public Troop[] troops;
    private int nextTroop = 0;

    public float timeBetweengroups = 10f;
    public float groupCountdown;

    private SpawnState state = SpawnState.Counting;

    void Start()
    {
        waveCountdown - timeBetween;
    }

    void Update() 
    {
        if (groupCountdown <= 0)
        {

            if (state != SpawnState.Spawning)
            {
                StartCoroutine( SpawnGroup ( groups[nextGroup] ) );
            }
        }
        else
        {
            groupCountdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnGroup( Troop _group )
    {
        state = SpawnState.Spawning;

        for (int i = 0; i < _group.count; i++)
        {
            SpawnUnit (_group.unit);
            yield return new WaitForSeconds( 1f/_group.rate );
        }

        state = SpawnState.Waiting;

        yield break;
    }

    void SpawnUnit ( Transform _unit )
    {
        Debug.log("spawning Unit: " + _unit.name);
    }
}
