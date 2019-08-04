using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PlatformerDemo
{
    public class Enemy : Character
    {
        protected override void onUpdate()
        {
        }

        protected override IEnumerator playDying()
        {
            rigidbody.bodyType = RigidbodyType2D.Static;

            for (int i = 0, blinkCount = 6; i < blinkCount; ++i)
            {
                spriteRenderer.enabled = i % 2 != 0;
                yield return new WaitForSeconds(0.1f);
            }

            Destroy(gameObject);
        }
    }
}