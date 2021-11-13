
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ColoradoRiverMobile.Core.Repository;
using ColoradoRiverMobile.Core.Services;

namespace ColoradoRiverApplication
{
    [Activity(Label = "DummyDamMenuActivity")]
    public class DummyDamMenuActivity : Activity
    {
        private RaspberryPiService _rpiService;
        private DamRepository _damRepository;
        private ImageButton _Ribbon1;
        private ImageButton _Ribbon2;
        private ImageButton _Ribbon3;
        private ImageButton _Ribbon4;
        private ImageButton _Ribbon5;
        private ImageButton _Ribbon6;
        private ImageButton _Ribbon7;
        private ImageButton _Ribbon8;
        private ImageButton _Ribbon9;
        private ImageButton _Ribbon10;
        private ImageButton _HomeButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DummyDam_menu);
            _rpiService = new RaspberryPiService();
            _damRepository = new DamRepository();
            BindViews();
            LinkEventHandlers();
        }
        private void BindViews()
        {
            _Ribbon1 = FindViewById<ImageButton>(Resource.Id.Ribbon1);
            _Ribbon2 = FindViewById<ImageButton>(Resource.Id.Ribbon2);
            _Ribbon3 = FindViewById<ImageButton>(Resource.Id.Ribbon3);
            _Ribbon4 = FindViewById<ImageButton>(Resource.Id.Ribbon4);
            _Ribbon5 = FindViewById<ImageButton>(Resource.Id.Ribbon5);
            _Ribbon6 = FindViewById<ImageButton>(Resource.Id.Ribbon6);
            _Ribbon7 = FindViewById<ImageButton>(Resource.Id.Ribbon7);
            _Ribbon8 = FindViewById<ImageButton>(Resource.Id.Ribbon8);
            _Ribbon9 = FindViewById<ImageButton>(Resource.Id.Ribbon9);
            _Ribbon10 = FindViewById<ImageButton>(Resource.Id.Ribbon10);
            _HomeButton = FindViewById<ImageButton>(Resource.Id.HomeButton);
        }
        private void LinkEventHandlers()
        {

            _Ribbon1.Click += _firstRibbon_Click;
            _Ribbon2.Click += _firstRibbon_Click;
            _Ribbon3.Click += _firstRibbon_Click;
            _Ribbon4.Click += _firstRibbon_Click;
            _Ribbon5.Click += _firstRibbon_Click;
            _Ribbon6.Click += _firstRibbon_Click;
            _Ribbon7.Click += _firstRibbon_Click;
            _Ribbon8.Click += _firstRibbon_Click;
            _Ribbon9.Click += _firstRibbon_Click;
            _Ribbon10.Click += _firstRibbon_Click;
            _HomeButton.Click += _HomeButton_Click;
        }

        private void _HomeButton_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

        private async void _firstRibbon_Click(object sender, EventArgs e)
        {

            ImageButton imageButton = (ImageButton)sender;
            var clickedDamId = imageButton.Tag.ToString();
            var damIdInt = Convert.ToInt32(clickedDamId);
            var intent = new Intent();
            intent.SetClass(this, typeof(DamDetailActivity));
            intent.PutExtra("selectedDamId", damIdInt);
            StartActivity(intent);

            var _damSelected = _damRepository.GetDamById(damIdInt);
            // run task async
            var t = Task.Run(() => _rpiService.ConnectAndTurnOnDamGPIO(_damSelected.GPIO)); // Exception is handled, if failed to connect, the app will continue running.
            //t.Wait();


            // previous version these would run synchrounously.
            //_rpiService.Connect();
            //var _damSelected = _damRepository.GetDamById(damIdInt);
            //_rpiService.TurnOnFan(_damSelected.GPIO);

        }
    }
}
