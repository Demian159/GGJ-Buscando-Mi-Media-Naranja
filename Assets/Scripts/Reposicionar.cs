using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposicionar : MonoBehaviour
{
    [SerializeField] private Transform[] spawns;
    [SerializeField] Transform nextSpawn;

    public void Reposicion()
    {
        nextSpawn = spawns[UnityEngine.Random.Range(0, 4)];
        this.transform.position = new Vector3(nextSpawn.position.x, nextSpawn.position.y, nextSpawn.position.z);
        this.transform.localScale = nextSpawn.localScale;
    }
}
