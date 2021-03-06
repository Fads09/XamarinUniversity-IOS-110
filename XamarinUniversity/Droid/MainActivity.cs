﻿using Android.App;
using Android.Widget;
using Android.OS;
using System;

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
            data.FastScrollEnabled= true;
            data.ItemClick += OnItemClick;
            data.Adapter = new InstructorAdapter(InstructorData.Instructors);

        }

        void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var instructor = InstructorData.Instructors[e.Position];

            var dialog = new AlertDialog.Builder(this);
            dialog.SetMessage(instructor.Name);
            dialog.SetNeutralButton("OK", delegate { });
            dialog.Show();
        }
    }
}

