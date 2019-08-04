using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [System.Serializable]
    public struct Info
    {
        public GameObject Prefab;
        public Transform Position;
        public Vector3 Speed;
        public float Borntime;
        public float Lifetime;
    }

    [SerializeField]
    private Info[] infoArray;

    private Transform[] transforms;

    private bool[] flags;

    private float time;

    public void Start()
    {
        transforms = new Transform[infoArray.Length];
        flags = new bool[infoArray.Length];
        time = 0;

        //for (int i = 0, c = infoArray.Length; i < c; ++i)
        //{
        //    transforms[i] = Instantiate
        //        (infoArray[i].Prefab, infoArray[i].Position.position, Quaternion.identity)
        //        .transform;
        //}
    }

    public void Update()
    {
        time += Time.deltaTime;

        for (int i = 0, c = infoArray.Length; i < c; ++i)
        {
            var info = infoArray[i];
            if (flags[i] == false && time >= info.Borntime)
            {
                transforms[i] = Instantiate
                    (info.Prefab, info.Position.position, Quaternion.identity)
                    .transform;

                flags[i] = true;
            }
        }

        for (int i = 0, c = transforms.Length; i < c; ++i)
        {
            if (transforms[i])
            {
                transforms[i].Translate(infoArray[i].Speed * Time.deltaTime);

                if (time >= infoArray[i].Borntime + infoArray[i].Lifetime)
                {
                    Destroy(transforms[i].gameObject);
                }
            }
        }
    }
}