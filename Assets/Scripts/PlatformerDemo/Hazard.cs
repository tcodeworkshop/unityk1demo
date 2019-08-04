using UnityEngine;

namespace Assets.Scripts.PlatformerDemo
{
    public class Hazard : MonoBehaviour
    {
        [SerializeField]
        private Knight _knight = null;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == _knight.gameObject)
            {
                _knight.Die();
            }
        }
    }
}