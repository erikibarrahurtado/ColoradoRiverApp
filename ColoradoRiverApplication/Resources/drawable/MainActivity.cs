﻿using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace ColoradoRiverApplication
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _launchDamMenuButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            FindViews();
            LinkEventHandlers();
        }

        private void LinkEventHandlers()
        {
            _launchDamMenuButton.Click += _launchDamMenuButton_Click; 
        }

        private void _launchDamMenuButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(DamMenuActivity));
            StartActivity(intent);

        }

        private void FindViews()
        {
            _launchDamMenuButton = FindViewById<Button>(Resource.Id.letsDoThisButton);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}
