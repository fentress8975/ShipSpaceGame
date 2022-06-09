using System.Collections.Generic;
using UnityEngine;


public class ObjectPooling : MonoBehaviour
{

    private List<GameObject> m_PooledObjects;
    private GameObject m_ObjectToPool;
    private int m_iAmountToPool;


    public void Initialization(GameObject objectToPool, int amountToPool, Transform parent)
    {
        m_ObjectToPool = objectToPool;
        m_iAmountToPool = amountToPool;
        m_PooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < m_iAmountToPool; i++)
        {
            tmp = Instantiate(m_ObjectToPool, parent);
            tmp.SetActive(false);
            m_PooledObjects.Add(tmp);
        }
    }

    public void ReSettup(GameObject objectToPool, int amountToPool)
    {
        m_ObjectToPool = objectToPool;
        m_iAmountToPool = amountToPool;
        m_PooledObjects.Clear();
        GameObject tmp;
        for (int i = 0; i < m_iAmountToPool; i++)
        {
            tmp = Instantiate(m_ObjectToPool);
            tmp.SetActive(false);
            m_PooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < m_iAmountToPool; i++)
        {
            if (!m_PooledObjects[i].activeInHierarchy)
            {
                return m_PooledObjects[i];
            }
        }
        return null;
    }
}
