using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int coin = 0;

    [SerializeField] private Text coinText;

    [SerializeField] private AudioSource collectionSoundEffect;
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.gameObject.CompareTag("Coin"))
       {
           collectionSoundEffect.Play();
           Destroy(collision.gameObject);
           coin++;
           coinText.text = "Coin: " + coin;
       }
   }
}
