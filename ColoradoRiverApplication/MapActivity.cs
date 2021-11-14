
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace ColoradoRiverApplication
{

    [Activity(Label = "MapActivity")]
    public class MapActivity : AppCompatActivity, IOnMapReadyCallback
    {
        private readonly LatLng _coloradoRiverLocation = new LatLng(50.850346, 4.351721);
        GoogleMap _googleMap;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GoogleMap);

            var mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);

            // Create your application here
        }
        public void OnMapReady(GoogleMap map) {

            _googleMap = map;

            _googleMap.UiSettings.ZoomControlsEnabled = true;
            _googleMap.UiSettings.CompassEnabled = true;
            _googleMap.UiSettings.MyLocationButtonEnabled = false;
            AddMarker();
            
        }

        private void AddMarker()
        {
            var marker = new MarkerOptions();
            marker.SetPosition(_coloradoRiverLocation).SetTitle("Colorado River");
            _googleMap.AddMarker(marker);

            var cameraUpdate = CameraUpdateFactory.NewLatLngZoom(_coloradoRiverLocation, 15);
            _googleMap.MoveCamera(cameraUpdate);
        }
    }
}
