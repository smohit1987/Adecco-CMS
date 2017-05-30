using System;
using System.Collections.Generic;


namespace AdeccoNL.iOS
{
	public static class Translations
	{
		static Translations()
		{

		}
		public static string keyword_title = "Trefwoord";
		public static string location_title = "Locatie";
		public static string job_search = "Zoek";
		public static string latest_job = "Laatste job";
		public static string recent_search = "Recente zoekopdracht";

		public static string Today = "Vandaag";
		public static string Yesterday = "Gisteren";

		// Branch Locator
		public static string Bl_Place = "Vandaag";
		public static string Bl_Distance = "Gisteren";
		public static string Bl_Branches = "Vandaag";
		public static string Bl_Map = "Gisteren";
		public static string Bl_Search = "Zoek";


		public static void setTranslations(string country, string language)
		{
			Console.WriteLine("selected country ={0} and language ={1}", country, language);

			if (language.Equals("nl-NL"))
			{

				keyword_title = "Trefwoord";
				job_search = "Zoek";
				location_title = "Locatie";
				latest_job = "Laatste job";
				recent_search = "Recente zoekopdracht";

				Today = "Vandaag";
				Yesterday = "Gisteren";


				Bl_Place = "Plaats";
				Bl_Distance = "Afstand";
				Bl_Search = "Zoek";
				Bl_Branches = "Branches";
				Bl_Map = "Kaart";

			}
			else if (language.Equals("fr-CH"))
			{
				keyword_title = "Mot-clé";
				job_search = "Recherche d'emploi";
				location_title = "Ville";
				latest_job = "Dernier emploi";
				recent_search = "Recherche réente";

				Today = "Aujourd'hui";
				Yesterday = "Hier";

				Bl_Place = "Localisation";
				Bl_Distance = "Distance";
				Bl_Search = "Trouver une agence";
				Bl_Branches = "Branches";
				Bl_Map = "Carte";

			}
			else if (language.Equals("fr-FR"))
			{
				keyword_title = "Mot-clé";
				job_search = "trouver des offres";
				location_title = "Ville";
				latest_job = "Dernier emploi";
				recent_search = "Recherche réente";

				Today = "Aujourd'hui";
				Yesterday = "Hier";

				Bl_Place = "Localisation";
				Bl_Distance = "Distance";
				Bl_Search = "Trouver une agence";
				Bl_Branches = "Branches";
				Bl_Map = "Carte";


			}
			else if (language.Equals("en-GB") || language.Equals("en-US"))
			{
				keyword_title = "Keyword";
				job_search = "Find Jobs";
				location_title = "Location";
				latest_job = "Latest Jobs";
				recent_search = "Recent Search";

				Today = "Today";
				Yesterday = "Yesterday";

				Bl_Place = "Location";
				Bl_Distance = "Distance";
				Bl_Search = "Search";
				Bl_Branches = "Branches";
				Bl_Map = "Map";
			}
			else if (language.Equals("de-CH"))
			{
				keyword_title = "Stichwort?";
				job_search = "Arbeitssuche";
				location_title = "Ort";
				latest_job = "Letzter Job";
				recent_search = "Aktuelle Suche";

				Today = "Vandaag";
				Yesterday = "Gisteren";


				Bl_Place = "Plaats";
				Bl_Distance = "Afstand";
				Bl_Search = "Zoek";
				Bl_Branches = "Branches";
				Bl_Map = "Kaart";

			}
			else if (language.Equals("it-CH"))
			{
				keyword_title = "Parola chiave";
				job_search = "Trova";
				location_title = "Località";
				latest_job = "Ultimo lavoro";
				recent_search = "Ricerca recente";

				Today = "Oggi";
				Yesterday = "Ieri";

				Bl_Place = "Luogo";
				Bl_Distance = "Distanza";
				Bl_Search = "Ricerca";
				Bl_Branches = "Filiali";
				Bl_Map = "Carta geografica";
			} 
		}
	}
}
