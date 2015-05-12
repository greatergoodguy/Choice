using UnityEngine;
using System.Collections;

public static class God {

	private static EliteGuidanceUI guidanceUI;
	public static EliteGuidanceUI GuidanceUI {
		get {
			if(guidanceUI == null) {
				guidanceUI = GameObject.FindGameObjectWithTag("Guidance UI").GetComponent<EliteGuidanceUI>();
			}
			return guidanceUI;
		}
	}

	private static EliteHero hero;
	public static EliteHero Hero {
		get {
			if(hero == null) {
				hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<EliteHero>();
			}
			return hero;
		}
	}
}
