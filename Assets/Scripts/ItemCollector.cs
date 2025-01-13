using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCollector : MonoBehaviour
{		
   private int fruits = 0;
   
   [SerializeField] private Text fruitsText;
   
   [SerializeField] private AudioSource collectionSoundEffect;
   
   private void OnTriggerEnter2D(Collider2D collision)
   {
	   if (collision.gameObject.CompareTag("Cherry"))
	   {
		   collectionSoundEffect.Play();
		   Destroy(collision.gameObject);
		   fruits++;
		   fruitsText.text = "Fruits: " + fruits;
	   }

       else if (collision.gameObject.CompareTag("Apple"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            fruits = fruits + 5;
            fruitsText.text = "Fruits: " + fruits;
        }
    }
}
