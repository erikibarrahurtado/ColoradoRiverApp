using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Xamarin.Essentials;

namespace ColoradoRiverApplication
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ImageButton _launchDamMenuButton;
        private TextView _appDescriptionTextView;
        private TextView _appTitleTextView;
        private TextView _secondAppTitleTextView;
        CancellationTokenSource cts;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            FindViews();
            BindData();
            LinkEventHandlers();
        }

        private void LinkEventHandlers()
        {
            _launchDamMenuButton.Click += _launchDamMenuButton_Click;
        }

        private void _launchDamMenuButton_Click(object sender, EventArgs e)
        {
            CancelSpeech();
            Intent intent = new Intent(this, typeof(DamMenuCustomerUIActivity));
            StartActivity(intent);

        }

        private void FindViews()
        {
            _launchDamMenuButton = FindViewById<ImageButton>(Resource.Id.letsDoThisButton);
            _appDescriptionTextView = FindViewById<TextView>(Resource.Id.appDescriptionTextViewId);
            _appTitleTextView = FindViewById<TextView>(Resource.Id.appTitleTextViewId);
            _secondAppTitleTextView = FindViewById<TextView>(Resource.Id.TamingTheMightyId);

        }
        private void BindData()
        {
            // set fonts
            var font = Typeface.CreateFromAsset(this.ApplicationContext.Assets, "EBGaramondVariableFont.ttf");
            _appDescriptionTextView.SetTypeface(font, TypefaceStyle.Normal);
            _appTitleTextView.SetTypeface(font, TypefaceStyle.Bold);
            _secondAppTitleTextView.SetTypeface(font, TypefaceStyle.Normal);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void CancelSpeech()
        {
            if (cts?.IsCancellationRequested ?? true)
                return;

            cts.Cancel();
        }
        protected override void OnResume() {
            base.OnResume();
            cts = new CancellationTokenSource();
            TextToSpeech.SpeakAsync(_appDescriptionTextView.Text, cancelToken: cts.Token).ContinueWith((t) =>
            {
                // Logic that will run after utterance finishes.

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

    }
}
