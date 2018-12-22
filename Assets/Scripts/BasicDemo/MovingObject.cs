using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public Transform Target;
    
    public void Update()
    {
        Target.Translate(Vector3.up * Time.deltaTime);
    }
}