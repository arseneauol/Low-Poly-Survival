#pragma strict

var TheDammage : int = 100;
var Distance : float;
var MaxDistance : float = 1.5;
var TheMace : Transform;

function Update ()
{
		if (Input.GetButtonDown("Fire1"))
		{
		TheMace.GetComponent.<Animation>().Play("batAnimation");
		var hit : RaycastHit;
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), hit))
		{
		Distance = hit.distance;
		if (Distance < MaxDistance)
		{
				hit.transform.SendMessage("ApplyDammage", TheDammage);
}
}
}
}