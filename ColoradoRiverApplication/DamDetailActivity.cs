
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
using ColoradoRiverMobile.Core.Models;
using ColoradoRiverMobile.Core.Repository;

namespace ColoradoRiverApplication
{
    [Activity(Label = "DamDetailActivity", MainLauncher = true)]
    public class DamDetailActivity : Activity
    {
        private DamRepository _damRepository;
        private Dam _selectedDam;
        private ImageView _damImageView;
        private TextView _damNameTextView;
        private TextView _damDescriptionTextView;
        private Button _goBackButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.dam_detail);

            _damRepository = new DamRepository();
            _selectedDam = _damRepository.GetDamById(2);

            FindViews();
            BindData();
        }

        private void FindViews()
        {
            _damImageView = FindViewById<ImageView>(Resource.Id.damImageView);
            _damNameTextView = FindViewById<TextView>(Resource.Id.damNameTextView);
            _damDescriptionTextView = FindViewById<TextView>(Resource.Id.damDescriptionTextView);
            _goBackButton = FindViewById<Button>(Resource.Id.goBackButton);
        }
        private void BindData()
        {
            _damNameTextView.Text = _selectedDam.Name;
            _damDescriptionTextView.Text = _selectedDam.Description;
           
        }
    }
}
