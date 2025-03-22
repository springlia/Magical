using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob2Manager : MonoBehaviour
{

    public GameManager gamemanager;

    [SerializeField]
    private GameObject mob;

    float wait = 1.7f;

    void Start()
    {
        StartCoroutine(CreateMobRoutine());
    }

    IEnumerator CreateMobRoutine()
    {
        while (true)
        {
            CreateMob();
            yield return new WaitForSeconds(wait);
        }
    }

    void CreateMob()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, UnityEngine.Random.Range(0.0f, 1.0f), 0));
        pos.z = 0.0f;
        Instantiate(mob, pos, Quaternion.identity);
    }
}

