using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject Prefab;

    public Transform[] Positions;

    public void Start()
    {
        for (int i = 0, c = Positions.Length; i < c; ++i)
        {
            var obj = Instantiate(Prefab);
            obj.transform.position = Positions[i].position;
        }
    }
}