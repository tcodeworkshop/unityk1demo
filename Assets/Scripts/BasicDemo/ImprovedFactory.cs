using UnityEngine;

public class ImprovedFactory : MonoBehaviour
{
    public GameObject Prefab1;
    public GameObject Prefab2;

    public Transform[] Positions1;
    public Transform[] Positions2;

    public void Start()
    {
        makeObjects(Prefab1, Positions1);
        makeObjects(Prefab2, Positions2);
    }

    private void makeObjects(GameObject prefab, Transform[] positions)
    {
        for (int i = 0, c = positions.Length; i < c; ++i)
        {
            var obj = Instantiate(prefab);
            obj.transform.position = positions[i].position;
        }
    }
}