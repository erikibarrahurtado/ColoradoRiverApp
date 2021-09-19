
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

namespace ColoradoRiverApplication
{
    [Activity(Label = "DamMenuActivity", MainLauncher = true)]
    public class DamMenuActivity : Activity
    {
        private RecyclerView _damRecyclerView;
        private RecyclerView.LayoutManager _damLayoutManager;
        private DamAdapter _damAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.dam_menu);
            _damRecyclerView = FindViewById<RecyclerView>(Resource.Id.damMenuRecyclerView);

            // pie adapter
            _damLayoutManager = new LinearLayoutManager(this);
            _damRecyclerView.SetLayoutManager(_damLayoutManager);

            _damAdapter = new DamAdapter();
            _damRecyclerView.SetAdapter(_damAdapter);

        }
    }
}
