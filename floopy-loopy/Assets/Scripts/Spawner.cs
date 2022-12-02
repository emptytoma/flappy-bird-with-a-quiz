using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxTime = 1;
    public float timer = 0;
    public GameObject colomn;
    public float height;
    public List<GameObject> spawnedColumns = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GameObject newcolomn = Instantiate(colomn);
        spawnedColumns.Add(newcolomn);
        newcolomn.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newcolomn = Instantiate(colomn);
            spawnedColumns.Add(newcolomn);
            newcolomn.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newcolomn, 15);
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    public void DestroyAllColumns()
    {
        for (var i = spawnedColumns.Count - 2; i >= 0; i--)
        {
            var spawnedColumn = spawnedColumns[i];
            spawnedColumns.Remove(spawnedColumn);
            Destroy(spawnedColumn);
        }
    }
}
