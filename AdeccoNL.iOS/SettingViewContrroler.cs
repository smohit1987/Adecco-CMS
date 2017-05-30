using System;
using Foundation;
using UIKit;

namespace AdeccoNL.iOS
{
	public partial class SettingViewContrroler : UIViewController
	{


		public SettingViewContrroler(IntPtr handle) : base(handle)
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			this.Title = "Settings";

			this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes()
			{
				ForegroundColor = UIColor.White
			};

			//#EEEEEE   light Grey color 
			View.BackgroundColor = UIColor.Clear.FromHexString("##EEEEEE", 1.0f);

			//#FFFFFF  white color 
			bgView.BackgroundColor = UIColor.Clear.FromHexString("##FFFFFF", 1.0f);
			bgView.Layer.BorderColor = UIColor.LightGray.CGColor;
			bgView.Layer.BorderWidth = 0.5f;
			bgView.Layer.CornerRadius = 2.0f;
			bgView.Layer.MasksToBounds = true;

			txtLanguage.TextColor = UIColor.DarkGray;
			txtLanguage.Font = UIFont.SystemFontOfSize(14);

			txtCountry.TextColor = UIColor.DarkGray;
			txtCountry.Font = UIFont.SystemFontOfSize(14);

			btnApply.Layer.CornerRadius = 2.0f;


			this.txtLanguage.AttributedPlaceholder = new NSAttributedString(
			"Please Select Your Language.",
							font: UIFont.SystemFontOfSize(14),
					foregroundColor: UIColor.DarkGray,
			strokeWidth: 0
			);


			this.txtCountry.AttributedPlaceholder = new NSAttributedString(
					"Please Select Your Country.",
							font: UIFont.SystemFontOfSize(14),
							foregroundColor: UIColor.DarkGray,
			strokeWidth: 0
		);

			txtCountry.ShouldBeginEditing += ShouldBeginEditing;
			txtLanguage.ShouldBeginEditing += ShouldBeginEditing;


			// Get Shared User Defaults
			var userPref = NSUserDefaults.StandardUserDefaults;
			txtCountry.Text = userPref.StringForKey("defaultCountry");
			txtLanguage.Text = userPref.StringForKey("defaultLanguage");
		}


		private bool ShouldBeginEditing(UITextField textfield)
		{
			string _path = NSBundle.MainBundle.PathForResource("Country-Lang", "plist");
			var countryDictionary = NSDictionary.FromFile(_path);
			//Console.WriteLine("Country-Lang = {0}",dict);


			if (textfield == txtCountry)
			{
				this.showCountry(countryDictionary.Keys);

			}
			else
			{
				string key = this.txtCountry.Text;

				if (string.IsNullOrWhiteSpace(key))
				{
					var alert = UIAlertController.Create("Adecco", "Please select your Country first.", UIAlertControllerStyle.Alert);
					alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
					PresentViewController(alert, animated: true, completionHandler: null);

					return false;
				}

				NSDictionary langDictionary = countryDictionary.ValueForKey((Foundation.NSString)key) as NSDictionary;
				this.showLanguage(langDictionary.Keys);

			}

			return false;

		}
		public void showCountry(NSObject[] keys)
		{
			// Create a new Alert Controller
			UIAlertController actionSheetAlert = UIAlertController.Create("Select Country", "", UIAlertControllerStyle.ActionSheet);
			// Add Actions
			//actionSheetAlert.AddAction(UIAlertAction.Create("5 Km", UIAlertActionStyle.Default, (action) => selectedCountry("5 Km")));
			//actionSheetAlert.AddAction(UIAlertAction.Create("25 Km", UIAlertActionStyle.Default, (action) => selectedCountry("25 Km")));
			//actionSheetAlert.AddAction(UIAlertAction.Create("50 Km", UIAlertActionStyle.Default, (action) => selectedCountry("50 Km")));


			foreach (NSObject key in keys)
			{
				actionSheetAlert.AddAction(UIAlertAction.Create(key.ToString(), UIAlertActionStyle.Default, (action) => selectedCountry(key.ToString())));

			}
			actionSheetAlert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (action) => Console.WriteLine("Cancel button pressed.")));

			// Display the alert
			this.PresentViewController(actionSheetAlert, true, null);

		}

		public void selectedCountry(string aCountry)
		{

			this.txtCountry.Text = aCountry;

			string _path = NSBundle.MainBundle.PathForResource("Country-Lang", "plist");
			var countryDictionary = NSDictionary.FromFile(_path);
			NSDictionary langDictionary = countryDictionary.ValueForKey((Foundation.NSString)aCountry) as NSDictionary;

			if (langDictionary.Count > 1)
			{
				this.txtLanguage.Text = "";
				this.showLanguage(langDictionary.Keys);
			}
			else
			{
				this.txtLanguage.Text = (langDictionary.Keys[0]).ToString();

				//this.txtLanguage.Text = langDictionary.ValueForKey((Foundation.NSString)langDictionary.Keys[0]).ToString();
			}
		}

		public void showLanguage(NSObject[] keys)
		{
			// Create a new Alert Controller
			UIAlertController actionSheetAlert = UIAlertController.Create("Select Language", "", UIAlertControllerStyle.ActionSheet);

			foreach (NSObject key in keys)
			{
				actionSheetAlert.AddAction(UIAlertAction.Create(key.ToString(), UIAlertActionStyle.Default, (action) => selectedLanguage(key.ToString())));

			}
			actionSheetAlert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (action) => Console.WriteLine("Cancel button pressed.")));

			// Display the alert
			this.PresentViewController(actionSheetAlert, true, null);

		}

		public void selectedLanguage(string lang)
		{
			//Console.WriteLine("Selected Radius is = {0}",aRadius);
			this.txtLanguage.Text = lang;
		}


		partial void BtnApply_TouchUpInside(UIButton sender)
		{
			this.View.EndEditing(true);

			if (string.IsNullOrWhiteSpace(this.txtCountry.Text))
			{
				var alert = UIAlertController.Create("Adecco", "Please select your Country first.", UIAlertControllerStyle.Alert);
				alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
				PresentViewController(alert, animated: true, completionHandler: null);

				return;
			}
			else if (string.IsNullOrWhiteSpace(this.txtLanguage.Text))
			{
				var alert = UIAlertController.Create("Adecco", "Please select your Language.", UIAlertControllerStyle.Alert);
				alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
				PresentViewController(alert, animated: true, completionHandler: null);

				return;
			}

			string _path = NSBundle.MainBundle.PathForResource("Country-Lang", "plist");
			var countryDictionary = NSDictionary.FromFile(_path);

			string country = this.txtCountry.Text;
			NSDictionary langDictionary = countryDictionary.ValueForKey((Foundation.NSString)country) as NSDictionary;
			var language = langDictionary.ValueForKey((Foundation.NSString)txtLanguage.Text);

			Console.WriteLine("selected country = {0} & Language == {1}", country, language);

			var userPref = NSUserDefaults.StandardUserDefaults;
			// set value
			userPref.SetString(this.txtCountry.Text, "defaultCountry");
			userPref.SetString(this.txtLanguage.Text, "defaultLanguage");
			userPref.SetString(language.ToString(), "defaultRegion");
			userPref.Synchronize();

			// Set translation - localizations
			Translations.setTranslations(country, language.ToString());

			// Set api configuration  
			Constants.setOfflineConfigs(country, language.ToString());

			Constants.isConigurationChanged = true;

			this.NavigationController.PopViewController(true);

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

