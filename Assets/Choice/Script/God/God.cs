using UnityEngine;
using System.Collections;

public static class God {

	public static readonly string TAG = typeof(God).Name;

	// ===============================
	// Properties
	// ===============================
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

	private static EliteSFX sfx;
	public static EliteSFX SFX {
		get {
			if(sfx == null) {
				sfx = GameObject.FindGameObjectWithTag("SFX").GetComponent<EliteSFX>();
			}
			return sfx;
		}
	}

	private static EliteHelpUI helpUI;
	public static EliteHelpUI HelpUI {
		get {
			if(helpUI == null) {
				helpUI = GameObject.FindGameObjectWithTag("Help UI").GetComponent<EliteHelpUI>();
			}
			return helpUI;
		}
	}

	private static EliteParse parse;
	public static EliteParse Parse {
		get {
			if(parse == null) {
				parse = GameObject.FindGameObjectWithTag("Parse").GetComponent<EliteParse>();
			}
			return parse;
		}
	}

	// ===============================
	// Functions
	// ===============================
	public static void Reset() {
		UtilLogger.Log(TAG, "Reset()");
		GameObject goStartPosition = GameObject.Find("Start Position");
		Hero.transform.position = goStartPosition.transform.position;
	}	
}
