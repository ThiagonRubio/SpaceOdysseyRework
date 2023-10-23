using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //------PRIVATE PROPERTIES-------
    private Queue<IPoolable> objectPool;
    private IPoolable objectToPool;
    private int poolSize = 10;

    private Transform poolFolder;

    //################ #################
    //----------UNITY EV FUNC-----------
    //################ #################
    private void Awake()
    {
        objectPool = new Queue<IPoolable>();
    }

    private void OnDestroy()
    {
        if (poolFolder != null)
            Destroy(poolFolder.gameObject);
    }

    //################ #################
    //----------CLASS METHODS-----------
    //################ #################

    public void CreatePool(IPoolable objectToPool, int poolMaxSize = 10)
    {
        if (objectPool != null)
        {
            this.objectToPool = objectToPool;
            this.poolSize = poolMaxSize;

            CreateObjectPoolParentIfItDoesntExist(objectToPool);
        }
        else Debug.LogWarning("Object is not a poolable object.");
    }

    public IPoolable TryGetPooledObject()
    {
        IPoolable pooledObject = null;

        if (objectPool.Count < poolSize)
        {
            pooledObject = NewObject();
        }
        else
        {
            pooledObject = ReuseObject();
        }

        objectPool.Enqueue(pooledObject);
        return pooledObject;
    }

    private IPoolable NewObject()
    {
        GameObject newObject = Instantiate(objectToPool.GameObject, transform.position, transform.rotation);
        IPoolable pooledObject = newObject.GetComponent<IPoolable>();
        pooledObject.GameObject.name = transform.root.name + "_" + objectToPool.GameObject.name + "_" + objectPool.Count;
        pooledObject.GameObject.transform.SetParent(poolFolder);

        return pooledObject;
    }
    private IPoolable ReuseObject()
    {
        IPoolable pooledObject = objectPool.Dequeue();
        pooledObject.GameObject.transform.position = transform.position;
        pooledObject.GameObject.transform.rotation = transform.rotation;
        pooledObject.GameObject.SetActive(true);

        return pooledObject;
    }

    private void CreateObjectPoolParentIfItDoesntExist(IPoolable objectToPool)
    {
        if (poolFolder == null)
        {
            string name = "ObjectPool_" + objectToPool.GameObject.name;
            poolFolder = new GameObject(name).transform;
        }
    }
}
