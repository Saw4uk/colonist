using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class legs : MonoBehaviour



{
    [SerializeField] private Transform williamTransform;
    [SerializeField]private Animator animator;
    private william William;
    public static legs Instance;
    private bool istriggered;
    
    
  
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("legs", false);
        William=williamTransform.GetComponent<william>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckLegs();
    }
    private void Awake()
    {
       
        
    }
    private void FixedUpdate()
    {
        
    }
    private void CheckLegs()
    {
        animator.SetBool("legs", istriggered);
    }
    private IEnumerator moving()
    {
        if (William.Head.headON == false)
        {
        yield return new WaitForSeconds(0.4f);
        istriggered = false;
        yield return null;
        williamTransform.transform.position = new Vector2(williamTransform.transform.position.x - 0.8f,williamTransform.transform.position.y + 1f);
        

        }
       
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (William.Head.headON == false)
        {
        istriggered = true;
        animator.SetBool("legs",true);
        StartCoroutine(moving());
        Debug.Log("���� ������");
       
        }
        

    }

}
