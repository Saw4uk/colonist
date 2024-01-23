using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class CliffLogic : MonoBehaviour
    {
        [SerializeField] private Transform williamTransform;
        [SerializeField] private Animator animator;
        private Human human;
        private bool isAnimationEnded;

        void Start()
        {
            animator.SetBool("legs", false);
            human = williamTransform.GetComponent<Human>();
        }

        private IEnumerator CliffingCoroutine(bool isLeft)
        {
            human.Freezed = true;
            animator.SetTrigger("Cliff");
            yield return new WaitForSeconds(0.85f);
            williamTransform.transform.position = new Vector2(
                williamTransform.transform.position.x + (isLeft ? -0.8f : 0.8f),
                williamTransform.transform.position.y + 1f);
            human.Freezed = false;
            human.IsWithWeapon = false;
        }

        public void StopCliffAnimation()
        {
            isAnimationEnded = true;
        }
        
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (human.Head.headON) return;

            var left = collider2D.transform.position.x - transform.position.x < 0;

            isAnimationEnded = false;
            
            StartCoroutine(CliffingCoroutine(left));
        }
    }
}