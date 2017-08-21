#pragma strict

function Start () {


}

function Update () {
  LeaveScene();

}

function LeaveScene ()
{
    yield WaitForSeconds (39.0);
    Application.LoadLevel("SementeScene");
}

