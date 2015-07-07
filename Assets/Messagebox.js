#pragma strict

	var GuiOn = false;
 //Those 2 fcts are just to change the color of your word when you hover the mouse over them
 function OnMouseEnter(){
 
     renderer.material.color = Color.green;
 }
 
 
 function OnMouseExit(){
 
     renderer.material.color = Color.white;
 }
 
 
 function OnGUI () {            
         if(GuiOn){//check if gui should be on. If false, the gui is off, if true,  the gui is on
             // Make a background box
             GUI.Box (Rect (10,10,100,90), "You sure?");
             // Make the first button. If pressed, quit game 
             if (GUI.Button (Rect (20,40,80,20), "Yes")) {
                 Application.Quit();
             }
             // Make the second button.If pressed, sets the var to false so that gui disappear
                 if (GUI.Button (Rect (20,70,80,20), "No")) {
                     GuiOn=false;
                 }
             }
         }
         //fct checks for a click and sets the var to true to make gui appear.
function OnMouseDown(){
             GuiOn = true;
         }




function Update () {

}