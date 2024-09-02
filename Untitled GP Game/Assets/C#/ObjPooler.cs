using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPooler : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;

    public static ObjPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for( int i = 0; i < pool.size; i++)
            {
                GameObject gameObject = Instantiate(pool.prefab);
                gameObject.SetActive(false);
                objectPool.Enqueue(gameObject);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject gameObjectToSpawn = poolDictionary[tag].Dequeue();
        gameObjectToSpawn.SetActive(true);
        gameObjectToSpawn.transform.position = position;
        gameObjectToSpawn.transform.rotation = rotation;
        poolDictionary[tag].Enqueue(gameObjectToSpawn);
        return gameObjectToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
