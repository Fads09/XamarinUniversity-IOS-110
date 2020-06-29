﻿using Android.App;
using Android.Widget;
using Android.OS;

namespace XamarinUniversity.Droid
{
    [Activity(Label = "XamarinUniversity", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            var data = FindViewById<ListView>(Resource.Id.instructorListView);
            var adapter = new ArrayAdapter<Instructor>(this, Android.Resource.Layout.SimpleListItem1, InstructorData.Instructors);
            data.Adapter = adapter;
        }
    }
}
