
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
using AndroidX.RecyclerView.Widget;
using ColoradoRiverApplication.Adapters;
using ColoradoRiverMobile.Core.Services;

namespace ColoradoRiverApplication
{
    [Activity(Label = "DamMenuActivity")]
    public class DamMenuActivity : Activity
    {
        private RecyclerView _damRecyclerView;
        private RecyclerView.LayoutManager _damLayoutManager;
        private DamAdapter _damAdapter;
        private RaspberryPiService _rpiService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.dam_menu);
            _damRecyclerView = FindViewById<RecyclerView>(Resource.Id.damMenuRecyclerView);

            // pie adapter
            _damLayoutManager = new LinearLayoutManager(this);

            _damRecyclerView.SetLayoutManager(_damLayoutManager);

            _damAdapter = new DamAdapter();
            _damAdapter.ItemClick += _damAdapter_ItemClick;
            _damRecyclerView.SetAdapter(_damAdapter);
            _rpiService = new RaspberryPiService();
        }

        private void _damAdapter_ItemClick(object sender, int e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(DamDetailActivity));
            intent.PutExtra("selectedDamId", e);
            StartActivity(intent);
            // UNCOMMENT
            _rpiService.Connect();
            _rpiService.TurnOnFan(e);
        }
    }
}
