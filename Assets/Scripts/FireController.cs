using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private float StartTime;
	[SerializeField] private float TimeLeft;
	
	private Animator anim;
	
	private bool IsActive;
   
    private void Start()
     {	
		anim = GetComponent<Animator>();
     }
	 
	 private void Update()
	 {	
		if (TimeLeft > 0)
	   {
		   gameObject.tag = "Untagged";
		   anim.SetBool("IsActive", false);
		   TimeLeft -= Time.deltaTime;
	   }
	   else
	   {
		   gameObject.tag = "Trap";
		   anim.SetBool("IsActive", true);
		   Invoke ("ResetTimer", 4f);   
	   }
	 }
	 
	 private void ResetTimer()
	 {
		 TimeLeft = StartTime;
	 }

}
