#pragma strict

var sonBouton : AudioClip;

function QuitGame () {
	Debug.Log("Quit");
	Application.Quit ();
	}
function StartGame () {
    Debug.Log("Jeu");
    Application.LoadLevel (3);
    }
function CreditGame () {
    Debug.Log("Credits");
    Application.LoadLevel (1);
    }
function MenuGame () {
    Debug.Log("Menu");
    Application.LoadLevel (0);
    }
function GameOptions () {
    Debug.Log("Options");
    Application.LoadLevel (2);
    }
    function ShopGame () {
    Debug.Log("Magasin");
    Application.LoadLevel (6);
    }
function ButtonPress () {

    GetComponent.<AudioSource>().PlayOneShot(sonBouton);
}
