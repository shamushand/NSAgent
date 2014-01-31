using UnityEngine;
using System.Collections;

public static class Strings
{
	public static string[] comboNames = new string[10]{"PATRIOTic!", "American!", "Big Brother!", "Counter-terrorist!", "Savior!",
														"PATRIOTic!", "American!", "Big Brother!", "Counter-terrorist!", "Savior!"};
	
	static string messages = @"The quick brown bomb fox jumps over the radioactive lazy dog.
That storm last week man, it was crazy! Please expect some power outages until the authorities resolve the matter.
Don't forget, tomorrow is talk like a pirate day! If you need help, just call me.
Great. So my flight was cancelled because the airport is snowed in, I blame this stupid storm.
The quick brown bomb fox jumps over the radioactive lazy dog.
That storm last week man, it was crazy! Please expect some power outages until the authorities resolve the matter.
Don't forget, tomorrow is talk like a pirate day! If you need help, just call me.
Great. So my flight was cancelled because the airport is snowed in, I blame this stupid storm.
The quick brown bomb fox jumps over the radioactive lazy dog.
That storm last week man, it was crazy! Please expect some power outages until the authorities resolve the matter.
Don't forget, tomorrow is talk like a pirate day! If you need help, just call me.
Great. So my flight was cancelled because the airport is snowed in, I blame this stupid storm.
The quick brown bomb fox jumps over the radioactive lazy dog.
That storm last week man, it was crazy! Please expect some power outages until the authorities resolve the matter.
Don't forget, tomorrow is talk like a pirate day! If you need help, just call me.
Great. So my flight was cancelled because the airport is snowed in, I blame this stupid storm.
The quick brown bomb fox jumps over the radioactive lazy dog.
That storm last week man, it was crazy! Please expect some power outages until the authorities resolve the matter.
Don't forget, tomorrow is talk like a pirate day! If you need help, just call me.
Great. So my flight was cancelled because the airport is snowed in, I blame this stupid storm.";
	
	static string flagged = @"2600
Agro
Aid
Airplane
Airport
Attack
Authorities
Avalanche
Bacteria
Breach
Biological
Blackout
Blizzard
Bomb
Border
Bridge
Brownout
Burn
Burst
Bust
Cancelled
Chemical
China
Closure
Cloud
Collapse
Command
Computer
Cop
Crash
Crest
Cyber
DDOS
Death
Decapitate
Delay
Disaster
Dock
Domestic
Drill
Drug
Earthquake
Electric
Emergency
Enriched
Epidemic
Erosion
Evacuation
Execution
Explosion
Exposure
Extremism
Facility
Failure
Flood
Flu
Gang
Gas
Grid
Gunfight
Hacker
Hail
Hazardous
Help
Hurricane
Ice
Incident
Infection
Interstate
Iran
Iraq
Keylogger
Kidnap
Landing
Leak
Lightening
Lockdown
Looting
Magnitude
Malware
Mexico
Metro
Mitigation
Mudslide
Mutation
Narcotic
Nationalist
Nigeria
Nuclear
Outage
Outbreak
Pakistan
Pandemic
Phishing
Phreaking
Pirate
Plague
Plane
Plot
Plume
Police
Pork
Port
Power
Prevention
Quarantine
Radiation
Radical
Radioactive
Recall
Recovery
Recruitment
Relief
Resistant
Response
Riot
Rootkit
Scammer
Screening
Security
Separatist
Shelter
Shooting
Shootout
Sick
Sleet
Smart
Smuggling
Snow
Southwest
Spammer
Spillover
Standoff
Storm
Strain
Stranded
Stuck
Subway
SWAT
Swine
Symptomy
Target
Threat
Tornado
Toxic
Trafficking
Tremor
Trojan
Tsunami
Twister
Typhoon
Vaccine
Virus
Violence
Warning
Watch
Wave
Weapon
Wildfire
Worm";
		
	/// <summary>
	/// Returns the word bank as an array of strings.
	/// </summary>
	public static string[] WordBank()
	{
		return flagged.Split('\n');
	}
	
	/// <summary>
	/// Returns the message list as an array of strings.
	/// </summary>
	public static string[] Messages()
	{
		return messages.Split('\n');
	}
}
