#pragma strict

var playerHealth = 100;

function ApplyDammage (TheDammage : int)
{
	playerHealth -= TheDammage;
	
	if(playerHealth <= 0)
	{
		Application.LoadLevel(4);
		SendMessage("Mort");
	}
}