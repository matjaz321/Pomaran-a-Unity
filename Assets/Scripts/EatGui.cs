using UnityEngine;
 using System.Collections;
  
 public class EatGui : MonoBehaviour {
  
     public GameObject menu; // Assign in inspector
 
     void Start() {
         menu.SetActive(false);
     }

     void OnTriggerEnter2D(Collider2D obj)
     {
         menu.SetActive(true);
     }

     void OnTriggerExit2D(Collider2D obj)
     {
              menu.SetActive(false);	
     }
 }