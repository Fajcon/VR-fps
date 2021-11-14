using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
   public float speed = 40;
   public GameObject bullet;
   public AudioClip audioClip;

   private Color startColor = Color.red;
   private Color endColor = Color.white;
   public void Fire(GameObject barrel,AudioSource audioSource, GameObject target)
   {
      GameObject spawnBullet = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
      spawnBullet.GetComponent<Rigidbody>().velocity = speed * barrel.transform.forward;
      audioSource.PlayOneShot(audioClip);
      Destroy(spawnBullet, 2);
      if (target != null)
      {
         Destroy(target);
      }
   }
}
