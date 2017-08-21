#pragma strict

 var objectHolder : GameObject;
 private var objects : Transform[];
 private var current : int;
 
 function Start() {
     objects = objectHolder.GetComponentsInChildren(Transform) as Transform[];
     for (var t : Transform in objects) {
         t.gameObject.SetActive(false);
     }
     current = 0;
     objects[current].gameObject.SetActive(true);
 }
 
 function NextFrame() {
     objects[current].gameObject.SetActive(false);
     current = (current + 1) % objects.Length;
     objects[current].gameObject.SetActive(true);
 }