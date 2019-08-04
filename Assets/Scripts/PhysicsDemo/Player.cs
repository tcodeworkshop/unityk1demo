using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.PhysicsDemo
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private new Rigidbody2D rigidbody;

        public void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.LogFormat("OnCollisionEnter2D {0} {1}",
                collision.collider.gameObject.name,
                collision.otherCollider.gameObject.name);
        }

        public void OnCollisionExit2D(Collision2D collision)
        {
            Debug.LogFormat("OnCollisionExit2D {0} {1}",
                collision.collider.gameObject.name,
                collision.otherCollider.gameObject.name);
        }
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            Debug.LogFormat("OnTriggerEnter2D {0}",
                other.gameObject.name);
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            Debug.LogFormat("OnTriggerExit2D {0}",
                other.gameObject.name);
        }
    }
}
