//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.34014
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections;

public class ExtraLifesAction : Action{

	public ExtraLifesAction () {
	}

	public void act() {
		LifeManager.getInstance ().addExtraLifes (10);
		ShopManager.getInstance ().destroyItem (ShopList.tenLifes);
	}
}


