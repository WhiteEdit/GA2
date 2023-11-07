using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinylInteract : Interactable
{
     private bool canInspect = false;
     private bool canvasOpen;
     [SerializeField]
     private GameObject imageViewerVinyl;

     [SerializeField]
     private GameObject inspectObject;

     private FirstPersonControler firstPersonControler;
    
     private string thisName = "none";


     void Start()
     {
          firstPersonControler = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonControler>();
          inspectObject.SetActive(false);
          imageViewerVinyl.SetActive(false);
     }


     
    
   public override void OnFocus() 
   {
     canInspect = true;
     thisName = gameObject.name;
      print("lOOKING AT" + thisName);
      



       
   }
   public override void OnLoseFocus()
   {
        print("STOPPED lOOKING AT" + gameObject.name);
        canInspect = false;
        inspectObject.SetActive(false);
       
   }
  
   public override void OnInteract()
   {
        print("interacted with" + gameObject.name);
   }
   
   void Update()
   {
     if (Input.GetKeyDown(KeyCode.Tab) && canInspect && !canvasOpen  )
     {
          
          imageViewerVinyl.SetActive(true);
          inspectObject.SetActive(true);
          firstPersonControler.enabled = false;
          Cursor.lockState = CursorLockMode.Confined; 
          Cursor.visible = true;
          canvasOpen = true;
          
            
     }

     else if (Input.GetKeyDown(KeyCode.Tab) && canvasOpen)
     {
          canvasOpen = false;
          firstPersonControler.enabled = true;
          inspectObject.SetActive(false);
          imageViewerVinyl.SetActive(false);
           Cursor.lockState = CursorLockMode.Locked;
           Cursor.visible = false; 
           
     }
   }
}
