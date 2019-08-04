using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.PhysicsDemo
{
    public class PhysicsController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D dynamicRigidbody;

        [SerializeField]
        private Rigidbody2D kinematicRigidbody;

        public void FixedUpdate()
        {
            dynamicRigidbody.AddForce(new Vector2(3, 0), ForceMode2D.Force);
            kinematicRigidbody.velocity = new Vector2(1, 0);
        }
    }
}
