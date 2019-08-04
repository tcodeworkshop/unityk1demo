using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private void Start()
    {
        Instantiate(prefab);
    }
}