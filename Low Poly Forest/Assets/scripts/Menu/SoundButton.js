#pragma strict
var sonBouton : AudioClip;
function ButtonPress () {
GetComponent.<AudioSource>().PlayOneShot(sonBouton);

}
