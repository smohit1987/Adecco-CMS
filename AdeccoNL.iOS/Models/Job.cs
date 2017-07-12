using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using SQLite.Net.Attributes;

namespace AdeccoNL
{
	/// <summary>
	/// This class contains all the attributes related to Job .
	/// </summary>
	[Table("Job")]
	public class Job
	{
		[PrimaryKey]
		public string JobId { get; set; }
		public string JobTitle { get; set; }

		public string PostedDate { get; set; }
		public string Reference { get; set; }
		public string Summary { get; set; }

		public string Language { get; set; }
		public string MaxSalary { get; set; }
		public string MinSalary { get; set; }
		public string JobStartDate { get; set; }
		public string JobStatusId { get; set; }
		public string JobStatusTitle { get; set; }
		public string NavigationUrl { get; set; }
		public string Salary { get; set; }
		public string CurrencyID { get; set; }
		public string CurrencySymbol { get; set; }
		public string IndustryTypeTitle { get; set; }
		public string IsFavorite { get; set; }

		public string BrandName { get; set; }
		public string BULogoURL { get; set; }
		public string ContractTypeTitle { get; set; }
		public string IsBadMatch { get; set; }
		public string IsExpiredNow { get; set; }
		public string IsGoodMatch { get; set; }
		public string isLoggedIn { get; set; }
		public string IsSaved { get; set; }
		public string JobApplicationStatusId { get; set; }
		public string JobApplicationStatusTitle { get; set; }
		public string JobCategoryTitle { get; set; }
		public string JobDurationId { get; set; }

		public string PositionLevelId { get; set; }
		public string PositionLevelTitle { get; set; }
		public string PostingEndDate { get; set; }


		public string TimeScaleId { get; set; }
		public string TimeScaleTitle { get; set; }
		public string TitleURL { get; set; }
		public string SubIndustryTypeId { get; set; }
		public string SubIndustryTypeTitle { get; set; }
		public string TotalCommuteTime { get; set; }
		public string PublishSalary { get; set; }
		// Recruter Details 
		public string RecruiterCountryCode { get; set; }
		public string RecruiterEmail { get; set; }
		public string RecruiterName { get; set; }
		public string RecruiterPhone { get; set; }
		public string RecruiterPhoneCountryCode { get; set; }

		public string Description { get; set; }
		public string ApplyUri { get; set; }


		// Shift Types 
		//[Ignore]
		//public List<ShiftType> ShiftTypes {get;set;}
		//[Ignore]
		//public List<Skill> Skills { get; set; }


		public bool isFavorote { get; set; }
	}
	public class JobCMS : Job
	{
		public string ShiftTypes { get; set; }
		public string Skills { get; set; }
		public string JobLocation { get; set; }
		public string EmploymentTypeTitle { get; set; }
		public string isExpiredorNew { get; set; }



	}
	public class JobCIS : Job
	{
		public List<ShiftType> ShiftTypes { get; set; }
		public List<Skill> Skills { get; set; }
		public Location JobLocation { get; set; }

	}
	//PresentationFacetResults
	public class PresentationFacetResult
	{
		public string FacetDisplayName { get; set; }
		public string FacetValueCode { get; set; }
		public List<FacetValue> ListFacetValues { get; set; }
		public bool isSelected { get; set; }

	}

	public class SelectedFacets
	{
		public string keyName { get; set; }
		public string valueName { get; set; }

	}

	//


	public class FacetValue
	{
		public string ValueName { get; set; }
		public string ValueCount { get; set; }
		public string ValueChecked { get; set; }
		public string ValueUnChecked { get; set; }
		public bool isSelected { get; set; }

	}

	[Table("LatestJobs")]
	public class LatestJobs : JobCMS
	{ }

	public class Location
	{
		public string id { get; set; }
		public string CityName { get; set; }
		public string CountryId { get; set; }
		public string CountryName { get; set; }
		public string Distance { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public string StateName { get; set; }
	}

	public class ShiftType
	{
		public string Id { get; set; }
		public string ParentId { get; set; }
		public string ParentTitle { get; set; }
		public string Title { get; set; }
	}
	public class Skill
	{
		public string Id { get; set; }
		public string LevelId { get; set; }
		public string ProfiencyTypeId { get; set; }
		public string Title { get; set; }
		public string TypeId { get; set; }
	}

	public static class ConfigManager
	{
		static ConfigManager()
		{
	
		}
		public static string MaxSearchCount { get; set; }
		public static string DefaultRadius { get; set; }
		public static bool   EnableAutoSuggest { get; set; }
		public static string  MaxShortListCount { get; set; }
		public static string  FacetSettingId { get; set; }
		public static string  BLMaxResultCount { get; set; }
		public static string  EnableBranchSearch { get; set; }
		public static string  SearchLocationAPIName { get; set; }
		public static string  SearchLocationGoogleURL { get; set; }
		public static string  ProfiencyTypeId { get; set; }
		public static string  SearchLocationBingAPIKey { get; set; }
		public static string  BLResultSortingOrder { get; set; }
		public static string SiteDefaultLanguage { get; set; }
		public static string  TypeId { get; set; }

		public static string BLRadius { get; set;}

		// Array List
		public static List<string> SiteLanguages = new List<string>();
		public static List<string> BLDistance = new List<string>();
		public static List<string> SocialShare = new List<string>();
		public static List<string> JobSnippetFieldList = new List<string>();
		public static List<string> JobDetailFieldList = new List<string>();


		public static void readAppConfigurationSettings()
		{
			
			JObject elements = JObject.Parse(File.ReadAllText("Config.json"));
			//Console.WriteLine(elements);

			MaxSearchCount = elements["MaxSearchCount"].ToObject<string>();
			DefaultRadius = elements["DefaultRadius"].ToObject<string>();
			EnableAutoSuggest = elements["EnableAutoSuggest"].ToObject<bool>();
			SearchLocationGoogleURL = elements["SearchLocationGoogleURL"].ToObject<string>();


			MaxShortListCount = elements["MaxShortListCount"].ToObject<string>();
			FacetSettingId = elements["FacetSettingId"].ToObject<string>();
			BLMaxResultCount = elements["BLMaxResultCount"].ToObject<string>();
			EnableBranchSearch = elements["EnableBranchSearch"].ToObject<string>();
			SearchLocationAPIName = elements["SearchLocationAPIName"].ToObject<string>();


			SearchLocationBingAPIKey = elements["SearchLocationBingAPIKey"].ToObject<string>();
			BLResultSortingOrder = elements["BLResultSortingOrder"].ToObject<string>();
			SiteDefaultLanguage = elements["SiteDefaultLanguage"].ToObject<string>();

			JobSnippetFieldList = elements["JobSnippetFieldList"].ToObject<List<string>>();
			JobDetailFieldList = elements["JobDetailFieldList"].ToObject<List<string>>();
			SocialShare = elements["SocialShare"].ToObject<List<string>>();
			SiteLanguages = elements["SiteLanguages"].ToObject<List<string>>();
			BLDistance = elements["BLDistance"].ToObject<List<string>>();


			Console.WriteLine(JobSnippetFieldList);

			// Changes Constant file here.
			Constants.JobSearchFacetSettingID = FacetSettingId;

			// chose max number of result to be shown 
			int maxSearchCount = Convert.ToInt32(MaxSearchCount);
			MaxSearchCount = Math.Max(maxSearchCount, 10).ToString();

			Constants.displayCount = MaxSearchCount;
			Constants.maxResults = MaxSearchCount;
			Constants.latestJobsCount = MaxSearchCount;


			// SearchLocation Api - GOOGLE/BING API 
			if (SearchLocationAPIName.Equals("Google"))
				Constants.isGoogleLocation = "1";
			else
				Constants.isGoogleLocation = "0";

			Constants.DistanceDefault = Convert.ToInt32(DefaultRadius);
					
		}

	}

}