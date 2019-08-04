using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.PlatformerDemo
{
    public class Knight : Character
    {
        protected override void onUpdate()
        {
            if (Input.GetKey(KeyCode.A))
            {
                walk(WalkDirection.Left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                walk(WalkDirection.Right);
            }
            else
            {
                walk(WalkDirection.None);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                jump();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                attack();
            }
        }

        protected override IEnumerator playDying()
        {
            resetJumpVelocity();
            addJumpForce();

            yield return new WaitForSeconds(2);

            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}