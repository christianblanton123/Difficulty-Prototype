using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> platformSet;

    public Dictionary<Transform, bool> occupiedMap;
    void Start()
    {
      
    }

    // Update is called once per frame

    public void SpawnNewPlatform(GameObject t)
    {
        //GameObject set= platformSet.Find(obj=>t);
        GameObject parentSet = t.transform.parent.gameObject;
        GameObject platform = parentSet.transform.GetChild(Random.Range(0, parentSet.transform.childCount)).gameObject;
        while (platform.GetComponent<DestroyAfterCollision>().startTimer && platform.activeSelf)
        {
            platform = parentSet.transform.GetChild(Random.Range(0, parentSet.transform.childCount)).gameObject;
        }
        platform.GetComponent<DestroyAfterCollision>().Spawn(platform.transform);
    }
   
}
