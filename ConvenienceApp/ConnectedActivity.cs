using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using ConvenienceBackend;

namespace ConvenienceApp
{
    [Activity(Label = "Person auswaehlen")]
    public class ConnectedActivity : Activity,ListView.IOnItemClickListener
    {


        ConNetClient client;

		List<String> list3;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Connected);

			try {
				client = new ConNetClient();
            	client.Connect();
            	client.Update();
				client.Close ();
			}
			catch (Exception e)
			{
				this.alert ("Verbindung konnte nicht aufgebaut werden. Bitte App beenden und spaeter neu starten!");
				return;
			}
			ConApp.client = client;
      		ListView listview = FindViewById<ListView>(Resource.Id.listView1);
            
            listview.SetBackgroundColor(Android.Graphics.Color.DarkOrange);

            
			/*
            List<String> list = new List<string>();
            List<Tuple<String, String>> list2 = new List<Tuple<string, string>>();
            list.Add("Test1!");
            list.Add("Test2!");
            list2.Add(new Tuple<string, string>("Test1!", "uTest1"));
            list2.Add(new Tuple<string, string>("Test2!", "uTest2"));*/

			list3 = new List<string> ();
			foreach (String s in ConApp.client.Users.Keys)
			{
				list3.Add (s);
			}

            listview.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemSingleChoice, list3);
            listview.BringToFront();

            listview.OnItemClickListener = this;

            
        }


        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
			ConApp.User = list3.ElementAt (position);
			StartActivity(typeof(ProductActivity));
        }

        public void OnPause()
        {
            base.OnPause();
            //tear down Connection if needed
        }

        public void OnStop()
        {
            base.OnStop();
            //tear down data structures if needed
        }

		public void alert(String msg)
		{
			AlertDialog.Builder builder = new AlertDialog.Builder(this);
			builder.SetTitle(Android.Resource.String.DialogAlertTitle);
			builder.SetIcon(Android.Resource.Drawable.IcDialogAlert);
			builder.SetMessage(msg);
			builder.SetPositiveButton("OK", (sender, e) =>
			{
				//nope
			});

			builder.Show();
		}
    }
}