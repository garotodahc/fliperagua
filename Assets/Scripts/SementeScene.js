#pragma strict

function Start () {

}

function Update () {
 LeaveScene();
}

function LeaveScene(){

    yield WaitForSeconds (5.0);
    Application.LoadLevel("W1S1Scene");
}