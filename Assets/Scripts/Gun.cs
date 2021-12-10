using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
   public float speed = 40;
   public GameObject bullet;
   public GameObject particles;
   public AudioClip audioClip;

   private Color startColor = Color.red;
   private Color endColor = Color.white;
 
   public void Fire(GameObject barrel,AudioSource audioSource, GameObject target)
   {
      GameObject spawnBullet = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
      spawnBullet.GetComponent<Rigidbody>().velocity = speed * barrel.transform.forward;
      audioSource.PlayOneShot(audioClip);
      Destroy(spawnBullet, 2);
      if (target != null && target.name == "Start_btn")
      {
         SceneManager.LoadScene ("SampleScene");
      } else if (target != null && target.CompareTag("Target"))
      {
         target.GetComponent<Target>().DestroyTarget();
         GameObject spawnParticles = Instantiate(particles, target.transform.position, target.transform.rotation);
         Destroy(spawnParticles, 2);
      }
   }
}
